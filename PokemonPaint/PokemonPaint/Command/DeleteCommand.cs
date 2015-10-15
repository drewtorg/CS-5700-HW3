using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokemonPaint.View;

namespace PokemonPaint.Command
{
    public class DeleteCommand : Command
    {
        public override void Execute(Drawing drawing)
        {
            drawing.PokemonList.Remove(pokemon.ID);
        }

        protected override void UndoCommand(Drawing drawing)
        {
            drawing.PokemonList.Add(pokemon.ID, pokemon);
        }
    }
}
