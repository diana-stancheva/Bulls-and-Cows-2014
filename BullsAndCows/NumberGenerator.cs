// <copyright file="NumberGenerator.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
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
    //public class StupidButSecureGenerator: NumberGenerator
    //{
    //    protected override int GenerateNumber(int minNumber, int maxNumber)
    //    {
    //        const int FixedNumber = 1234;
    //        return FixedNumber;
    //    }
    //}
}