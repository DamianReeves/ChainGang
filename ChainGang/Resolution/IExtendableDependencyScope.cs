namespace ChainGang.Resolution
{
    public interface IExtendableDependencyScope
    {
        void AddResolver(IDependencyResolver resolver, bool includeInPrimary = false);
        void Lock();
    }
}