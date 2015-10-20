using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonPaint.View;

namespace PokemonPaint.Command
{
    public class ShrinkCommand : Command
    {
        protected override void UndoCommand(Drawing drawing)
        {
            throw new NotImplementedException();
        }
    }
}
