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
            DependencyScopeFactory defaultScopeFactory = CreateDependencyScope;
            _resolvers.Add(new SingletonDependencyResolver<DependencyScopeFactory>(defaultScopeFactory));
        }        

        public object GetService(Type type, object key)
        {
            return _resolvers.GetService(type, key);
        }

        protected virtual IDependencyScope CreateDependencyScope(
            IDependencyResolver parentResolver, 
            object tag, 
            IDependencyResolver scopeSpecificResolver)
        {
            var primary = new ResolverChain();
            primary.Add(scopeSpecificResolver);
            var fallback = new ResolverChain();
            return new DependencyScope(primary, fallback);
        }
    }
}