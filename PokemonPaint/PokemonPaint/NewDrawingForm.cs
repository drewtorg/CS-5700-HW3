using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonPaint
{
    public partial class NewDrawingForm : Form
    {
        public Color Color { get; set; }

        public NewDrawingForm()
        {
            InitializeComponent();
            Color = Color.Azure;
            colorPanel.BackColor = Color;
            Text = "New Image";
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            if (MyDialog.ShowDialog() == DialogResult.OK)
                colorPanel.BackColor = MyDialog.Color;
            Color = MyDialog.Color;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
