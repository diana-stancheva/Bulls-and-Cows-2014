namespace BullsAndCows
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Game
    {
        public void Play()
        {
            GameEngine game = new GameEngine();
            game.StartNewGame();
            while (true)
            {
                game.ReadAction();
            }
        }
    }
}