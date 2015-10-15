using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.Model;

namespace PokemonPaint.View
{
    public static class PokemonFactory
    {
        private static int count = 0;
        public static Pokemon Create(Pokemon.PokemonType type, Point location, Size size)
        {
            return new Pokemon { Location = location, Size = size, Model = PokemonModelFactory.Create(type), ID = count++ };
        }
    }
}
