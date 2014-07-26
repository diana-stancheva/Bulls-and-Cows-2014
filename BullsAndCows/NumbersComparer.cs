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
        ////private const int MinNumber = 1000;
        ////private const int MaxNumber = 9999;
        private byte[] originalNumber;
        private byte[] guessedNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersComparer"/> class
        /// </summary>
        /// <param name="originalNumber">secret number</param>
        /// <param name="guessedNumber">guess number</param>
        public NumbersComparer(int originalNumber, int guessedNumber)
        {
            this.OriginalNumber = BitConverter.GetBytes(originalNumber);
            this.GuessedNumber = BitConverter.GetBytes(guessedNumber);
        }

        /// <summary>
        /// Gets or sets secret number
        /// </summary>
        private byte[] OriginalNumber
        {
            get
            {
                return this.originalNumber;
            }

            set
            {
                if (value.Length != NumberOfDigits)
                {
                    throw new ArgumentOutOfRangeException("Number must be between 1000 and 9999");
                }

                this.originalNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets guess number
        /// </summary>
        private byte[] GuessedNumber
        {
            get
            {
                return this.guessedNumber;
            }

            set
            {
                if (value.Length != NumberOfDigits)
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

            for (int i = 0; i < NumberOfDigits; i++)
            {
                ////check all digits EXCEPT the current (which, if equal, would make a bull)
                for (int j = 0; (j < NumberOfDigits) && (j != i); j++)
                {
                    if (this.OriginalNumber[i] == this.GuessedNumber[j])
                    {
                        cows++;
                        break;
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

            for (int i = 0; i < NumberOfDigits; i++)
            {
                if (this.OriginalNumber[i] == this.GuessedNumber[i])
                {
                    bulls++;
                }
            }

            return bulls;
        }
    }
}
