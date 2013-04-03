using System;

namespace ChainGang.Resolution
{
    public class LazyDependencyResolver<T> : IDependencyResolver
    {
        private readonly Lazy<T> _instance;
        private readonly object _key ;

        public LazyDependencyResolver() : this(new Lazy<T>(), null)
        {            
        }

        public LazyDependencyResolver(object key) : this(new Lazy<T>(), key)
        {
        }

        public LazyDependencyResolver(Func<T> activator) : this(new Lazy<T>(activator), null)
        {            
        }

        public LazyDependencyResolver(Func<T> activator, object key) 
            : this(new Lazy<T>(activator), key)
        {
        }

        public LazyDependencyResolver(Lazy<T> instance, object key)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            _instance = instance;
            _key = key;
        }

        public object GetService(Type type, object key)
        {
            return (typeof (T) == type && (_key == null || (Equals(_key, key))))
                       ? (object)_instance.Value
                       : null;
        }
    }
}