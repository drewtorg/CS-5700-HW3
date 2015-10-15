using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonPaint.View;

namespace PokemonPaint.Model
{
    public class PokemonFactory
    {
        private ConcurrentDictionary<Pokemon.PokemonType, PokemonModel> pokemon = null;
        private object myLock = new object();

        public PokemonModel Create(Pokemon.PokemonType type)
        {
            lock(myLock)
            {
                if (pokemon == null)
                {
                    pokemon = new ConcurrentDictionary<Pokemon.PokemonType, PokemonModel>();
                }
            }
            if (pokemon.Keys.Contains(type))
                return pokemon[type].GetInstance();
            else
            {
                pokemon.AddOrUpdate(type, Pokemon.GetInstance());
            }
            return 
        }
    }
}
