using System;
using System.Collections.Generic;

using static FunctionalProgrammingBookExercises.Functional;

namespace FunctionalProgrammingBookExercises
{
    public static class Chapter4
    {
        public static ISet<TResult> Map<TSource, TResult>(this ISet<TSource> source, Func<TSource, TResult> function)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new HashSet<TResult>(source.Count);
            foreach (var item in source)
            {
                result.Add(function(item));
            }

            return result;
        }

        public static IDictionary<TResultKey, TResultValue> Map<TSourceKey, TSourceValue, TResultKey, TResultValue>(
            this IDictionary<TSourceKey, TSourceValue> source,
            Func<KeyValuePair<TSourceKey, TSourceValue>, KeyValuePair<TResultKey, TResultValue>> function)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Dictionary<TResultKey, TResultValue>(source.Count);
            foreach (var item in source)
            {
                var (key, value) = function(item);
                result.Add(key, value);
            }

            return result;
        }

        public static IDictionary<TResultKey, TResultValue> Map<TSourceKey, TSourceValue, TResultKey, TResultValue>(
            this IDictionary<TSourceKey, TSourceValue> source,
            Func<TSourceKey, TResultKey> keyFunction,
            Func<TSourceValue, TResultValue> valueFunction)
        {
            var function = new Func<KeyValuePair<TSourceKey, TSourceValue>, KeyValuePair<TResultKey, TResultValue>>(
                item => new KeyValuePair<TResultKey, TResultValue>(keyFunction(item.Key), valueFunction(item.Value)));

            return source.Map(function);
        }

        public static Option<TResult> Map<TSource, TResult>(this Option<TSource> source, Func<TSource, TResult> function)
        {
            return source.Bind(item => Some(function(item)));
        }

        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> function)
        {
            return source.Bind(item => new List<TResult> { function(item) });
        }
    }
}
