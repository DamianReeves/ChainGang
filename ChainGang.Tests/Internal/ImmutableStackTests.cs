using FluentAssertions;
using NUnit.Framework;

namespace ChainGang.Internal
{
    [TestFixture]
    public class ImmutableStackTests
    {
        [Test]
        public void Create_With_No_Args_Returns_An_Empty_Stack()
        {
            var stack = ImmutableStack.Create<int>();
            stack.IsEmpty.Should().BeTrue("Call to Create<T>() should produce an empty stack.");
        }

        [Test]
        public void Create_Returns_A_Stack_With_Item_As_Only_Item()
        {
            var stack = ImmutableStack.Create(1);
            stack.Should().ContainSingle(item => item == 1);
        }

        [Test]
        public void Push_Returns_New_Stack_With_Pushed_Item_On_Top()
        {
            var originalStack = ImmutableStack.Create(2);
            var stack = originalStack.Push(1);            
            stack.Should().ContainInOrder(1, 2);
            ((object)stack).Should().NotBeSameAs(originalStack);
        }

        [Test]
        public void Push_Does_Not_Modify_Original_Stack()
        {
            var originalStack = ImmutableStack.Create(2);
            var stack = originalStack.Push(1);
            ((object) stack).Should().NotBeSameAs(originalStack);
        }
    }
}
