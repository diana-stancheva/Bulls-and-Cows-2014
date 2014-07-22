// <copyright file="Help.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
namespace BullsAndCows
{
    using System;
    using System.Linq;

    /// <summary>
    /// Contains help methods
    /// </summary>
    public static class Help
    {
        /// <summary>
        /// Shows one digit from the secret number
        /// </summary>
        /// <param name="originalNumber">secret number</param>
        /// <param name="maskedNumber">number in masked string format</param>
        /// <param name="maskChar">Mask char</param>
        public static void RevealOneDigit(int originalNumber, string maskedNumber, char maskChar)
        {
            if (maskedNumber.Contains(maskChar))
            {
                string originalNumberAsString = originalNumber.ToString();
                int numberLength = originalNumberAsString.Length;
                char[] maskedNumberAsCharArray = maskedNumber.ToCharArray();
                int index = RandomUtils.GenerateRandomNumber(0, numberLength);

                do
                {
                    index = RandomUtils.GenerateRandomNumber(0, numberLength);
                }
                while (maskedNumber[index] != maskChar); //ToFix (maybe)

                maskedNumberAsCharArray[index] = originalNumberAsString[index];
                maskedNumber = new string(maskedNumberAsCharArray);
            }

            Console.WriteLine("The number looks like {0}.", maskedNumber);
        }
    }
}