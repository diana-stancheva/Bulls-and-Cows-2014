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


            GameEngine gameEngine = GameEngine.InstanceCreation();

            gameEngine.StartNewGame(new Player("чичу Митку"));
            while (true)
            {
                gameEngine.ReadAction();
            }
        }

//        private IPlayer CreatePlayer(string name)
//        {
//            if (name.Length > NameMinLength || name.Length < NameMaxLength)
//            {
//                return new Player(name);
//            }
//            else
//            {
//                return new NullPlayer();
//            }
//        }
    }
}