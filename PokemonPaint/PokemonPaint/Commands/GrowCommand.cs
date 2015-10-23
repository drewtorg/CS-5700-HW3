using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using PokemonPaint.View;

namespace PokemonPaint.Commands
{
    public class GrowCommand : Command
    {
        public const int GROWTH_FACTOR = 5;

        private Size oldSize;

        public override void Execute(Drawing drawing)
        {
            if (pokemon != null)
            {
                oldSize = pokemon.Size;
                drawing.PokemonList[pokemon.ID].Size = new Size(pokemon.Size.Width + GROWTH_FACTOR,
                                                                pokemon.Size.Height + GROWTH_FACTOR);
                base.Execute(drawing);
            }
        }

        protected override void UndoCommand(Drawing drawing)
        {
            drawing.PokemonList[pokemon.ID].Size = oldSize;
        }
    }
}
