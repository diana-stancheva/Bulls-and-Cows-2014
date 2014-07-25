namespace BullsAndCows
{
    using System;

    public class RandomGenerator : NumberGenerator
    {
        private static readonly Random randomNumberGenerator = new Random();

        protected override int GenerateNumber(int minNumber, int maxNumber)
        { 
            int result;
            do
            {
                result = randomNumberGenerator.Next(minNumber, maxNumber);
            }
            while (!base.IsNumberValid(result));
            return result;
        }
    }
}