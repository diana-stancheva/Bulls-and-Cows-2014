namespace BullsAndCows
{
    using System;

    public static class RandomUtils
    {
        private static Random randomNumberGenerator = new Random();

        public static int GenerateRandomNumber(int minNumber, int maxNumber)
        {
            var result = randomNumberGenerator.Next(minNumber, maxNumber);
            return result;
        }
    }
}
