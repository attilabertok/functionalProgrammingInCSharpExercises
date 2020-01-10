using System;
using System.Collections.Specialized;
using System.Globalization;

using FluentAssertions;
using FunctionalProgrammingBookExercises;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter3Tests
    {
        public class AppConfigGet : Chapter3Tests
        {
            [Theory]
            [InlineData(StringKey, StringValue)]
            [InlineData(InvalidKey, "")]
            public void Should_ReturnValue_When_TypeIsString(string key, string value)
            {
                var input = new NameValueCollection
                {
                    { StringKey, StringValue },
                    { IntegerKey, IntegerValue.ToString() },
                    { DateKey, DateValue.ToString(CultureInfo.InvariantCulture) }
                };

                var sut = new Chapter3.AppConfig(input);

                var result = sut.Get<string>(key);

                result.Match(() => string.Empty, some => some).Should().Be(value);
            }

            [Theory]
            [InlineData(IntegerKey, IntegerValue)]
            [InlineData(InvalidKey, 0)]
            public void Should_ReturnValue_When_TypeIsInteger(string key, int value)
            {
                var input = new NameValueCollection
                {
                    { StringKey, StringValue },
                    { IntegerKey, IntegerValue.ToString() },
                    { DateKey, DateValue.ToString(CultureInfo.InvariantCulture) }
                };

                var sut = new Chapter3.AppConfig(input);

                var result = sut.Get<int>(key);

                result.Match(() => 0, some => some).Should().Be(value);
            }

            [Theory]
            [MemberData(nameof(DateTimeData))]
            public void Should_ReturnValue_When_TypeIsDateTime(string key, DateTime value)
            {
                var input = new NameValueCollection
                {
                    { StringKey, StringValue },
                    { IntegerKey, IntegerValue.ToString() },
                    { DateKey, DateValue.ToString(CultureInfo.InvariantCulture) }
                };

                var sut = new Chapter3.AppConfig(input);

                var result = sut.Get<DateTime>(key);

                result.Match(() => default, some => some).Should().Be(value);
            }
        }
    }
}
