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
        public class AppConfigGetWithDefaults : Chapter3Tests
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

                var result = sut.Get(key, string.Empty);

                result.Should().Be(value);
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

                var result = sut.Get(key, 0);

                result.Should().Be(value);
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

                var result = sut.Get<DateTime>(key, default);

                result.Should().Be(value);
            }
        }
    }
}
