using System;
using System.Collections.Generic;
using System.Linq;

using FunctionalProgrammingBookExercises.Option;

namespace FunctionalProgrammingBookExercises
{
    public static class Functional
    {
        public static None None => None.Default;

        public static Option<T> Some<T>(T value) => new Some<T>(value);

        public static Option<TResult> Bind<T, TResult>(this Option<T> source, Func<T, Option<TResult>> function)
            => source.Match(
                () => None,
                function);

        public static IEnumerable<TResult> Bind<T, TResult>(this IEnumerable<T> source, Func<T, IEnumerable<TResult>> function)
        {
            return source.SelectMany(function);
        }

        public readonly struct Option<T>
        {
            private readonly bool isSome;
            private readonly T value;

            private Option(T value)
            {
                isSome = true;
                this.value = value;
            }

            public static implicit operator Option<T>(None _) => default;

            public static implicit operator Option<T>(Some<T> some) => new Option<T>(some.Value);

            public static implicit operator Option<T>(T value) => new Some<T>(value);

            public TResult Match<TResult>(Func<TResult> none, Func<T, TResult> some)
            {
                if (some == null)
                {
                    throw new ArgumentNullException(nameof(some));
                }

                if (none == null)
                {
                    throw new ArgumentNullException(nameof(none));
                }

                return isSome
                    ? some(value)
                    : none();
            }
        }
    }

    namespace Option
    {
        public readonly struct None
        {
            internal static None Default { get; }
        }

        public readonly struct Some<T>
        {
            internal Some(T value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                Value = value;
            }

            internal T Value { get; }
        }
    }
}
