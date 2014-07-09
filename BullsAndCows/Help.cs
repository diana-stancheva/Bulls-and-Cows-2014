namespace BullsAndCows
{
    using System;
    using System.Linq;

    public static class Help
    {
        public static void Cheat(int number, string ch, Random randomNumber)
        {
            //notCheated = false;
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

        public static void GameInstructions()
        {
            string separator = new String('-', Console.WindowWidth);

            Console.WriteLine("Commands: \n");
            Console.WriteLine(separator);
            Console.WriteLine("{0,-10} --> {1,20}", "restart", "Start new game");
            Console.WriteLine("{0,-10} --> {1,22}", "top", "View scroreboard");
            Console.WriteLine("{0,-10} --> {1,10}", "help", "Help");
            Console.WriteLine("{0,-10} --> {1,16}", "exit", "Quit game\n");
            Console.WriteLine(separator);
        }
    }
}