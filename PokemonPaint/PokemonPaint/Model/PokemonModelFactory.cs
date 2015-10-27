using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonPaint.View;

namespace PokemonPaint.Model
{
    public static class PokemonModelFactory
    {
        private static Dictionary<Pokemon.PokemonType, PokemonModel> pokemon = null;
        private static object myLock = new object();

        public static PokemonModel Create(Pokemon.PokemonType type)
        {
            lock(myLock)
            {
                if (pokemon == null)
                {
                    pokemon = new Dictionary<Pokemon.PokemonType, PokemonModel>();
                }
            }

            if (pokemon.Keys.Contains(type))
                return pokemon[type];

            pokemon.Add(type, CreateModel(type));
            return pokemon[type];
        }

        private static PokemonModel CreateModel(Pokemon.PokemonType type)
        {
            switch (type)
            {
                case Pokemon.PokemonType.Bulbasaur:
                    return Bulbasaur.GetInstance();

                case Pokemon.PokemonType.Charmander:
                    return Charmander.GetInstance();

                case Pokemon.PokemonType.Squirtle:
                    return Squirtle.GetInstance();

                case Pokemon.PokemonType.Pikachu:
                    return Pikachu.GetInstance();

                case Pokemon.PokemonType.Slowpoke:
                    return Slowpoke.GetInstance();

                case Pokemon.PokemonType.Diglett:
                    return Diglett.GetInstance();

                default:
                    return null;
            }
        }
    }
}
