﻿// <copyright file="BullsAndCows.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace BullsAndCows
{
    using System;
    using System.Linq;

    /// <summary>
    /// Tests BullsAndCows
    /// </summary>
    public class BullsAndCows
    {
        /// <summary>
        /// The entry point of the program
        /// </summary>
        public static void Main()
        {
            GameEngine gameEngine = GameEngine.Instance;
            gameEngine.Play();
        }
    }
}