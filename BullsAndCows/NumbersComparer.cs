namespace BullsAndCows
{
    using System;
    using System.Linq;

    public class NumbersComparer
    {
        private const int NumberOfDigits = 4;
        //private const int MinNumber = 1000;
        //private const int MaxNumber = 9999;
        private byte[] originalNumber;
        private byte[] guessedNumber;

        public NumbersComparer(int originalNumber, int guessedNumber)
        {
            this.OriginalNumber = BitConverter.GetBytes(originalNumber);
            this.GuessedNumber = BitConverter.GetBytes(guessedNumber);
        }

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

        public int GetNumberOfCows()
        {
            int cows = 0;

            for (int i = 0; i < NumberOfDigits; i++)
            {
                //check all digits EXCEPT the current (which, if equal, would make a bull)
                for (int j = 0; (j < NumberOfDigits && j != i); j++)
                {
                    if ((this.OriginalNumber[i] == this.GuessedNumber[j]))
                    {
                        cows++;
                        break;
                    }
                }
            }

            return cows;
        }

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
