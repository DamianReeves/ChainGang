using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace ChainGang.Resolution
{
    [TestFixture]
    public class DependencyScopeTests
    {
        [Test]
        public void BeginScope_Returns_NonNull_Scope()
        {
            var rootScope = new DependencyScope();
            var childScope = rootScope.BeginScope(null, null);
            childScope.Should().NotBeNull();
        }

        [Test]
        public void Dependencies_Are_Resolved_In_Child_Scope_First()
        {
            var rootScope = new DependencyScope();
            var items = new[]
                {
                    new { Tag = "Root" },
                    new { Tag = "Child" },
                };
            rootScope.AddResolver(SingletonDependencyResolver.Create(items[0]));
            var childScope = rootScope.BeginScope(null, SingletonDependencyResolver.Create(items[1]));
            var item = childScope.GetService(items[0].GetType(), null);
            item.Should().Be(items[1]);
        }

        [Test]
        public void Dependencies_In_Parent_Scope_Can_Be_Resolved()
        {
            var rootScope = new DependencyScope();
            var expected = new RootItem();
            rootScope.AddResolver(SingletonDependencyResolver.Create(expected));
            var childScope = rootScope.BeginScope(null, SingletonDependencyResolver.Create(new ChildItem()));
            var item = childScope.GetService<RootItem>();
            item.Should().Be(expected);
        }

        private class RootItem {}
        private class ChildItem {}
    }
}
