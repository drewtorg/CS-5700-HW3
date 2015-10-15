using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokemonPaint.View;

namespace PokemonPaint.Command
{
    public class CommandFactory
    {
        public enum CommandType { Create, Delete, Move };

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
                default:
                    return null;
            }
        }
    }
}
