namespace ChainGang.Resolution
{
    public delegate object DependencyScopeTagFactory(IDependencyScope parentScope);

    public delegate IDependencyScope DependencyScopeFactory(IDependencyResolver resolver, object tag);
}