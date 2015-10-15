using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.Properties;

namespace PokemonPaint.Model
{
    public class Squirtle : PokemonModel
    {
        private static object myLock = new object();
        private static Squirtle instance = null;

        private Squirtle()
        {
            Image = new Bitmap(Resources.squirtle);
        }

        public static Squirtle GetInstance()
        {
            lock(myLock)
            {
                if(instance == null)
                {
                    instance = new Squirtle();
                }
            }
            return instance;
        }
    }
}
