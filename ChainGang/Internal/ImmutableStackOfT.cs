using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainGang.Internal
{
    internal interface IImmutableStack<out T> : IEnumerable<T>
    {
        IImmutableStack<T> Pop();
        T Peek();
        bool IsEmpty { get; }
    }

    internal sealed class ImmutableStack<T> : IImmutableStack<T>
    {
//// ReSharper disable InconsistentNaming
        private static readonly EmptyStack _empty = new EmptyStack();
//// ReSharper restore InconsistentNaming
        public static IImmutableStack<T> Empty { get { return _empty; } }
        private readonly T _head;
        private readonly IImmutableStack<T> _tail;
        
        private ImmutableStack(T head, IImmutableStack<T> tail)
        {
            _head = head;
            _tail = tail;
        }

        public bool IsEmpty { get { return false; } }

        public T Peek()
        {
            return _head;
        }

        public IImmutableStack<T> Pop()
        {
            return _tail;
        }

        public static IImmutableStack<T> Push(T head, IImmutableStack<T> tail)
        {
            return new ImmutableStack<T>(head, tail ?? Empty);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (IImmutableStack<T> stack = this; !stack.IsEmpty; stack = stack.Pop())
            {
                yield return stack.Peek();
            }                
        }

        IEnumerator IEnumerable.GetEnumerator() {return this.GetEnumerator();}

        private sealed class EmptyStack : IImmutableStack<T>
        {
            public bool IsEmpty { get { return true; } }
            public T Peek()
            {
                throw new InvalidOperationException("Cannot perform a Peek on an empty stack.");
            }

            public IImmutableStack<T> Pop()
            {
                throw new InvalidOperationException("Cannot perform a Pop on an empty stack.");
            }

            public IEnumerator<T> GetEnumerator() { yield break; }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }
    }
}
