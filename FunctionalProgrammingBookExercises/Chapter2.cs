using System;

namespace FunctionalProgrammingBookExercises
{
    public class Chapter2
    {
        public enum BmiClassification
        {
            None,
            Underweight,
            Healthy,
            Overweight
        }

        public const decimal HealthyBmiLowerLimit = 18.5m;
        public const decimal HealthyBmiUpperLimit = 25m;

        public static void CalculateBmi(Func<decimal> getHeightMethod, Func<decimal> getWeightMethod, Action<BmiClassification> output)
        {
            var height = getHeightMethod();
            var weight = getWeightMethod();

            var bmi = CalculateBmi(height, weight);

            var classification = Classify(bmi);

            output(classification);
        }

        private static BmiClassification Classify(in decimal bmi) =>
            bmi switch
            {
                var n when n < HealthyBmiLowerLimit => BmiClassification.Underweight,
                var n when HealthyBmiLowerLimit < n && n < HealthyBmiUpperLimit => BmiClassification.Healthy,
                _ => BmiClassification.Overweight
            };

        private static decimal CalculateBmi(decimal height, decimal weight)
        {
            return weight / (height * height);
        }
    }
}
