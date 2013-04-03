using System.Collections.Generic;

namespace ChainGang.Internal
{
    internal static class ImmutableStack
    {
        public static IImmutableStack<T> Create<T>()
        {
            return ImmutableStack<T>.Empty;
        }

        public static IImmutableStack<T> Create<T>(T head)
        {
            return ImmutableStack<T>.Empty.Push(head);
        }

        public static IImmutableStack<T> Push<T>(this IImmutableStack<T> self, T t)
        {
            return ImmutableStack<T>.Push(t, self);
        }
    }
}