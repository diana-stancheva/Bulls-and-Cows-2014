namespace BullsAndCows
{
    using System;
    using System.Text;

    public class Player : IPlayer
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 40;

        private string name;
        private int score;

        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The name must be between {0} and {1} symbols", NameMinLength, NameMaxLength));
                }

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

        public override string ToString()
        {
            StringBuilder player = new StringBuilder();
            player.AppendFormat("{0,-10} --> {1, 5}", this.Name, this.Score);

            return player.ToString();
        }
    }
}
