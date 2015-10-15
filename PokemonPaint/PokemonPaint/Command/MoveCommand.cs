using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.View;

namespace PokemonPaint.Command
{
    public class MoveCommand : Command
    {
        private Point oldLocation;
        
        public override void Execute(Drawing drawing)
        {
            oldLocation = drawing.PokemonList[pokemon.ID].Location;
            drawing.PokemonList[pokemon.ID].Location = pokemon.Location;

        }

        protected override void UndoCommand(Drawing drawing)
        {
            drawing.PokemonList[pokemon.ID].Location = oldLocation;
        }
    }
}
