// <copyright file="IPlayer.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace BullsAndCows
{
    /// <summary>
    /// Represents IPlayer interface
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets or sets player name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets player score
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wheter the player were used help
        /// </summary>
        bool HasCheated { get; set; }

        /// <summary>
        /// Gets or sets player attempts
        /// </summary>
        int Attempts { get; set; }
    }
}
