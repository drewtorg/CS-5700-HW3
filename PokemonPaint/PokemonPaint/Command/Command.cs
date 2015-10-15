using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokemonPaint.View;

namespace PokemonPaint.Command
{
    public abstract class Command
    {
        public Pokemon pokemon;

        public abstract void Execute(Drawing drawing);
        public abstract void Undo(Drawing drawing);
    }
}
