﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.Command;

namespace PokemonPaint.View
{
    public class Drawing
    {
        public Dictionary<int, Pokemon> PokemonList { get; set; }
        private Stack<Command.Command> Commands { get; set; }

        public void Do(Command.Command c)
        {
            c.Execute(this);
        }

        public void Undo()
        {
            if (Commands.Count > 0)
                Commands.Pop().Undo(this);
        }
    }
}