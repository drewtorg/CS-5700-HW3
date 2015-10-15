using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokemonPaint.Properties;
using PokemonPaint.View;

namespace PokemonPaint.Model
{
    public abstract class PokemonModel
    {
        public Image Image { get; protected set; }
    }
}
