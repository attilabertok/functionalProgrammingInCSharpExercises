using System;
using System.Collections.Generic;

using FluentAssertions;

using FunctionalProgrammingBookExercises;

using Xunit;

using static FunctionalProgrammingBookExercises.Functional;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter3Tests
    {
        public static class LookupFirst
        {
            public static TheoryData<List<int>, Func<int, bool>, Option<int>> IntegerData => new TheoryData<List<int>, Func<int, bool>, Option<int>>
            {
                {
                    new List<int> { 1, 2, 3 },
                    _ => true,
                    1
                },
                {
                    new List<int> { 1, 2, 3 },
                    value => value % 2 == 0,
                    2
                },
                {
                    new List<int> { 1, 2, 3 },
                    _ => false,
                    None
                },
            };

            public static TheoryData<List<string>, Func<string, bool>, Option<string>> StringData => new TheoryData<List<string>, Func<string, bool>, Option<string>>
            {
                {
                    new List<string> { "abc", "bcd", "cde" },
                    _ => true,
                    "abc"
                },
                {
                    new List<string> { "abc", "bcd", "cde" },
                    value => value.StartsWith('b'),
                    "bcd"
                },
                {
                    new List<string> { "abc", "bcd", "cde" },
                    _ => false,
                    None
                }
            };

            [Theory]
            [MemberData(nameof(IntegerData))]
            public static void Should_ReturnFirstMatchingResult_When_InputIsInteger(List<int> enumerable, Func<int, bool> predicate, Option<int> expectedResult)
            {
                var result = enumerable.LookupFirst(predicate);

                result.Should().Be(expectedResult);
            }

            [Theory]
            [MemberData(nameof(StringData))]
            public static void Should_ReturnFirstMatchingResult_When_InputIsString(List<string> enumerable, Func<string, bool> predicate, Option<string> expectedResult)
            {
                var result = enumerable.LookupFirst(predicate);

                result.Should().Be(expectedResult);
            }
        }
    }
}
