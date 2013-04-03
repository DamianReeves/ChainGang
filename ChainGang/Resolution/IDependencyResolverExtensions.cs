using System;

namespace ChainGang.Resolution
{
//// ReSharper disable InconsistentNaming
    public static class IDependencyResolverExtensions
    {
        public static T GetService<T>(this IDependencyResolver resolver, object key)
        {
            if (resolver == null)
            {
                throw new ArgumentNullException("resolver");
            }

            return (T)resolver.GetService(typeof (T), key);
        }

        public static T GetService<T>(this IDependencyResolver resolver)
        {
            if (resolver == null)
            {
                throw new ArgumentNullException("resolver");
            }

            return (T) resolver.GetService(typeof (T), null);
        }

        public static object GetService(this IDependencyResolver resolver, Type type)
        {
            if (resolver == null)
            {
                throw new ArgumentNullException("resolver");
            }

            return resolver.GetService(type, null);
        }
    }
//// ReSharper restore InconsistentNaming
}