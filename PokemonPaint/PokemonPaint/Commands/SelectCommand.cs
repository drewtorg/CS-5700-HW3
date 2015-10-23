using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.View;

namespace PokemonPaint.Commands
{
    public class SelectCommand : Command
    {
        Pokemon oldPokemon = null;

        public override void Execute(Drawing drawing)
        {
            oldPokemon = drawing.SelectedPokemon;
            if (pokemon != null)
            {
                drawing.SelectedPokemon = drawing.PokemonList[pokemon.ID];
                base.Execute(drawing);
            }
            else
                drawing.SelectedPokemon = null;
        }

        protected override void UndoCommand(Drawing drawing)
        {
            drawing.SelectedPokemon = oldPokemon;
        }
    }
}
