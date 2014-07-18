namespace BullsAndCows
{
    using System;
    using System.Text;

    public class Player
    {
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
                if (value.Length < 3 || value.Length > 40)
                {
                    throw new ArgumentOutOfRangeException("The name must be between 3 and 40 symbols");
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
