using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using PokemonPaint.View;

namespace PokemonPaint.Command
{
    public class CommandFactory
    {
        public enum CommandType { Create, Delete, Move, Select, Grow, Shrink, Duplicate };

        private CommandFactory() { }

        public static Command Create(CommandType type, Pokemon pokemon)
        {
            switch (type)
            {
                case CommandType.Create:
                    return new CreateCommand() { pokemon = pokemon };
                case CommandType.Delete:
                    return new DeleteCommand() { pokemon = pokemon };
                case CommandType.Move:
                    return new MoveCommand() { pokemon = pokemon };
                case CommandType.Select:
                    return new SelectCommand() { pokemon = pokemon };
                case CommandType.Shrink:
                    return new ShrinkCommand() { pokemon = pokemon };
                case CommandType.Grow:
                    return new GrowCommand() { pokemon = pokemon };
                case CommandType.Duplicate:
                    return new DuplicateCommand() { pokemon = pokemon };
                default:
                    return null;
            }
        }
    }
}
