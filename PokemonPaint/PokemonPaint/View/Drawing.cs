using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using PokemonPaint.Command;

namespace PokemonPaint.View
{
    public class Drawing
    {
        public Dictionary<int, Pokemon> PokemonList { get; set; }
        public Pokemon SelectedPokemon { get; set; }
        public Image BackgroundImage { get; set; }
        public Color BackgroundColor { get; set; }
        public Rectangle Canvas { get; set; }
        
        private Graphics graphics;

        private Drawing(Graphics g, Rectangle canvas, Color backgroundColor)
        {
            graphics = g;
            PokemonList = new Dictionary<int, Pokemon>();
            Canvas = canvas;
            BackgroundColor = backgroundColor;

            RefreshDrawing();
        }

        public static Drawing Create(Graphics g, Color backgroundColor)
        {
            return new Drawing(g, new Rectangle(new Point(64, 27), new Size(627, 349)), backgroundColor);
        }

        public void RefreshDrawing()
        {
            graphics.FillRectangle(new SolidBrush(BackgroundColor), Canvas);
            foreach (Pokemon pokemon in PokemonList.Values)
            {
                graphics.DrawImage(pokemon.Model.Image, pokemon.Rectangle);
            }

            if (SelectedPokemon != null)
            {
                graphics.DrawRectangle(Pens.Black, SelectedPokemon.Rectangle);
                graphics.DrawImage(SelectedPokemon.Model.Image, SelectedPokemon.Rectangle);
            }
        }

        public void Do(Command.Command c)
        {
            c.Execute(this);
        }

        public void Undo()
        {
            Command.Command.Undo(this);
        }
    }
}
