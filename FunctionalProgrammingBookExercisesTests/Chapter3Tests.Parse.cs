﻿using FluentAssertions;

using FunctionalProgrammingBookExercises;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter3Tests
    {
        public class Parse : Chapter3Tests
        {
            private const string InvalidValue = "Invalid";

            private enum TestEnum
            {
                TestValue,
                AnotherTestValue
            }

            [Theory]
            [InlineData("NotAnEnumValue", InvalidValue)]
            [InlineData(nameof(TestEnum.TestValue), nameof(TestEnum.TestValue))]
            [InlineData(nameof(TestEnum.AnotherTestValue), nameof(TestEnum.AnotherTestValue))]
            public void Should_ReturnNone_When_InputIsIncorrect(string valueToParse, string expectedResult)
            {
                var result = Chapter3.Parse<TestEnum>(valueToParse);

                var resultString = result.Match(() => InvalidValue, value => value.ToString());

                resultString.Should().Be(expectedResult);
            }
        }
    }
}
