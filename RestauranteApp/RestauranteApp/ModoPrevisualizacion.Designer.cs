namespace RestauranteApp
{
    partial class ModoPrevisualizacion
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
            menuStrip1 = new MenuStrip();
            modoToolStripMenuItem = new ToolStripMenuItem();
            previsualizacionToolStripMenuItem = new ToolStripMenuItem();
            edicionToolStripMenuItem = new ToolStripMenuItem();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { modoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // modoToolStripMenuItem
            // 
            modoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { previsualizacionToolStripMenuItem, edicionToolStripMenuItem, inicioToolStripMenuItem });
            modoToolStripMenuItem.Name = "modoToolStripMenuItem";
            modoToolStripMenuItem.Size = new Size(82, 20);
            modoToolStripMenuItem.Text = "Navegacion";
            // 
            // previsualizacionToolStripMenuItem
            // 
            previsualizacionToolStripMenuItem.Name = "previsualizacionToolStripMenuItem";
            previsualizacionToolStripMenuItem.Size = new Size(180, 22);
            previsualizacionToolStripMenuItem.Text = "Previsualizacion";
            // 
            // edicionToolStripMenuItem
            // 
            edicionToolStripMenuItem.Name = "edicionToolStripMenuItem";
            edicionToolStripMenuItem.Size = new Size(180, 22);
            edicionToolStripMenuItem.Text = "Edicion";
            edicionToolStripMenuItem.Click += edicionToolStripMenuItem_Click;
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(180, 22);
            inicioToolStripMenuItem.Text = "Inicio";
            inicioToolStripMenuItem.Click += inicioToolStripMenuItem_Click;
            // 
            // ModoPrevisualizacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ModoPrevisualizacion";
            Text = "Preview";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem modoToolStripMenuItem;
        private ToolStripMenuItem previsualizacionToolStripMenuItem;
        private ToolStripMenuItem edicionToolStripMenuItem;
        private ToolStripMenuItem inicioToolStripMenuItem;
    }
}