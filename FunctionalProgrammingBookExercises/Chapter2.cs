using System;

namespace FunctionalProgrammingBookExercises
{
    public static class Chapter2
    {
        public const decimal HealthyBmiLowerLimit = 18.5m;
        public const decimal HealthyBmiUpperLimit = 25m;

        public enum BmiClassification
        {
            None,
            Underweight,
            Healthy,
            Overweight
        }

        public static void CalculateBmi(Func<decimal> getHeightMethod, Func<decimal> getWeightMethod, Action<BmiClassification> output)
        {
            if (getHeightMethod == null)
            {
                throw new ArgumentNullException(nameof(getHeightMethod));
            }

            if (getWeightMethod == null)
            {
                throw new ArgumentNullException(nameof(getWeightMethod));
            }

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
                var n when n > HealthyBmiLowerLimit && n < HealthyBmiUpperLimit => BmiClassification.Healthy,
                _ => BmiClassification.Overweight
            };

        private static decimal CalculateBmi(decimal height, decimal weight)
        {
            return weight / (height * height);
        }
    }
}
