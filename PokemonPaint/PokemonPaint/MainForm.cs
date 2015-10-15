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

namespace PokemonPaint
{
    public partial class MainForm : Form
    {
        public enum Mode { Selection, Creation };
        Graphics g;
        List<Image> images = new List<Image>();
        Mode mode = Mode.Selection;

        public MainForm()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
            mode = Mode.Selection;
        }

        private void bulbasaurBtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Creation;
        }

        private void charmanderBtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Creation;
        }

        private void squirtleBtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Creation;
        }

        private void pikachuBtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Creation;
        }

        private void slowpokeBtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Creation;
        }

        private void diglettBtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Creation;
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            images.Add(new Bitmap(Resources.charmander));
            g.DrawImage(images[0], 100, 100);
        }
    }
}
