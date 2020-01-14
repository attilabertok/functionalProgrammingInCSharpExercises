using System.Collections.Generic;

using FluentAssertions;

using Xunit;

using static FunctionalProgrammingBookExercises.Chapter4;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter4Tests
    {
        public class SetMap
        {
            [Fact]
            public void Should_KeepItemsIntact_When_FunctionIsIdentity()
            {
                var originalSet = new HashSet<int> { 1, 2, 3 };

                var result = originalSet.Map(i => i);

                result.Should().BeEquivalentTo(originalSet);
            }

            [Fact]
            public void Should_MapAsExpected_When_FunctionLeavesTypeIntact()
            {
                var originalSet = new HashSet<int> { 1, 2, 3 };
                var expectedResult = new HashSet<int> { 1 * 2, 2 * 2, 3 * 2 };

                var result = originalSet.Map(i => i * 2);

                result.Should().BeEquivalentTo(expectedResult);
            }

            [Fact]
            public void Should_MapAsExpected_When_FunctionChangesType()
            {
                var originalSet = new HashSet<int> { 1, 2, 3 };
                var expectedResult = new HashSet<string> { 1.ToString(), 2.ToString(), 3.ToString() };

                var result = originalSet.Map(i => i.ToString());

                result.Should().BeEquivalentTo(expectedResult);
            }
        }
    }
}
