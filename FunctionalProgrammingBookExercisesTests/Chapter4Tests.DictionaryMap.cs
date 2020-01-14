﻿using System;
using System.Collections.Generic;

using FluentAssertions;

using FunctionalProgrammingBookExercises;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter4Tests
    {
        public class DictionaryMap
        {
            public static TheoryData<Dictionary<int, int>, Func<int, int>, Func<int, int>, Dictionary<int, int>> IntegerDictionary =>
                new TheoryData<Dictionary<int, int>, Func<int, int>, Func<int, int>, Dictionary<int, int>>
                {
                    {
                        new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 } },
                        sourceKey => sourceKey,
                        sourceValue => sourceValue,
                        new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 } }
                    },
                    {
                        new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 } },
                        sourceKey => sourceKey * 2,
                        sourceValue => sourceValue,
                        new Dictionary<int, int> { { 1 * 2, 1 }, { 2 * 2, 2 }, { 3 * 2, 3 } }
                    },
                    {
                        new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 } },
                        sourceKey => sourceKey,
                        sourceValue => sourceValue * 2,
                        new Dictionary<int, int> { { 1, 1 * 2 }, { 2, 2 * 2 }, { 3, 3 * 2 } }
                    },
                    {
                        new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 } },
                        sourceKey => sourceKey * 2,
                        sourceValue => sourceValue * 2,
                        new Dictionary<int, int> { { 1 * 2, 1 * 2 }, { 2 * 2, 2 * 2 }, { 3 * 2, 3 * 2 } }
                    }
                };

            [Theory]
            [MemberData(nameof(IntegerDictionary))]
            public void Should_MapAsExpected_When_FunctionLeavesBothTypesIntact(Dictionary<int, int> source, Func<int, int> keyMap, Func<int, int> valueMap, Dictionary<int, int> expectedResult)
            {
                var result = source.Map(keyMap, valueMap);

                result.Should().BeEquivalentTo(expectedResult);
            }

            [Fact]
            public void Should_MapAsExpected_When_FunctionChangesKeyType()
            {
                var originalSet = new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 } };
                var expectedResult = new Dictionary<string, int> { { 1.ToString(), 1 }, { 2.ToString(), 2 }, { 3.ToString(), 3 } };

                var result = originalSet.Map(k => k.ToString(), v => v);

                result.Should().BeEquivalentTo(expectedResult);
            }

            [Fact]
            public void Should_MapAsExpected_When_FunctionChangesValueType()
            {
                var originalSet = new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 } };
                var expectedResult = new Dictionary<int, string> { { 1, 1.ToString() }, { 2, 2.ToString() }, { 3, 3.ToString() } };

                var result = originalSet.Map(k => k, v => v.ToString());

                result.Should().BeEquivalentTo(expectedResult);
            }

            [Fact]
            public void Should_MapAsExpected_When_FunctionChangesBothTypes()
            {
                var originalSet = new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 } };
                var expectedResult = new Dictionary<string, string> { { 1.ToString(), 1.ToString() }, { 2.ToString(), 2.ToString() }, { 3.ToString(), 3.ToString() } };

                var result = originalSet.Map(k => k.ToString(), v => v.ToString());

                result.Should().BeEquivalentTo(expectedResult);
            }
        }
    }
}
