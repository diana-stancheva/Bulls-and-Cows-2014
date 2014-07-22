namespace BullsAndCows
{
    using System;

	public abstract class NumberGenerator
	{
		protected abstract int GenerateNumber(int minNumber, int maxNumber);
		
		public bool IsNumberValid (int number)
		{
			string numberAsString = number.ToString();
			bool[] usedDigits = new bool[10];
			for (int i = 0; i < 10; i++)
			{
				usedDigits[i]=false;
			}
				
			for (int i = 0; i < numberAsString.Length; i++)
		 	{
				if (usedDigits[int.Parse(numberAsString[i].ToString())])
				{
					return false;
				}
				else
				{
					usedDigits[int.Parse(numberAsString[i].ToString())] = true;
				}

			}

			return true;
		}

		public int GenerateValidNumber (int minNumber, int maxNumber)
		{
			int result = this.GenerateNumber (minNumber, maxNumber);
			if (!this.IsNumberValid (result))
			{
				throw new ArgumentException("The number is not valid");
			}
			return result;
		}

	}

    public class RandomGenerator: NumberGenerator
    {
        private static Random randomNumberGenerator = new Random();

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

    public class StupidButSecureGenerator: NumberGenerator
    {

        protected override int GenerateNumber(int minNumber, int maxNumber)
        {
            const int FIXED_NUMBER = 1234;
            return FIXED_NUMBER;
        }
    }
	
    public class UserInputGenerator: NumberGenerator
    {

        protected override int GenerateNumber(int minNumber, int maxNumber)
        {
			int number;
			Console.Write("Type in the number: ");
			number = int.Parse(Console.ReadLine());

//			do
//			{
//				Console.Write("Type in the number: ");
//				number = int.Parse(Console.ReadLine());
//				if (!base.isNumberValid(number))
//				{	
//					Console.WriteLine ("The number is not valid!");
//				}
//			} while (!base.isNumberValid(number));
            return number;
        }
    }

}