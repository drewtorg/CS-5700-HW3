using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokemonPaint.View;

namespace PokemonPaint.Commands
{
    public class DeleteCommand : Command
    {
        public override void Execute(Drawing drawing)
        {
            if (pokemon != null)
            {
                drawing.PokemonList.Remove(pokemon.ID);
                base.Execute(drawing);
            }
        }

        protected override void UndoCommand(Drawing drawing)
        {
            drawing.PokemonList.Add(pokemon.ID, pokemon);
        }
    }
}
