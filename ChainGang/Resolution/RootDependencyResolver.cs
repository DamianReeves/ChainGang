using System;
using ChainGang.Resolution;

namespace ChainGang.Resolution
{   
    internal class RootDependencyResolver : IDependencyResolver
    {
        private readonly ResolverChain _resolvers = new ResolverChain();

        public RootDependencyResolver()
        {
            DependencyScopeTagFactory defaultTagFactory = _ => Guid.NewGuid();
            _resolvers.Add(new SingletonDependencyResolver<DependencyScopeTagFactory>(defaultTagFactory));
        }        

        public object GetService(Type type, object key)
        {
            return _resolvers.GetService(type, key);
        }
    }
}