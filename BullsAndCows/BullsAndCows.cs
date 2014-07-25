namespace BullsAndCows
{
    using System;
    using System.Linq;

    public class BullsAndCows
    {        
        public void Play()
        {
            GameEngine gameEngine = GameEngine.Instance;

            gameEngine.StartNewGame(new Player());

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