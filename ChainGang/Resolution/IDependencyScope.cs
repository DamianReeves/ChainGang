using System;

namespace ChainGang.Resolution
{   
    public interface IDependencyScope : IDependencyResolver, IDisposable
    {
        IDependencyScope BeginScope(object tag, IDependencyResolver resolver);
        object Tag { get; }
    }        

    public class DependencyScope : IDependencyScope
    {
        private readonly CompositeResolver<ResolverChain,ResolverChain> _resolvers;        

        public DependencyScope():this(new RootDependencyResolver())
        {            
        }

        internal DependencyScope(RootDependencyResolver rootResolver)
        {


            var tagFactory = _resolvers.GetService<DependencyScopeTagFactory>();
            Tag = tagFactory == null ? null : tagFactory(null);
        }

        public object Tag { get; private set; }

        public object GetService(Type type, object key)
        {
            return _resolvers.GetService(type, key);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IDependencyScope BeginScope(object tag, IDependencyResolver resolver)
        {
            throw new NotImplementedException();
        }        
    }
}