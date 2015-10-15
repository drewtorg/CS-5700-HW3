using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.Properties;

namespace PokemonPaint.Model
{
    public class Diglett : PokemonModel
    {
        private static object myLock = new object();
        private static Diglett instance = null;

        private Diglett()
        {
            Image = new Bitmap(Resources.diglett);
        }

        public static Diglett GetInstance()
        {
            lock(myLock)
            {
                if(instance == null)
                {
                    instance = new Diglett();
                }
            }
            return instance;
        }
    }
}
