﻿namespace BullsAndCows
{
    using System;
    using System.Linq;

    public static class InterfaceMessages
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
        }

        public static void PrintCommandsInstructionsMessage()
        {
            string separator = new String('-', Console.WindowWidth-1);

            Console.WriteLine("\nCommands:");
            Console.WriteLine(separator);
            Console.WriteLine("{0,-10} --> {1,18}", "restart", "Start new game");
            Console.WriteLine("{0,-10} --> {1,20}", "top", "View scroreboard");
            Console.WriteLine("{0,-10} --> {1,8}", "help", "Help");
            Console.WriteLine("{0,-10} --> {1,13}", "exit", "Quit game");
            Console.WriteLine(separator);
        }

        public static void PrintPromptMessage()
        {
            Console.WriteLine("Enter your guess or command: ");
        }

        public static void PrintNotGuessedMessage(int bullsElements, int cowElements)
        {
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bullsElements, cowElements);
        }

        public static void PrintInvalidCommandMessage()
        {
            Console.WriteLine("Invalid command!");
            PrintCommandsInstructionsMessage();
            Console.WriteLine("For next attempt enter a 4-digit number.");
        }

        public static void PrintCongratulationsMessage(int attempts)
        {
            Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", attempts);
        }
    }
}
