using System;

namespace ChainGang.Resolution
{
    public class TransientDependencyResolver<T> : IDependencyResolver
    {
        private readonly Func<T> _activator;
        private readonly object _key;        

        public TransientDependencyResolver(Func<T> activator) : this(activator, null)
        {            
        }

        public TransientDependencyResolver(Func<T> activator, object key)
        {
            if (activator == null)
            {
                throw new ArgumentNullException("activator");
            }

            _activator = activator;
            _key = key;
        }

        public object GetService(Type type, object key)
        {
            return typeof (T) == type && (_key == null || Equals(_key, key)) 
                       ? (object) _activator() 
                       : null;
        }
    }
}