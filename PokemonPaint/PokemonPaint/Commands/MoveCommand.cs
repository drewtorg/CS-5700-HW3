using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.View;

namespace PokemonPaint.Commands
{
    public class MoveCommand : Command
    {
        private Point oldLocation;
        
        public override void Execute(Drawing drawing)
        {
            if (pokemon != null)
            {
                pokemon.Location = new Point(pokemon.Location.X - pokemon.Size.Width / 2,
                                             pokemon.Location.Y - pokemon.Size.Height / 2);

                oldLocation = drawing.PokemonList[pokemon.ID].Location;
                drawing.PokemonList[pokemon.ID].Location = pokemon.Location;
                base.Execute(drawing);
            }
        }

        protected override void UndoCommand(Drawing drawing)
        {
            drawing.PokemonList[pokemon.ID].Location = oldLocation;
        }
    }
}
