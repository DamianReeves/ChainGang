using System;
using System.Runtime.Serialization;
using ChainGang.Internal;

namespace ChainGang.Resolution
{   
    public interface IDependencyScope : IDependencyResolver, IDisposable
    {
        IDependencyScope BeginScope(object tag, IDependencyResolver resolver);
        object Tag { get; }
    }
}