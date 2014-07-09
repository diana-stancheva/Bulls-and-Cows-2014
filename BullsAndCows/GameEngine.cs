namespace BullsAndCows
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class GameEngine
    {
        public Scoreboard scoreboard = new Scoreboard();
        static string ch;
        static readonly Random randomNumber = new Random();
        private int number;
        private bool notCheated;
        private int attempts = 0;

        public void StartNewGame()
        {
            Help.GameInstructions();
            number = 1111;//randomNumber.Next(1000, 10000);
            attempts = 1;
            notCheated = true;
            ch = "XXXX";
        }

        public bool ReadAction()
        {
            Console.WriteLine("Enter your guess or command: ");

            string line = Console.ReadLine().Trim();
            Regex patt = new Regex("[1-9][0-9][0-9][0-9]");

            switch (line)
            {
                case "top":
                    scoreboard.ShowScoreboard();
                    break;
                case "restart":
                    StartNewGame();
                    break;
                case "help":

                    Help.Cheat(number, ch, randomNumber);
                    break;
                case "exit":
                    return false;

                default:
                    if (patt.IsMatch(line))
                    {
                        int guess = int.Parse(line);
                        ProcessGuess(guess);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a 4-digit number or");
                        Console.WriteLine("one of the commands: 'top', 'restart', 'help' or 'exit'.");
                    }
                    break;
            }

            return true;
        }

        public void ProcessWin()
        {
            Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", attempts);

            if (notCheated)
            {
                scoreboard.AddToScoreboard(attempts);
            }

            StartNewGame();
        }

        public void ProcessGuess(int guess)
        {
            if (guess == number)
            {
                ProcessWin();
            }
            else
            {
                string snum = number.ToString(), sguess = guess.ToString();
                bool[] isBull = new bool[4];
                int bulls = 0, cows = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (isBull[i] = snum[i] == sguess[i])
                    {
                        bulls++;
                    }
                }

                int[] digs = new int[10];

                for (int d = 0; d < 10; d++)
                {
                    digs[d] = 0;
                }

                for (int i = 0; i < 4; i++)
                {
                    if (!isBull[i])
                    {
                        digs[snum[i] - '0']++;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (!isBull[i])
                    {
                        if (digs[sguess[i] - '0'] > 0)
                        {
                            cows++;
                            digs[sguess[i] - '0']--;
                        }
                    }
                }

                Console.WriteLine("\nWrong number! Bulls: {0}, Cows: {1}", bulls, cows);
                attempts++;
            }
        }
    }
}
