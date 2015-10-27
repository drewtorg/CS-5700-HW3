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
using PokemonPaint.Commands;

namespace PokemonPaint
{
    public partial class MainForm : Form
    {
        public enum Mode { Selection, Creation, Erase, Move, Shrink, Grow, Duplicate };

        private Pokemon.PokemonType selectedType;
        private ToolTip toolTip;

        public Graphics Graphics { get; set; }
        public Mode CurrentMode { get; set; }
        public Rectangle LastClick { get; set; }
        public Drawing Drawing { get; set; }
        public Pokemon.PokemonType SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                CurrentMode = Mode.Creation;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Graphics = CreateGraphics();
            Drawing = Drawing.Create(Graphics, BackColor);
            Drawing.RefreshDrawing();
            AddToolTips();
        }

        private void AddToolTips()
        {
            toolTip = new ToolTip();
            toolTip.SetToolTip(growBtn, "Click here or press Ctrl + G then click on a pokemon to make it grow");
            toolTip.SetToolTip(shrinkBtn, "Click here or press Ctrl + F then click on a pokemon to make it shrink");
            toolTip.SetToolTip(eraseBtn, "Click here or press Ctrl + E then click on a pokemon to erase it");
            toolTip.SetToolTip(cursorBtn, "Click here or press Ctrl + W then click on a pokemon to select it");
            toolTip.SetToolTip(undoBtn, "Click here or press Ctrl + Z to undo past actions");
            toolTip.SetToolTip(duplicateBtn, "Click here or press Ctrl + D then click on a pokemon to duplicate it");
            toolTip.SetToolTip(moveBtn, "Click here or press Ctrl + X then click on a pokemon to select it\nOnce selected, click somewhere else to move the pokemon to that new location");
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            LastClick = new Rectangle(e.Location, new Size(1, 1));
            if (Drawing.Canvas.IntersectsWith(LastClick))
            {
                switch (CurrentMode)
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
                    case Mode.Duplicate:
                        Drawing.Do(CommandFactory.Create(CommandFactory.CommandType.Duplicate, PokemonFactory.Create(Drawing.PokemonAtRectangle(LastClick))));
                        break;
                }
                Drawing.RefreshDrawing();
            }
        }

        private void cursorBtn_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.Selection;
        }

        private void bulbasaurBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Bulbasaur;
        }

        private void charmanderBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Charmander;
        }

        private void squirtleBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Squirtle;
        }

        private void pikachuBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Pikachu;
        }

        private void slowpokeBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Slowpoke;
        }

        private void diglettBtn_Click(object sender, EventArgs e)
        {
            SelectedType = Pokemon.PokemonType.Diglett;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            Drawing.Undo();
            Drawing.RefreshDrawing();
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.Erase;
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.Move;
        }

        private void shrinkBtn_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.Shrink;
        }

        private void growBtn_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.Grow;
        }

        private void duplicateBtn_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.Duplicate;
        }

        private void exportToPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drawing.SelectedPokemon = null;
            Drawing.RefreshDrawing();
            if (exportFileDialog.ShowDialog() == DialogResult.OK)
            {
                Drawing.ExportImage(DesktopLocation, exportFileDialog.FileName);
                MessageBox.Show("Saved " + exportFileDialog.FileName);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                Drawing.RefreshDrawing();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDrawing();
        }

        private void NewDrawing()
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
            string imageName = imageComboBox.SelectedItem as string;
            Image backImage = GetImage(imageName);
            Drawing = Drawing.Create(Graphics, backImage, imageName);
            Drawing.RefreshDrawing();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch(e.KeyCode)
                {
                    case Keys.G:
                        CurrentMode = Mode.Grow;
                        break;
                    case Keys.F:
                        CurrentMode = Mode.Shrink;
                        break;
                    case Keys.E:
                        CurrentMode = Mode.Erase;
                        break;
                    case Keys.W:
                        CurrentMode = Mode.Selection;
                        break;
                    case Keys.D:
                        CurrentMode = Mode.Duplicate;
                        break;
                    case Keys.X:
                        CurrentMode = Mode.Move;
                        break;
                    case Keys.N:
                        NewDrawing();
                        break;
                    case Keys.Z:
                        Drawing.Undo();
                        Drawing.RefreshDrawing();
                        break;
                    case Keys.Q:
                        Close();
                        break;
                    case Keys.L:
                        LoadDrawing();
                        break;
                    case Keys.S:
                        SaveDrawing();
                        break;

                }
            }
            switch (e.KeyCode)
            {
                case Keys.B:
                    SelectedType = Pokemon.PokemonType.Bulbasaur;
                    break;
                case Keys.S:
                    SelectedType = Pokemon.PokemonType.Squirtle;
                    break;
                case Keys.C:
                    SelectedType = Pokemon.PokemonType.Charmander;
                    break;
                case Keys.P:
                    SelectedType = Pokemon.PokemonType.Pikachu;
                    break;
                case Keys.L:
                    SelectedType = Pokemon.PokemonType.Slowpoke;
                    break;
                case Keys.D:
                    SelectedType = Pokemon.PokemonType.Diglett;
                    break;
            }
        }

        private void SaveDrawing()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                LoaderSaver.WriteToJsonFile<Drawing>(filename, Drawing);
                MessageBox.Show("Saved " + saveFileDialog.FileName);
            }
        }

        private void LoadDrawing()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                Drawing = LoaderSaver.ReadFromJsonFile<Drawing>(filename);
                Drawing.SetGraphics(Graphics);
                int maxKey = Drawing.PokemonList.Max(pokemon => pokemon.Key);
                PokemonFactory.OverrideCount(maxKey + 1);

                if(Drawing.ImageName != null)
                    Drawing.BackgroundImage = GetImage(Drawing.ImageName);
                MessageBox.Show("Loaded " + openFileDialog.FileName);
                Drawing.RefreshDrawing();
            }
        }

        private Image GetImage(string imageName)
        {
            switch (imageName)
            {
                case "palletTown":
                    return Resources.palletTown;
                case "emptyPallet":
                    return Resources.emptyPallet;
                case "oakLab":
                    return Resources.oakLab;
                default:
                    return Resources.palletTown;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDrawing();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDrawing();
        }
    }
}
