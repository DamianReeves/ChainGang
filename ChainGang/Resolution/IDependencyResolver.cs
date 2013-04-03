using System;

namespace ChainGang.Resolution
{
    public interface IDependencyResolver
    {
        object GetService(Type type, object key);
    }
}
