namespace BullsAndCows
{
    using System;
    using System.Linq;

    public static class Help
    {
        public static void RevealOneDigit(int originalNumber, string maskedNumber, char maskChar)
        {
            ////notCheated = false;

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