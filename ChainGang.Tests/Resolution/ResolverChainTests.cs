using FluentAssertions;
using NUnit.Framework;

namespace ChainGang.Resolution
{
    [TestFixture]
    public class ResolverChainTests
    {

        [Test]
        public void GetService_Returns_Null_If_Service_Not_Found()
        {
            var resolver = new ResolverChain();
            var anon = new {};
            var result = resolver.GetService(anon.GetType(), null);
            result.Should().BeNull();
        }

        [Test]
        public void GetService_Chooses_Most_Recent_In_Chain()
        {
            var resolver = new ResolverChain();
            resolver.Add(new TransientDependencyResolver<string>(()=>"Goodbye"));
            resolver.Add(new TransientDependencyResolver<string>(() => "Hello"));

            var message = resolver.GetService(typeof (string), null);
            message.Should().Be("Hello");
        }
    }
}
