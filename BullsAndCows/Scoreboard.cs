namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Scoreboard
    {
        private SortedList<int, string> bestScores = new SortedList<int, string>();

        public SortedList<int, string> BestScores
        {
            get
            {
                return this.bestScores;
            }

            private set
            {
                this.bestScores = value;
            }
        }

        public void AddToScoreboard(int attempts)
        {
            if (this.BestScores.Count < 5 || this.BestScores.ElementAt(4).Key > attempts)
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");

                string username = Console.ReadLine().Trim();

                this.BestScores.Add(attempts, username);

                if (this.BestScores.Count == 6)
                {
                    this.BestScores.RemoveAt(5);
                }

                this.ShowScoreboard();
            }
        }

        public void ShowScoreboard()
        {
            Console.WriteLine("Scoreboard:");

            if (this.BestScores.Count() > 0)
            {
                int i = 1;
                foreach (var item in this.BestScores)
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