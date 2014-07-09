namespace BullsAndCows
{
    using System;
    using System.Linq;

    class BullsAndCowsTest
    {
        static void Main()
        {
            GameEngine game = new GameEngine();
            game.StartNewGame();
            while (game.ReadAction());
        }
    }
}