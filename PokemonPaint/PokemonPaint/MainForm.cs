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

        Graphics Graphics { get; set; }
        Mode mode { get; set; }
        Pokemon.PokemonType SelectedType { get; set; }
        Point LastClick { get; set; }
        Drawing Drawing { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Graphics = CreateGraphics();
            Drawing = new Drawing(Graphics);
            mode = Mode.Selection;
            SelectedType = Pokemon.PokemonType.Bulbasaur;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDrawingForm newDialog = new NewDrawingForm();

            if(newDialog.ShowDialog() == DialogResult.OK)
            {
                BackColor = newDialog.Color;
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            LastClick = e.Location;
            if (mode == Mode.Creation)
                Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Create, PokemonFactory.Create(SelectedType, LastClick)));

            Drawing.RefreshDrawing();
        }
    }
}
