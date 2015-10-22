﻿using System;
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
        public enum Mode { Selection, Creation, Erase, Move, Shrink, Grow, Duplicate };

        public Graphics Graphics { get; set; }
        public Mode mode { get; set; }
        public Pokemon.PokemonType SelectedType { get; set; }
        public Rectangle LastClick { get; set; }
        public Drawing Drawing { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Graphics = CreateGraphics();
            Drawing = Drawing.Create(Graphics, BackColor);
            Drawing.RefreshDrawing();
            mode = Mode.Selection;
            SelectedType = Pokemon.PokemonType.Bulbasaur;
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            LastClick = new Rectangle(e.Location, new Size(1, 1));
            if (Drawing.Canvas.IntersectsWith(LastClick))
            {
                switch (mode)
                {
                    case Mode.Move:
                        if(Drawing.SelectedPokemon == null)
                            Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Select, Drawing.PokemonAtRectangle(LastClick)));
                        else
                        {
                            Pokemon selected = PokemonFactory.Copy(Drawing.SelectedPokemon);
                            selected.Location = LastClick.Location;
                            Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Move, selected));
                        }
                        break;
                    case Mode.Erase:
                        Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Delete, Drawing.PokemonAtRectangle(LastClick)));
                        break;
                    case Mode.Creation:
                        Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Create, PokemonFactory.Create(SelectedType, LastClick.Location)));
                        break;
                    case Mode.Selection:
                        Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Select, Drawing.PokemonAtRectangle(LastClick)));
                        break;
                    case Mode.Shrink:
                        Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Shrink, Drawing.PokemonAtRectangle(LastClick)));
                        break;
                    case Mode.Grow:
                        Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Grow, Drawing.PokemonAtRectangle(LastClick)));
                        break;
                }
            }
        }

        private void cursorBtn_Click(object sender, EventArgs e)
        {
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

        private void undoButton_Click(object sender, EventArgs e)
        {
            Drawing.Undo();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //Drawing.RefreshDrawing();
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            mode = Mode.Erase;
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Move;
        }

        private void shrinkBtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Shrink;
        }

        private void growBtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Grow;
        }

        private void duplicateBtn_Click(object sender, EventArgs e)
        {
            Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Duplicate, PokemonFactory.Create(Drawing.PokemonAtRectangle(LastClick))));
        }

        private void exportToPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drawing.SelectedPokemon = null;
            Drawing.RefreshDrawing();
            if (exportFileDialog.ShowDialog() == DialogResult.OK)
            {
                Drawing.ExportImage(DesktopLocation, exportFileDialog.FileName);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                Drawing.RefreshDrawing();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDrawingForm newDialog = new NewDrawingForm();

            if (newDialog.ShowDialog() == DialogResult.OK)
            {
                Drawing = Drawing.Create(Graphics, newDialog.Color);
                Drawing.RefreshDrawing();
            }
        }

        private void imageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image backImage;
            switch (imageComboBox.SelectedIndex)
            {
                case 0:
                    backImage = Resources.palletTown;
                    break;
                case 1:
                    backImage = Resources.emptyPallet;
                    break;
                case 2:
                    backImage = Resources.oakLab;
                    break;
                default:
                    backImage = Resources.palletTown;
                    break;
            }
            Drawing = Drawing.Create(Graphics, backImage);
            Drawing.RefreshDrawing();
        }
    }
}
