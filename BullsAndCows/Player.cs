namespace BullsAndCows
{
    using System;
    using System.Text;

    public class Player : IPlayer
    {
        private const int InitialScore = 0;
        private const int InitialAttempts = 0;
                
        private string name;
        private int score;

        public Player(string name)
        {
            this.Name = name;
            this.Score = InitialScore;
            this.Attempts = InitialAttempts;
            this.HasCheated = false;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {                
                this.name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        public bool HasCheated { get; set; }

        public int Attempts { get; set; }

        public override string ToString()
        {
            StringBuilder player = new StringBuilder();
            player.AppendFormat("{0,-10} --> {1, 5}", this.Name, this.Score);

            return player.ToString();
        }
    }
}
