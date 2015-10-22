using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

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

        private Drawing(Graphics g, Rectangle canvas, Color backgroundColor, Image backgroundImage = null)
        {
            graphics = g;
            PokemonList = new Dictionary<int, Pokemon>();
            Canvas = canvas;
            BackgroundColor = backgroundColor;
            BackgroundImage = backgroundImage;
            Command.Command.history.Clear();
        }

        public static Drawing Create(Graphics g, Color backgroundColor)
        {
            return new Drawing(g, new Rectangle(new Point(64, 78), new Size(627, 349)), backgroundColor);
        }

        public static Drawing Create(Graphics g, Image backgroundImage)
        {
            return new Drawing(g, new Rectangle(new Point(64, 78), new Size(627, 349)), Color.White, backgroundImage);
        }

        public Pokemon PokemonAtRectangle(Rectangle loc)
        {
            foreach (Pokemon pokemon in PokemonList.Values)
            {
                if (pokemon.Rectangle.IntersectsWith(loc))
                {
                    return pokemon;
                }
            }
            return null;
        }

        public void RefreshDrawing()
        {
            RefreshBackground();
            RefreshAllPokemon();
            RefreshSelectedPokemon();
        }

        private void RefreshSelectedPokemon()
        {
            if (SelectedPokemon != null)
            {
                graphics.DrawRectangle(Pens.Black, SelectedPokemon.Rectangle);
                graphics.DrawImage(SelectedPokemon.Model.Image, SelectedPokemon.Rectangle);
            }
        }

        private void RefreshAllPokemon()
        {
            foreach (Pokemon pokemon in PokemonList.Values)
            {
                graphics.DrawImage(pokemon.Model.Image, pokemon.Rectangle);
            }
        }

        private void RefreshBackground()
        {
            if (BackgroundImage == null)
                graphics.FillRectangle(new SolidBrush(BackgroundColor), Canvas);
            else
                graphics.DrawImage(BackgroundImage, Canvas);
        }

        public void ExportImage(Point desktopLocation, string filename)
        {
            using (Bitmap bitmap = new Bitmap(Canvas.Width, Canvas.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Point loc = new Point(desktopLocation.X + Canvas.X + 1, desktopLocation.Y + Canvas.Y + 24);
                    Size size = new Size(Canvas.Width - 1, Canvas.Height - 32);
                    g.CopyFromScreen(loc, new Point(0, 0), size);
                }

                bitmap.Save(filename, ImageFormat.Png);
            }
        }

        public void Do(Command.Command c)
        {
            c.Execute(this);
            RefreshDrawing();
        }

        public void Undo()
        {
            Command.Command.Undo(this);
            RefreshDrawing();
        }
    }
}
