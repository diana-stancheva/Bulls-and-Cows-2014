namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Scoreboard
    {
        private const int BestScoresCount = 5;
        private const string ScoresFile = "../../scores.txt";
        private const char Delimiter = '!';
        private SortedList<int, string> bestScores = new SortedList<int, string>();
        private List<Player> scores = new List<Player>();

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

        public List<Player> Scores
        {
            get
            {
                return this.scores;
            }

            private set
            {
                this.scores = value;
            }
        }

        public void AddToScoreboard(int attempts)
        {
            Console.WriteLine("Please enter your name for the top scoreboard: ");

            string username = Console.ReadLine().Trim();

            WriteScoreInFile(username, attempts, ScoresFile);
            //if (this.BestScores.Count < 5 || this.BestScores.ElementAt(4).Key > attempts)
            //{
            //    Console.WriteLine("Please enter your name for the top scoreboard: ");
            //    string username = Console.ReadLine().Trim();
            //    this.BestScores.Add(attempts, username);
            //    if (this.BestScores.Count == 6)
            //    {
            //        this.BestScores.RemoveAt(5);
            //    }
            //    this.ShowScoreboard();
            //}
        }

        public void ShowScoreboard()
        {

            List<Player> scores = new List<Player>();
            scores = ReadScoresFromFile(ScoresFile);
            scores = scores.OrderBy(o => o.Score).ThenBy(o => o.Name).ToList();
            string separator = new String('-', Console.WindowWidth - 1);

            Console.WriteLine("\nScoreboard:");
            Console.WriteLine(separator);
            for (int i = 0; i <= BestScoresCount; i++)
            {
                Console.WriteLine("{0}. {1}", i, scores[i].ToString());
            }
            Console.WriteLine(separator);
            //if (this.BestScores.Count() > 0)
            //{
            //    int i = 1;
            //    foreach (var item in this.BestScores)
            //    {
            //        Console.WriteLine("{0}. {1} --> {2} guesses", i, item.Value, item.Key);
            //        i++;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("The scoreboard is empty.");
            //}
        }

        private static void WriteScoreInFile(string name, int score, string file)
        {
            StreamWriter sw = File.AppendText(file);

            using (sw)
            {
                sw.WriteLine(name + Delimiter + score);
            }
        }

        private List<Player> ReadScoresFromFile(string file)
        {
            List<Player> listOfScores = new List<Player>();
            StreamReader scores = new StreamReader(file, Encoding.GetEncoding("windows-1251"));

            using (scores)
            {
                string currentLine;
                while ((currentLine = scores.ReadLine()) != null)
                {
                    string[] separatedLine = currentLine.Split(Delimiter);

                    listOfScores.Add(new Player(separatedLine[0], int.Parse(separatedLine[1])));
                }
            }

            return listOfScores;
        }
    }
}