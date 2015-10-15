using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.Properties;

namespace PokemonPaint.Model
{
    public class Charmander : PokemonModel
    {
        private static object myLock = new object();
        private static Charmander instance = null;

        private Charmander()
        {
            Image = new Bitmap(Resources.charmander);
        }

        public static Charmander GetInstance()
        {
            lock(myLock)
            {
                if(instance == null)
                {
                    instance = new Charmander();
                }
            }
            return instance;
        }
    }
}
