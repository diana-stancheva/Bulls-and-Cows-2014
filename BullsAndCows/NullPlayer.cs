using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class NullPlayer : IPlayer
    {
        private string name;
        private int score;

        public NullPlayer()
        {
            this.Name = "Unknown Player";
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
    }
}
