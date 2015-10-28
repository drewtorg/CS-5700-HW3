using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokemonPaint.View;

namespace PokemonPaint.Commands
{
    public abstract class Command
    {
        private static Stack<Command> history = new Stack<Command>();
        public Pokemon pokemon;

        public virtual void Execute(Drawing drawing)
        {
            history.Push(this);
        }

        public static void Undo(Drawing drawing)
        {
            if (history.Count > 0)
                history.Pop().UndoCommand(drawing);
        }

        public static void ClearHistory()
        {
            history.Clear();
        }

        protected abstract void UndoCommand(Drawing drawing);
    }
}
