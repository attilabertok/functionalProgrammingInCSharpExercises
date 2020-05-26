using System;

using FluentAssertions;

using FunctionalProgrammingBookExercises;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter1Tests
    {
        public class Negate : Chapter1Tests
        {
            [Fact]
            public void Should_ReturnFalse_When_TheOriginalPredicateReturnsTrue()
            {
                var originalPredicate = new Func<int, bool>(_ => true);

                var negatedPredicate = originalPredicate.Negate();

                negatedPredicate(1).Should().BeFalse();
            }

            [Fact]
            public void Should_ReturnTrue_When_TheOriginalPredicateReturnsFalse()
            {
                var originalPredicate = new Func<int, bool>(_ => false);

                var negatedPredicate = originalPredicate.Negate();

                negatedPredicate(1).Should().BeTrue();
            }
        }
    }
}
