﻿// <copyright file="NullPlayer.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace BullsAndCows
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents the NullPlayer
    /// </summary>
    public class NullPlayer : IPlayer
    {
        private string name;
        private int score;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullPlayer"/> class
        /// </summary>
        public NullPlayer()
        {
            this.Name = "Unknown Player";
        }

        /// <summary>
        /// Gets or sets name of the player
        /// </summary>
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

        /// <summary>
        /// Gets or sets score of the player
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the player were used help
        /// </summary>
        public bool HasCheated { get; set; }

        /// <summary>
        /// Gets or sets guess attempts of the player
        /// </summary>
        public int Attempts { get; set; }

        /// <summary>
        /// Represents the Player information
        /// </summary>
        /// <returns>Player info to string</returns>
        public override string ToString()
        {
            StringBuilder player = new StringBuilder();
            player.AppendFormat("{0,-10} --> {1, 5}", this.Name, this.Score);

            return player.ToString();
        }
    }
}