namespace BullsAndCows
{
    using System;
    using System.Linq;

    public class BullsAndCows
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 40;
        
        public void Play()
        {
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();

            IPlayer player = CreatePlayer(playerName);

            GameEngine gameEngine = GameEngine.InstanceCreation(player);

            gameEngine.StartNewGame();
            while (true)
            {
                gameEngine.ReadAction();
            }
        }

        private IPlayer CreatePlayer(string name)
        {
            if (name.Length > NameMinLength || name.Length < NameMaxLength)
            {
                return new Player(name);
            }
            else
            {
                return new NullPlayer();
            }
        }
    }
}