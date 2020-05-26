using FluentAssertions;

using FunctionalProgrammingBookExercises;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter3Tests
    {
        public class EmailType : Chapter3Tests
        {
            [Theory]
            [InlineData("abc@def.gh")]
            [InlineData("abc@def.ghi")]
            [InlineData("abc+tag@def.ghi")]
            public void Should_Accept_When_FormatIsCorrect(string address)
            {
                var email = Chapter3.Email.Create(address);

                var converted = email.Match(() => string.Empty, value => value);

                converted.Should().Be(address);
            }

            [Theory]
            [InlineData("abcdef.ghi")]
            [InlineData("abc@def")]
            public void Should_Reject_When_FormatIsIncorrect(string address)
            {
                var email = Chapter3.Email.Create(address);

                var converted = email.Match(() => string.Empty, value => value);

                converted.Should().Be(string.Empty);
            }
        }
    }
}
