namespace BullsAndCows
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class GameEngine
    {
        private readonly Scoreboard scoreboard = new Scoreboard();
        private readonly Random randomNumber = new Random();

        public string Ch { get; set; }

        public int Number { get; set; }

        public bool NotCheated { get; set; }

        public int Attempts { get; set; }

        public void StartNewGame()
        {
            InterfaceMessages.PrintWelcomeMessage();
            InterfaceMessages.PrintCommandsInstructionsMessage();
            this.Number = 1111;////randomNumber.Next(1000, 10000);
            this.Attempts = 1;
            this.NotCheated = true;
            this.Ch = "XXXX";
        }

        public bool ReadAction()
        {
            InterfaceMessages.PrintPromptMessage();

            string line = Console.ReadLine().Trim();

            Command currentCommand = Command.Parse(line);
            CommandExecution(currentCommand);
            //Regex patt = new Regex("[1-9][0-9][0-9][0-9]");

            //switch (line)
            //{
            //    case "top":
            //        this.scoreboard.ShowScoreboard();
            //        break;
            //    case "restart":
            //        this.StartNewGame();
            //        break;
            //    case "help":
            //        Help.Cheat(this.Number, this.Ch, this.randomNumber);
            //        break;
            //    case "exit":
            //        ////return false;
            //        Environment.Exit(0);
            //        break;
            //    default:

            //        if (patt.IsMatch(line))
            //        {
            //            int guess = int.Parse(line);
            //            this.ProcessGuess(guess);
            //        }
            //        else
            //        {
            //            InterfaceMessages.PrintInvalidCommandMessage();
            //        }

            //        break;
            //}

            return true;
        }

        public void ProcessWin()
        {
            InterfaceMessages.PrintCongratulationsMessage(this.Attempts);

            if (this.NotCheated)
            {
                this.scoreboard.AddToScoreboard(this.Attempts);
            }

            this.StartNewGame();
        }

        public void ProcessGuess(int guess)
        {
            if (guess == this.Number)
            {
                this.ProcessWin();
            }
            else
            {
                string snum = this.Number.ToString(), sguess = guess.ToString();
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

                InterfaceMessages.PrintNotGuessedMessage(bulls, cows);

                this.Attempts++;
            }
        }
        #region
        private void CommandExecution(Command command)
        {
            switch (command.Name)
            {
                case "top":
                    this.scoreboard.ShowScoreboard();
                    break;
                case "restart":
                    this.StartNewGame();
                    return;
                case "help":
                    Help.Cheat(this.Number, this.Ch, this.randomNumber);
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "invalid command":
                    Console.WriteLine("Invalid command!");
                    break;
                case "invalid number":
                    Console.WriteLine("You have entered invalid number!");
                    break;
                default:
                    if (isValidGuessNumber(command))
                    {
                        int guess = int.Parse(command.Name);

                        this.ProcessGuess(guess);
                    }
                    else
                    {
                        InterfaceMessages.PrintInvalidCommandMessage();
                    }
                    break;
            }
        }
        #endregion

        private bool isValidGuessNumber(Command command)
        {
            Regex guessNumberPattern = new Regex("^(\\d{4})$");

            if (guessNumberPattern.IsMatch(command.Name))
            {
                return true;
            }

            return false;
        }
    }
}