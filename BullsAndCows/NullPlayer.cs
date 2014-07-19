using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class NullPlayer : IPlayer
    {
        private string name = "Unknown Player";
        private int score;

        public NullPlayer()
        {
        }

        public string Name
        {
            get
            {
                return this.name;
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
    }
}
