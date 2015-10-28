using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

using PokemonPaint.Commands;

namespace PokemonPaint.View
{
    public class Drawing
    {
        public Dictionary<int, Pokemon> PokemonList { get; set; }
        public Pokemon SelectedPokemon { get; set; }
        public Image BackgroundImage { private get; set; }
        public string ImageName { get; set; }
        public Color BackgroundColor { get; set; }
        public Rectangle Canvas { get; set; }
        
        private Graphics graphics;

        private const int canvasX = 64;
        private const int canvasY = 78;

        private const int canvasWidth = 627;
        private const int canvasHeight = 349;

        public Drawing() { }

        private Drawing(Graphics g, Rectangle canvas, Color backgroundColor, Image backgroundImage = null, string imageName = null)
        {
            graphics = g;
            PokemonList = new Dictionary<int, Pokemon>();
            Canvas = canvas;
            BackgroundColor = backgroundColor;
            BackgroundImage = backgroundImage;
            ImageName = imageName;
            Command.ClearHistory();
        }

        public static Drawing Create(Graphics g, Color backgroundColor)
        {
            return new Drawing(g, new Rectangle(new Point(canvasX, canvasY), new Size(canvasWidth, canvasHeight)), backgroundColor);
        }

        public static Drawing Create(Graphics g, Image backgroundImage, string imageName)
        {
            return new Drawing(g, new Rectangle(new Point(canvasX, canvasY), new Size(canvasWidth, canvasHeight)), Color.White, backgroundImage, imageName);
        }

        public void SetGraphics(Graphics g)
        {
            graphics = g;
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
            using (Bitmap bitmap = new Bitmap(Canvas.Width - 8, Canvas.Height - 40))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Point loc = new Point(desktopLocation.X + Canvas.X + 8, desktopLocation.Y + Canvas.Y + 32);
                    Size size = new Size(Canvas.Width - 8, Canvas.Height - 40);
                    Thread.Sleep(100);
                    g.CopyFromScreen(loc, new Point(0, 0), size);
                }

                bitmap.Save(filename, ImageFormat.Png);
            }
        }

        public void Do(Command c)
        {
            c.Execute(this);
        }

        public void Undo()
        {
            Command.Undo(this);
        }
    }
}
