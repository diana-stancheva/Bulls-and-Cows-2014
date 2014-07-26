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
    public sealed class GameEngine
    {
        private const int DigitsCount = 4;
        private const char MaskChar = 'X';
        private const int MinNumber = 1000;
        private const int MaxNumber = 10000;

        /// <summary>
        /// Default instance of the <see cref="GameEngine"/> class
        /// </summary>
        private static readonly GameEngine instance = new GameEngine();

        private readonly Scoreboard scoreboard = new Scoreboard();

        /// <summary>
        /// Prevents a default instance of the <see cref="GameEngine"/> class from being created
        /// </summary>
        private GameEngine()
        {
        }

        /// <summary>
        /// Gets default instance of the <see cref="GameEngine"/> class
        /// </summary>
        public static GameEngine Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets masked number
        /// </summary>
        public string MaskedNumber { get; private set; }

        /// <summary>
        /// Gets generated number
        /// </summary>
        public int Number { get; private set; }

        public string Username { get; private set; }

        /// <summary>
        /// Gets or sets current player
        /// </summary>
        public IPlayer CurrentPlayer { get; set; }

        /// <summary>
        /// Starts new game
        /// </summary>
        /// <param name="player">player name</param>
        private void StartNewGame(IPlayer player)
        {
            Console.WriteLine("\nPlease enter your name for the new game: ");
            this.Username = Console.ReadLine().Trim();

            InterfaceMessages.PrintWelcomeMessage();
            InterfaceMessages.PrintCommandsInstructionsMessage();
            this.Initialize(player);
           
        }
        private void Initialize(IPlayer player)
        {
            ////NumberGenerator prefferredGenerator = new StupidButSecureGenerator();
            NumberGenerator prefferredGenerator = new UserInputGenerator();
            ////NumberGenerator prefferredGenerator = new RandomGenerator();
            this.Number = prefferredGenerator.GenerateValidNumber(MinNumber, MaxNumber);
            this.CurrentPlayer = player;
            this.CurrentPlayer.Attempts = 1;
            this.CurrentPlayer.HasCheated = false;
            this.MaskedNumber = new string(MaskChar, DigitsCount);
        }

        public void Play()
        {
            this.StartNewGame(new Player("player Name"));
            while (true)
            {
                ReadAction();
            }


        }
        /// <summary>
        /// Reads command from user input
        /// </summary>
        /// <returns></returns>
        private void ReadAction()
        {
            InterfaceMessages.PrintPromptMessage();

            string line = Console.ReadLine().Trim();

            Command currentCommand = Command.Parse(line);
            this.CommandExecution(currentCommand);
        }

        public void ProcessWin()
        {
            InterfaceMessages.PrintCongratulationsMessage(this.CurrentPlayer.Attempts);

            if (!this.CurrentPlayer.HasCheated)
            {
                this.scoreboard.AddToScoreboard(this.CurrentPlayer.Attempts, this.Username);
            }

            this.StartNewGame(new Player(this.Username));
        }

        /// <summary>
        /// Checks if the guess number is equal to hidden number
        /// </summary>
        /// <param name="guessNumber">user input number</param>
        private void ProcessGuess(int guessNumber)
        {
            if (guessNumber == this.Number)
            {
                this.ProcessWin();
            }
            else
            {
                NumbersComparer comparer = new NumbersComparer(this.Number, guessNumber);
                int bullsCount = comparer.GetNumberOfBulls();
                int cowsCount = comparer.GetNumberOfCows();

                InterfaceMessages.PrintNotGuessedMessage(bullsCount, cowsCount);

                this.CurrentPlayer.Attempts++;
            }
        }

        #region

        /// <summary>
        /// Executes the user command
        /// </summary>
        /// <param name="command">command name</param>
        private void CommandExecution(Command command)
        {
            switch (command.CommandName)
            {
                case "top":
                    this.scoreboard.ShowScoreboard();
                    break;
                case "restart":
                    this.StartNewGame(new Player(this.Username));
                    return;
                case "help":
                    Help.RevealOneDigit(this.Number, this.MaskedNumber, MaskChar);
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                //case "invalid command":
                //    Console.WriteLine("Invalid command!");
                //    break;
                //case "invalid number":
                //    Console.WriteLine("You have entered invalid number!");
                //    break;
                default:
                    if (this.IsValidGuessNumber(command))
                    {
                        int guess = int.Parse(command.CommandName);

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

        /// <summary>
        /// Checks if user input is number or other command not
        /// 
        /// </summary>
        /// <param name="command">command name</param>
        /// <returns>true or false</returns>
        private bool IsValidGuessNumber(Command command)
        {
            Regex guessNumberPattern = new Regex("^(\\d{4})$");

            if (guessNumberPattern.IsMatch(command.CommandName))
            {
                return true;
            }

            return false;
        }
    }
}