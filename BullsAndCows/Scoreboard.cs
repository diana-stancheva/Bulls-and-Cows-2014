namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Scoreboard
    {
        private static readonly SortedList<int, string> scoreboard = new SortedList<int, string>();

        public void AddToScoreboard(int attempts)
        {
            if (scoreboard.Count < 5 || scoreboard.ElementAt(4).Key > attempts)
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");

                string username = Console.ReadLine().Trim();

                scoreboard.Add(attempts, username);

                if (scoreboard.Count == 6)
                {
                    scoreboard.RemoveAt(5);
                }

                ShowScoreboard();
            }
        }

        public void ShowScoreboard()
        {
            Console.WriteLine("Scoreboard:");

            if (scoreboard.Count() > 0)
            {
                int i = 1;
                foreach (var item in scoreboard)
                {
                    Console.WriteLine("{0}. {1} --> {2} guesses", i, item.Value, item.Key);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The scoreboard is empty.");
            }
        }
    }
}