using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.Properties;

namespace PokemonPaint.Model
{
    public class Slowpoke : PokemonModel
    {
        private static object myLock = new object();
        private static Slowpoke instance = null;

        private Slowpoke()
        {
            Image = new Bitmap(Resources.slowpoke);
        }

        public static Slowpoke GetInstance()
        {
            lock(myLock)
            {
                if(instance == null)
                {
                    instance = new Slowpoke();
                }
            }
            return instance;
        }
    }
}
