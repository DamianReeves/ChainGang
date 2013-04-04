using System;
using ChainGang.Internal.Disposables;

namespace ChainGang.Resolution
{
    public class DependencyScope : IDependencyScope, ICancelable
    {
        private CompositeDisposable _scopeHandles = new CompositeDisposable();
        private readonly CompositeResolver<ResolverChain,ResolverChain> _resolvers;

        public DependencyScope() : this(null, new ResolverChain(), new ResolverChain(), new RootDependencyResolver())
        {            
        }

        public DependencyScope(object tag) : this(tag, new ResolverChain(), new ResolverChain(), new RootDependencyResolver())
        {            
        }

        public DependencyScope(ResolverChain primaryChain, ResolverChain fallbackChain)
            :this(null, primaryChain, fallbackChain, new RootDependencyResolver())
        {            
        }

        public DependencyScope(object tag, ResolverChain primaryChain, ResolverChain fallbackChain)
            : this(tag, primaryChain, fallbackChain, new RootDependencyResolver())
        {
        }

        public DependencyScope(object tag, IDependencyResolver resolver)
        {
            
        }

        internal DependencyScope(object tag, ResolverChain primaryChain, ResolverChain fallbackChain, RootDependencyResolver rootResolver)
        {
            if (primaryChain == null)
            {
                throw new ArgumentNullException("primaryChain");
            }
            if (fallbackChain == null)
            {
                throw new ArgumentNullException("fallbackChain");
            }
            if (rootResolver == null)
            {
                throw new ArgumentNullException("rootResolver");
            }
            
            _resolvers = new CompositeResolver<ResolverChain, ResolverChain>(primaryChain, fallbackChain);
            fallbackChain.Add(rootResolver);
            Tag = tag;
        }

        public object Tag { get; private set; }
        public bool IsDisposed { get; private set; }

        public virtual object GetService(Type type, object key)
        {
            return _resolvers.GetService(type, key);
        }                

        public IDependencyScope BeginScope(object tag, IDependencyResolver resolver)
        {
            var scopeFactory = _resolvers.GetService<DependencyScopeFactory>();
            if (scopeFactory == null)
            {
                throw new DependencyNotFoundException(typeof(DependencyScopeFactory), null);
            }

            return scopeFactory(this, tag, resolver);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !IsDisposed)
            {
                var handles = _scopeHandles;
                if (handles != null)
                {
                    handles.Dispose();
                    IsDisposed = true;
                    _scopeHandles = null;
                }
            }
        }        
    }

    //public class ExtendableDependencyScope : DependencyScope
    //{
    //    private readonly CompositeResolver<ResolverChain, ResolverChain> _resolvers;

    //    public void AddResolver(IDependencyResolver resolver, bool includeInPrimary = false)
    //    {

    //    }
    //}
}