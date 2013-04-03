using System;

namespace ChainGang.Resolution
{
    public class CompositeResolver<TFirst, TSecond> : IDependencyResolver
        where TFirst : class, IDependencyResolver
        where TSecond : class, IDependencyResolver
    {
        private readonly TFirst _firstResolver;
        private readonly TSecond _secondResolver;

        public CompositeResolver(TFirst firstResolver, TSecond secondResolver)
        {
            if (firstResolver == null)
            {
                throw new ArgumentNullException("firstResolver");
            }

            if (secondResolver == null)
            {
                throw new ArgumentNullException("secondResolver");
            }

            _firstResolver = firstResolver;
            _secondResolver = secondResolver;
        }

        public TFirst First
        {
            get { return _firstResolver; }
        }

        public TSecond Second
        {
            get { return _secondResolver; }
        }

        public object GetService(Type type, object key)
        {
            return First.GetService(type, key) ?? Second.GetService(type, key);
        }
    }
}