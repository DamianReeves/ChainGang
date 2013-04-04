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
    }
}
