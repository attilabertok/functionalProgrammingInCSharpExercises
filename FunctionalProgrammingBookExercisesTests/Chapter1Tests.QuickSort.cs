using System;
using System.Collections.Generic;

using FluentAssertions;

using FunctionalProgrammingBookExercises;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter1Tests
    {
        public class QuickSort : Chapter1Tests
        {
            [Fact]
            public void Should_KeepTheOriginalListUnmodified()
            {
                var originalList = new List<int> { 5, 4, 7, 2 };

                var copiedList = new List<int>(originalList);

                originalList.QuickSort();

                originalList.Should().ContainInOrder(copiedList);
            }

            [Fact]
            public void Should_ReturnWithASortedList()
            {
                var originalList = new List<int> { 5, 4, 7, 2 };

                var result = originalList.QuickSort();

                result.Should().BeInAscendingOrder();
            }

            [Fact]
            public void Should_SortCorrectly_When_UsingAComparer()
            {
                var originalList = new List<string> { "alpha", "bravo", "echo", "delta", "charlie" };

                var result = originalList.QuickSort(StringComparer.OrdinalIgnoreCase.Compare);

                result.Should().BeInAscendingOrder();
            }
        }
    }
}
