using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonPaint.Properties;

using PokemonPaint.View;
using PokemonPaint.Command;
using PokemonPaint.Model;

namespace PokemonPaint
{
    public partial class MainForm : Form
    {
        public enum Mode { Selection, Creation };

        public Graphics Graphics { get; set; }
        public Mode mode { get; set; }
        public Pokemon.PokemonType SelectedType { get; set; }
        public Point LastClick { get; set; }
        public Drawing Drawing { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Graphics = CreateGraphics();
            Drawing = Drawing.Create(Graphics, Color.GhostWhite);
            mode = Mode.Selection;
            SelectedType = Pokemon.PokemonType.Bulbasaur;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDrawingForm newDialog = new NewDrawingForm();

            if(newDialog.ShowDialog() == DialogResult.OK)
            {
                Drawing = Drawing.Create(Graphics, newDialog.Color);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (Drawing.Canvas.IntersectsWith(new Rectangle(e.Location, new Size(1, 1))))
            {
                LastClick = e.Location;
                switch (mode)
                {
                    case Mode.Creation:
                        Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Create, PokemonFactory.Create(SelectedType, LastClick)));
                        break;
                    case Mode.Selection:
                        Pokemon selected = null;
                        foreach (Pokemon pokemon in Drawing.PokemonList.Values)
                        {
                            if (pokemon.Rectangle.IntersectsWith(new Rectangle(LastClick, new Size(1, 1))))
                            {
                                selected = pokemon;
                                break;
                            }
                        }
                        //moving a pokemon
                        //if (selected == null && Drawing.SelectedPokemon != null)
                        //{
                        //    selected = Drawing.SelectedPokemon;
                        //    selected.Location = LastClick;
                        //    Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Move, selected));
                        //    break;
                        //}
                        Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Select, selected));
                        break;
                }

                Drawing.RefreshDrawing();
            }
        }

        private void cursorBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Bulbasaur;
            mode = Mode.Selection;
        }

        private void bulbasaurBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Bulbasaur;
            mode = Mode.Creation;
        }

        private void charmanderBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Charmander;
            mode = Mode.Creation;
        }

        private void squirtleBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Squirtle;
            mode = Mode.Creation;
        }

        private void pikachuBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Pikachu;
            mode = Mode.Creation;
        }

        private void slowpokeBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Slowpoke;
            mode = Mode.Creation;
        }

        private void diglettBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Diglett;
            mode = Mode.Creation;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
