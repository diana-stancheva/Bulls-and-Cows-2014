namespace BullsAndCows
{
    using System;

    public class UserInputGenerator : NumberGenerator
    {
        protected override int GenerateNumber(int minNumber, int maxNumber)
        {
            int number;
            Console.Write("Type in the number: ");
            number = int.Parse(Console.ReadLine());

            return number;
        }
    }
}