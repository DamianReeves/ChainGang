using System;
using System.Linq;
using System.Threading;
using ChainGang.Internal;

namespace ChainGang.Resolution
{
    public class ResolverChain : IDependencyResolver
    {
        private volatile IImmutableStack<IDependencyResolver> _resolvers = ImmutableStack.Create<IDependencyResolver>();

        public virtual void Add(IDependencyResolver resolver)
        {
            _resolvers = _resolvers.Push(resolver);
        }

        public object GetService(Type type, object key)
        {
            return _resolvers
                .Select(r => r.GetService(type, key))
                .FirstOrDefault(s => s != null);
        }
    }
}