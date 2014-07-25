// <copyright file="Scoreboard.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contain methods to show and update game scoreboard
    /// </summary>
    public class Scoreboard
    {
        private const int BestScoresCount = 5;
        private const string ScoresFile = "../../scores.txt";
        private const char Delimiter = '!';
        private List<IPlayer> scores = new List<IPlayer>();

        /// <summary>
        /// Gets players list
        /// </summary>
        public List<IPlayer> Scores
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

        /// <summary>
        /// Adds a result to the scoreboard file
        /// </summary>
        /// <param name="attempts">Guess attempts</param>
        public void AddToScoreboard(int attempts, string username)
        {
            WriteScoreInFile(username, attempts, ScoresFile);
        }

        /// <summary>
        /// Shows top players in console
        /// </summary>
        public void ShowScoreboard()
        {
            List<IPlayer> scores = new List<IPlayer>();
            scores = this.ReadScoresFromFile(ScoresFile);
            scores = scores.OrderBy(o => o.Score).ThenBy(o => o.Name).ToList();
            string separator = new String('-', Console.WindowWidth - 1);

            Console.WriteLine("\nScoreboard:");
            Console.WriteLine(separator);
            for (int i = 1; i <= BestScoresCount; i++)
            {
                Console.WriteLine("{0}. {1}", i, scores[i].ToString());
            }

            Console.WriteLine(separator);
        }

        /// <summary>
        /// Save the player's score in the file
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="score">Guess attempts</param>
        /// <param name="file">File path</param>
        private static void WriteScoreInFile(string name, int score, string file)
        {
            StreamWriter sw = File.AppendText(file);

            using (sw)
            {
                sw.WriteLine(name + Delimiter + score);
            }
        }

        /// <summary>
        /// Reads all scores from scores file
        /// </summary>
        /// <param name="file">File path</param>
        /// <returns>List with Players</returns>
        private List<IPlayer> ReadScoresFromFile(string file)
        {
            string currentPlayerName;
            int currentPlayerScore;

            List<IPlayer> listOfScores = new List<IPlayer>();
            StreamReader scores = new StreamReader(file, Encoding.GetEncoding("windows-1251"));

            using (scores)
            {
                string currentLine;
                while ((currentLine = scores.ReadLine()) != null)
                {
                    string[] separatedLine = currentLine.Split(Delimiter);
                    currentPlayerName = separatedLine[0];
                    currentPlayerScore = int.Parse(separatedLine[1]);
                    IPlayer currentPlayer = new Player(currentPlayerName);
                    currentPlayer.Score = currentPlayerScore;
                    listOfScores.Add(currentPlayer);
                }
            }

            return listOfScores;
        }
    }
}