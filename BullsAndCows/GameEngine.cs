// <copyright file="GameEngine.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
namespace BullsAndCows
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains all engine methods of the game
    /// </summary>
    public class GameEngine
    {		
		private GameEngine() {}

		public static GameEngine instance;

		public static GameEngine InstanceCreation()
		{
		    if (instance == null)
            {
		       instance = new GameEngine();
		    }
		    return instance;
		} 

        private const int DigitsCount = 4;
        private const char MaskChar = 'X';
        private const int MinNumber = 1000;
        private const int MaxNumber = 10000;

        private readonly Scoreboard scoreboard = new Scoreboard();

        public string MaskedNumber { get; private set; }

        public int Number { get; private set; }

        public IPlayer CurrentPlayer { get; set; }

        public void StartNewGame(IPlayer player)
        {
            InterfaceMessages.PrintWelcomeMessage();
            InterfaceMessages.PrintCommandsInstructionsMessage();
			//NumberGenerator prefferredGenerator = new StupidButSecureGenerator();
 			NumberGenerator prefferredGenerator = new UserInputGenerator();
			//NumberGenerator prefferredGenerator = new RandomGenerator();
            this.Number = prefferredGenerator.GenerateValidNumber(MinNumber, MaxNumber);
			this.CurrentPlayer = player;
            this.CurrentPlayer.Attempts = 1;
            this.CurrentPlayer.HasCheated = false;
            this.MaskedNumber = new string(MaskChar, DigitsCount);
        }

        public bool ReadAction()
        {
            InterfaceMessages.PrintPromptMessage();

            string line = Console.ReadLine().Trim();

            Command currentCommand = Command.Parse(line);
            CommandExecution(currentCommand);
            
            return true;
        }

        public void ProcessWin()
        {
            InterfaceMessages.PrintCongratulationsMessage(this.CurrentPlayer.Attempts);

            if (!this.CurrentPlayer.HasCheated)
            {
                this.scoreboard.AddToScoreboard(this.CurrentPlayer.Attempts);
            }

            this.StartNewGame(new Player("чичу Митку"));
        }
                
        public void ProcessGuess(int guess)
        {            
            if (guess == this.Number)
            {
                this.ProcessWin();
            }
            else
            {
                //to all: does this look OK:
                //NumbersComparer comparer = new NumbersComparer(this.Number, guess);
                //int bullsCount = comparer.GetNumberOfBulls();
                //int cowsCount = comparer.GetNumberOfCows();
                //end of suggestion

                //begin: to be removed
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
                //end: to be removed


                InterfaceMessages.PrintNotGuessedMessage(bulls, cows);

                this.CurrentPlayer.Attempts++;
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
                    this.StartNewGame(new Player("чичу Митку"));
                    return;
                case "help":
                    Help.RevealOneDigit(this.Number, this.MaskedNumber, MaskChar);
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
                    if (IsValidGuessNumber(command))
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

        private bool IsValidGuessNumber(Command command)
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