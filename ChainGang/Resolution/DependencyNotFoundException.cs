using System;
using ChainGang.Properties;

namespace ChainGang.Resolution
{
    public class DependencyNotFoundException : Exception
    {        
        public DependencyNotFoundException():this(Resources.DependencyNotFoundExceptionMessage)
        {
        }

        public DependencyNotFoundException(Type dependencyType, object dependencyKey)
            :this(string.Format(Resources.DependencyNotFoundExceptionMessageFormat, dependencyType, dependencyKey ?? (object)"{NULL}"))
        {
            DependencyType = dependencyType;
            DependencyKey = dependencyKey;
        }

        public DependencyNotFoundException(string message) : base(message)
        {
        }

        public DependencyNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        public Type DependencyType { get; set; }
        public object DependencyKey { get; set; }
    }
}