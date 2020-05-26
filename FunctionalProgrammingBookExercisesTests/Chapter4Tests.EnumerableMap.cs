using System;
using System.Collections.Generic;
using System.Globalization;

using FluentAssertions;

using FunctionalProgrammingBookExercises;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter4Tests
    {
        public class EnumerableMap : Chapter4Tests
        {
            public static TheoryData<IEnumerable<string>, Func<string, string>, IEnumerable<string>> StringOptions => new TheoryData<IEnumerable<string>, Func<string, string>, IEnumerable<string>>
            {
                { new List<string>(), i => i, new List<string>() },
                { new List<string> { "abc", "def", "ghi" }, i => i, new List<string> { "abc", "def", "ghi" } },
                { new List<string>(), i => i.ToUpper(CultureInfo.InvariantCulture), new List<string>() },
                { new List<string> { "abc", "def", "ghi" }, i => i.ToUpper(CultureInfo.InvariantCulture), new List<string> { "abc".ToUpper(CultureInfo.InvariantCulture), "def".ToUpper(CultureInfo.InvariantCulture), "ghi".ToUpper(CultureInfo.InvariantCulture) } },
            };

            [Theory]
            [MemberData(nameof(StringOptions))]
            public void Should_ReturnTheMappedOption(IEnumerable<string> source, Func<string, string> function, IEnumerable<string> expectedResult)
            {
                source.Map(function).Should().BeEquivalentTo(expectedResult);
            }
        }
    }
}
