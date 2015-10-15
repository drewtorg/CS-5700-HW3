using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.Properties;

namespace PokemonPaint.Model
{
    public class Pikachu : PokemonModel
    {
        private static object myLock = new object();
        private static Pikachu instance = null;

        private Pikachu()
        {
            Image = new Bitmap(Resources.pikachu);
        }

        public static Pikachu GetInstance()
        {
            lock(myLock)
            {
                if(instance == null)
                {
                    instance = new Pikachu();
                }
            }
            return instance;
        }
    }
}
