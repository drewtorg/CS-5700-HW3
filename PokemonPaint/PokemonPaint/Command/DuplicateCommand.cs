using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using PokemonPaint.View;

namespace PokemonPaint.Command
{
    public class DuplicateCommand : Command
    {
        public const int OFFSET = 10;

        public override void Execute(Drawing drawing)
        {
            if (pokemon != null)
            {
                pokemon.Location = new Point(pokemon.Location.X + OFFSET,
                                             pokemon.Location.Y + OFFSET);
                drawing.PokemonList.Add(pokemon.ID, pokemon);
                base.Execute(drawing);
            }
        }

        protected override void UndoCommand(Drawing drawing)
        {
            drawing.PokemonList.Remove(pokemon.ID);
        }
    }
}
