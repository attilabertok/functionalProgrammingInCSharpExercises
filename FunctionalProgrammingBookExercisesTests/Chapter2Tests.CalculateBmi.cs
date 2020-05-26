using System;
using System.Text;

using FluentAssertions;

using FunctionalProgrammingBookExercises;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter2Tests
    {
        public class CalculateBmi : Chapter2Tests
        {
            [Theory]
            [InlineData(2, 70, Chapter2.BmiClassification.Underweight)]
            [InlineData(2, 85, Chapter2.BmiClassification.Healthy)]
            [InlineData(2, 100, Chapter2.BmiClassification.Overweight)]
            public void ReturnsCorrectClassification(decimal height, decimal weight, Chapter2.BmiClassification expectedResult)
            {
                var consoleLog = new StringBuilder();
                var bmiClassification = Chapter2.BmiClassification.None;
                decimal GetHeightFake() => height;
                decimal GetWeightFake() => weight;

                void WriteOutputFake(Chapter2.BmiClassification result)
                {
                    bmiClassification = result;
                }

                static Action<Chapter2.BmiClassification> LogConsoleOutput(Action<Chapter2.BmiClassification> result, StringBuilder buffer)
                {
                    buffer.Append(result);
                    return result;
                }

                Chapter2.CalculateBmi(GetHeightFake, GetWeightFake, LogConsoleOutput(WriteOutputFake, consoleLog));

                bmiClassification.Should().Be(expectedResult);
            }
        }
    }
}
