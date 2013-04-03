using System;

namespace ChainGang.Resolution
{
    public class SingletonDependencyResolver<T> : IDependencyResolver where T : class
    {
        private readonly T _instance;
        private readonly object _key;

        public SingletonDependencyResolver(T instance):this(instance, null)
        {
        }

        public SingletonDependencyResolver(T instance, object key)
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
            var instanceType = typeof (T);
            return type == instanceType && (_key == null || Equals(key, _key)) 
                       ? _instance 
                       : null;
        }
    }
}