using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

using static FunctionalProgrammingBookExercises.Functional;

namespace FunctionalProgrammingBookExercises
{
    public static class Chapter3
    {
        public static Option<TEnum> Parse<TEnum>(string value)
            where TEnum : struct, Enum
        {
            return Enum.TryParse(value, out TEnum result) ? Some(result) : None;
        }

        public static Option<T> LookupFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            try
            {
                var result = source.First(predicate);
                return Some(result);
            }
            catch (InvalidOperationException)
            {
                return None;
            }
        }

        public sealed class Email
        {
            private static readonly Regex Regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");

            private Email(string value) => Value = value;

            private string Value { get; }

            public static implicit operator string(Email email)
                => email?.Value;

            public static Option<Email> Create(string address)
                => Regex.IsMatch(address)
                    ? Some(new Email(address))
                    : None;
        }

        public class AppConfig
        {
            private readonly NameValueCollection source;

            public AppConfig()
                : this(ConfigurationManager.AppSettings)
            {
            }

            public AppConfig(NameValueCollection source)
            {
                this.source = source;
            }

            public Option<T> Get<T>(string name)
            {
                var value = source[name];
                return value == null
                    ? None
                    : Some((T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture));
            }

            public T Get<T>(string name, T defaultValue)
            {
                return Get<T>(name).Match(
                    () => defaultValue,
                    value => value);
            }
        }
    }
}
