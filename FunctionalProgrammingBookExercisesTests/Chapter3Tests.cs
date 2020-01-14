using System;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter3Tests
    {
        private const string InvalidKey = "InvalidKey";
        private const string StringKey = "StringKey";
        private const string StringValue = "StringValue";
        private const string IntegerKey = "IntegerKey";
        private const int IntegerValue = 123;
        private const string DateKey = "DateKey";
        private static readonly DateTime DateValue = new DateTime(2020, 02, 02);

        private const string DefaultString = "";
        private const int DefaultInteger = 0;
        private static readonly DateTime DefaultTime = default;

        public static TheoryData<string, DateTime> DateTimeData => new TheoryData<string, DateTime>
        {
            {
                DateKey,
                DateValue
            },
            {
                InvalidKey,
                default
            }
        };
    }
}
