using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.View;

namespace PokemonPaint.Command
{
    public class CreateCommand : Command
    {
        public override void Execute(Drawing drawing)
        {

            pokemon.Location = new Point(pokemon.Location.X - pokemon.Size.Width / 2,
                                         pokemon.Location.Y - pokemon.Size.Height / 2);
            drawing.PokemonList.Add(pokemon.ID, pokemon);
            base.Execute(drawing);
        }

        protected override void UndoCommand(Drawing drawing)
        {
            drawing.PokemonList.Remove(pokemon.ID);
        }
    }
}
