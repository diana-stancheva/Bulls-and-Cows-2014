// <copyright file="CommandExecutor.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace BullsAndCows
{
    using System;
    using System.Text.RegularExpressions;

    public static class CommandExecutor
    {
        public static void Execute(Command command)
        {
            switch (command.CommandName)
            {
                case "top":
                    //this.scoreboard.ShowScoreboard();
                    break;
                case "restart":
                    //this.StartNewGame();
                    return;
                case "help":
                    //Help.Cheat(this.Number, this.Ch, this.randomNumber);
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
                        int guess = int.Parse(command.CommandName);

                        //this.ProcessGuess(guess);
                    }
                    else
                    {
                        InterfaceMessages.PrintInvalidCommandMessage();
                    }
                    break;
            }
        }

        public static bool IsValidGuessNumber(Command command)
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
