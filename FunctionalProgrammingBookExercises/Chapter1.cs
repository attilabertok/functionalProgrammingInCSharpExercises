using System;
using System.Collections.Generic;

namespace FunctionalProgrammingBookExercises
{
    public static class Chapter1
    {
        public static Func<TSource, bool> Negate<TSource>(this Func<TSource, bool> predicate)
        {
            return t => !predicate(t);
        }

        public static List<int> QuickSort(this List<int> source)
        {
            var result = new List<int>(source);
            result.Sort();

            return result;
        }

        public static List<T> QuickSort<T>(this List<T> source, Comparison<T> comparison)
        {
            var result = new List<T>(source);
            result.Sort(comparison);

            return result;
        }

        public static TResult Using<TDisposable, TResult>(TDisposable disposable, Func<TDisposable, TResult> function)
            where TDisposable : IDisposable
        {
            using (disposable) 
                return function(disposable);
        }

        public static TResult Using<TDisposable, TResult>(Func<TDisposable> disposableFactory, Func<TDisposable, TResult> function)
            where TDisposable : IDisposable
        {
            using var disposable = disposableFactory.Invoke();
            return function(disposable);
        }
    }
}
