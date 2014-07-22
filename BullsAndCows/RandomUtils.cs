// <copyright file="RandomUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
namespace BullsAndCows
{
    using System;

    /// <summary>
    /// Contains methods to generate random values
    /// </summary>
    public static class RandomUtils
    {
        private static readonly Random randomNumberGenerator = new Random();

        /// <summary>
        /// Generates random numbers between <paramref name="minNumber"/> and <paramref name="maxNumber"/>
        /// </summary>
        /// <param name="minNumber">Minimal value</param>
        /// <param name="maxNumber">Maximal value</param>
        /// <returns>random number</returns>
        public static int GenerateRandomNumber(int minNumber, int maxNumber)
        {
            var result = randomNumberGenerator.Next(minNumber, maxNumber);
            return result;
        }
    }
}
