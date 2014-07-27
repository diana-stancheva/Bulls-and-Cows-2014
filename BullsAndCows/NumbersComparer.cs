// <copyright file="NumbersComparer.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace BullsAndCows
{
    using System;
    using System.Linq;

    public class NumbersComparer
    {
        private const int NumberOfDigits = 4;
        private int originalNumber;
        private int guessedNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersComparer"/> class
        /// </summary>
        /// <param name="originalNumber">secret number</param>
        /// <param name="guessedNumber">guess number</param>
        public NumbersComparer(int originalNumber, int guessedNumber)
        {
            this.OriginalNumber = originalNumber;
            this.GuessedNumber = guessedNumber;
        }

        /// <summary>
        /// Gets or sets secret number
        /// </summary>
        private int OriginalNumber
        {
            get
            {
                return this.originalNumber;
            }

            set
            {
                if ((value < 1000) || (9999 < value))
                {
                    throw new ArgumentOutOfRangeException("Number must be between 1000 and 9999");
                }

                this.originalNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets guess number
        /// </summary>
        private int GuessedNumber
        {
            get
            {
                return this.guessedNumber;
            }

            set
            {
                if ((value < 1000) || (9999 < value))
                {
                    throw new ArgumentOutOfRangeException("Number must be between 1000 and 9999");
                }

                this.guessedNumber = value;
            }
        }

        /// <summary>
        /// Gets numbers of cows in the guess number
        /// </summary>
        /// <returns>number of cows</returns>
        public int GetNumberOfCows()
        {
            int cows = 0;
            string originalNumberStr = this.OriginalNumber.ToString();
            string guessedNumberStr = this.GuessedNumber.ToString();

            for (int i = 0; i < NumberOfDigits; i++)
            {
                ////check all digits EXCEPT the current (which, if equal, would make a bull)
                for (int j = 0; j < NumberOfDigits; j++)
                {
                    if (j != i)
                    {
                        if (originalNumberStr[i] == guessedNumberStr[j])
                        {
                            cows++;
                            break;
                        }
                    }
                  
                }
            }

            return cows;
        }

        /// <summary>
        /// Gets numbers of bulls in the guess number
        /// </summary>
        /// <returns>number of cows</returns>
        public int GetNumberOfBulls()
        {
            int bulls = 0;
            string originalNumberStr = this.OriginalNumber.ToString();
            string guessedNumberStr = this.GuessedNumber.ToString();

            for (int i = 0; i < NumberOfDigits; i++)
            {
                if (originalNumberStr[i] == guessedNumberStr[i])
                {
                    bulls++;
                }
            }

            return bulls;
        }
    }
}
