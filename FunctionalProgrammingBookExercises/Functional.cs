using System;

using FunctionalProgrammingBookExercises.Option;

namespace FunctionalProgrammingBookExercises
{
    public static class Functional
    {
        public static Option.None None => Option.None.Default;

        public static Option<T> Some<T>(T value) => new Option.Some<T>(value);

        public struct Option<T>
        {
            private readonly bool isSome;
            private readonly T value;

            private Option(T value)
            {
                this.isSome = true;
                this.value = value;
            }

            public static implicit operator Option<T>(Option.None _) => new Option<T>();

            public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);

            public static implicit operator Option<T>(T value) => new Some<T>(value);

            public TResult Match<TResult>(Func<TResult> none, Func<T, TResult> some) => isSome ? some(value) : none();
        }
    }

    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new None();
        }

        public struct Some<T>
        {
            internal T Value { get; }

            internal Some(T value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                Value = value;
            }
        }
    }
}
