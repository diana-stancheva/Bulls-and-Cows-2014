namespace BullsAndCows
{
    using System;
    using System.Linq;

    public static class Help
    {
        public static void Cheat(int number, string ch, Random randomNumber)
        {
            ////notCheated = false;
            if (ch.Contains('X'))
            {
                int i;

                do
                {
                    i = randomNumber.Next(0, 4);
                }
                while (ch[i] != 'X');

                char[] cha = ch.ToCharArray();
                cha[i] = number.ToString()[i];
                ch = new string(cha);
            }

            Console.WriteLine("The number looks like {0}.", ch);
        }
    }
}