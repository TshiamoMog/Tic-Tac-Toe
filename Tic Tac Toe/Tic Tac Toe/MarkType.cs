﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// The type of value a cell in the game is currently at
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// The cell hasn't been clicked yet
        /// </summary>
        Open,

        /// <summary>
        /// The cell is an O
        /// </summary>
        Exes,

        /// <summary>
        /// The cell is an X
        /// </summary>
        Oes
    }
}
