namespace PokemonPaint
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursorBtn = new System.Windows.Forms.Button();
            this.diglettBtn = new System.Windows.Forms.Button();
            this.slowpokeBtn = new System.Windows.Forms.Button();
            this.pikachuBtn = new System.Windows.Forms.Button();
            this.squirtleBtn = new System.Windows.Forms.Button();
            this.charmanderBtn = new System.Windows.Forms.Button();
            this.bulbasaurBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exportToPNGToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // exportToPNGToolStripMenuItem
            // 
            this.exportToPNGToolStripMenuItem.Name = "exportToPNGToolStripMenuItem";
            this.exportToPNGToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exportToPNGToolStripMenuItem.Text = "Export To PNG";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cursorBtn
            // 
            this.cursorBtn.Image = global::PokemonPaint.Properties.Resources.cursor;
            this.cursorBtn.Location = new System.Drawing.Point(13, 27);
            this.cursorBtn.Name = "cursorBtn";
            this.cursorBtn.Size = new System.Drawing.Size(45, 45);
            this.cursorBtn.TabIndex = 1;
            this.cursorBtn.UseVisualStyleBackColor = true;
            this.cursorBtn.Click += new System.EventHandler(this.cursorBtn_Click);
            // 
            // diglettBtn
            // 
            this.diglettBtn.Image = ((System.Drawing.Image)(resources.GetObject("diglettBtn.Image")));
            this.diglettBtn.Location = new System.Drawing.Point(13, 333);
            this.diglettBtn.Name = "diglettBtn";
            this.diglettBtn.Size = new System.Drawing.Size(45, 45);
            this.diglettBtn.TabIndex = 6;
            this.diglettBtn.UseVisualStyleBackColor = true;
            this.diglettBtn.Click += new System.EventHandler(this.diglettBtn_Click);
            // 
            // slowpokeBtn
            // 
            this.slowpokeBtn.Image = ((System.Drawing.Image)(resources.GetObject("slowpokeBtn.Image")));
            this.slowpokeBtn.Location = new System.Drawing.Point(13, 282);
            this.slowpokeBtn.Name = "slowpokeBtn";
            this.slowpokeBtn.Size = new System.Drawing.Size(45, 45);
            this.slowpokeBtn.TabIndex = 5;
            this.slowpokeBtn.UseVisualStyleBackColor = true;
            this.slowpokeBtn.Click += new System.EventHandler(this.slowpokeBtn_Click);
            // 
            // pikachuBtn
            // 
            this.pikachuBtn.Image = ((System.Drawing.Image)(resources.GetObject("pikachuBtn.Image")));
            this.pikachuBtn.Location = new System.Drawing.Point(13, 231);
            this.pikachuBtn.Name = "pikachuBtn";
            this.pikachuBtn.Size = new System.Drawing.Size(45, 45);
            this.pikachuBtn.TabIndex = 4;
            this.pikachuBtn.UseVisualStyleBackColor = true;
            this.pikachuBtn.Click += new System.EventHandler(this.pikachuBtn_Click);
            // 
            // squirtleBtn
            // 
            this.squirtleBtn.Image = ((System.Drawing.Image)(resources.GetObject("squirtleBtn.Image")));
            this.squirtleBtn.Location = new System.Drawing.Point(13, 180);
            this.squirtleBtn.Name = "squirtleBtn";
            this.squirtleBtn.Size = new System.Drawing.Size(45, 45);
            this.squirtleBtn.TabIndex = 3;
            this.squirtleBtn.UseVisualStyleBackColor = true;
            this.squirtleBtn.Click += new System.EventHandler(this.squirtleBtn_Click);
            // 
            // charmanderBtn
            // 
            this.charmanderBtn.Image = ((System.Drawing.Image)(resources.GetObject("charmanderBtn.Image")));
            this.charmanderBtn.Location = new System.Drawing.Point(13, 129);
            this.charmanderBtn.Name = "charmanderBtn";
            this.charmanderBtn.Size = new System.Drawing.Size(45, 45);
            this.charmanderBtn.TabIndex = 2;
            this.charmanderBtn.UseVisualStyleBackColor = true;
            this.charmanderBtn.Click += new System.EventHandler(this.charmanderBtn_Click);
            // 
            // bulbasaurBtn
            // 
            this.bulbasaurBtn.Image = ((System.Drawing.Image)(resources.GetObject("bulbasaurBtn.Image")));
            this.bulbasaurBtn.Location = new System.Drawing.Point(12, 78);
            this.bulbasaurBtn.Name = "bulbasaurBtn";
            this.bulbasaurBtn.Size = new System.Drawing.Size(45, 45);
            this.bulbasaurBtn.TabIndex = 8;
            this.bulbasaurBtn.UseVisualStyleBackColor = true;
            this.bulbasaurBtn.Click += new System.EventHandler(this.bulbasaurBtn_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(12, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 45);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(13, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 45);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 388);
            this.Controls.Add(this.cursorBtn);
            this.Controls.Add(this.diglettBtn);
            this.Controls.Add(this.slowpokeBtn);
            this.Controls.Add(this.pikachuBtn);
            this.Controls.Add(this.squirtleBtn);
            this.Controls.Add(this.charmanderBtn);
            this.Controls.Add(this.bulbasaurBtn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Pokemon Paint";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToPNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button bulbasaurBtn;
        private System.Windows.Forms.Button charmanderBtn;
        private System.Windows.Forms.Button squirtleBtn;
        private System.Windows.Forms.Button pikachuBtn;
        private System.Windows.Forms.Button slowpokeBtn;
        private System.Windows.Forms.Button diglettBtn;
        private System.Windows.Forms.Button cursorBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

