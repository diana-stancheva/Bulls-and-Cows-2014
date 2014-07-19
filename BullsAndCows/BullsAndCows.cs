namespace BullsAndCows
{
    using System;
    using System.Linq;

    public class BullsAndCows
    {
        public void Play()
        {
            GameEngine gameEngine = GameEngine.InstanceCreation();

            gameEngine.StartNewGame();
            while (true)
            {
                gameEngine.ReadAction();
            }
        }
    }
}