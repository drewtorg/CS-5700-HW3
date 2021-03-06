﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.Model;

namespace PokemonPaint.View
{
    public class Pokemon
    {
        public enum PokemonType { Bulbasaur, Charmander, Squirtle, Pikachu, Slowpoke, Diglett };

        public int ID { get; set; }
        public PokemonModel Model { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }
        public Rectangle Rectangle { get { return new Rectangle(Location, Size); } }
        public PokemonType Type { get; set; }
    }
}
