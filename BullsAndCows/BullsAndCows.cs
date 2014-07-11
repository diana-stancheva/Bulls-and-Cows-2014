namespace BullsAndCows
{
    using System;
    using System.Linq;

    public class BullsAndCows
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