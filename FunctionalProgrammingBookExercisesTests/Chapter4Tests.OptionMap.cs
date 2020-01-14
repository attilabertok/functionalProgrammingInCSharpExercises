using System;

using FluentAssertions;

using FunctionalProgrammingBookExercises;
using Xunit;

using static FunctionalProgrammingBookExercises.Functional;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter4Tests
    {
        public class OptionMap
        {
            public static TheoryData<Option<string>, Func<string, string>, Option<string>> StringOptions => new TheoryData<Option<string>, Func<string, string>, Option<string>>
            {
                { None, i => i, None },
                { Some("abc"), i => i, Some("abc") },
                { None, i => i.ToUpper(), None },
                { Some("abc"), i => i.ToUpper(), Some("abc".ToUpper()) },
            };

            [Theory]
            [MemberData(nameof(StringOptions))]
            public void Should_ReturnTheMappedOption(Option<string> source, Func<string, string>  function, Option<string> expectedResult)
            {
                source.Map(function).Should().Be(expectedResult);
            }
        }
    }
}
