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
        private static Size defaultSize = new Size(40, 40);
        public static Pokemon Create(Pokemon.PokemonType type, Point location)
        {
            return new Pokemon { Location = location, Size = defaultSize, Model = PokemonModelFactory.Create(type), ID = count++, Type = type };
        }

        public static Pokemon Create(Pokemon other, bool isCopy = false)
        {
            if(isCopy)
                return new Pokemon { Location = other.Location, Size = other.Size, Model = other.Model, ID = other.ID, Type = other.Type };
            return new Pokemon { Location = other.Location, Size = other.Size, Model = other.Model, ID = count++, Type = other.Type };
        }
    }
}
