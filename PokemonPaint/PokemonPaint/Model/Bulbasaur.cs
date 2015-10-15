using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.Properties;

namespace PokemonPaint.Model
{
    public class Bulbasaur : PokemonModel
    {
        private static object myLock = new object();
        private static Bulbasaur instance = null;

        private Bulbasaur()
        {
            Image = new Bitmap(Resources.bulbasaur);
        }

        public static Bulbasaur GetInstance()
        {
            lock(myLock)
            {
                if(instance == null)
                {
                    instance = new Bulbasaur();
                }
            }
            return instance;
        }
    }
}
