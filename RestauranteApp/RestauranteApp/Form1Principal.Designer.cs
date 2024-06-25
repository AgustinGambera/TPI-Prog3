namespace RestauranteApp
{
    partial class Form1Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1Principal));
            btnModoEdicion = new Button();
            btnModoPrevisualizacion = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnModoEdicion
            // 
            btnModoEdicion.BackColor = SystemColors.Info;
            btnModoEdicion.Cursor = Cursors.Hand;
            btnModoEdicion.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic);
            btnModoEdicion.Location = new Point(12, 224);
            btnModoEdicion.Name = "btnModoEdicion";
            btnModoEdicion.Size = new Size(243, 72);
            btnModoEdicion.TabIndex = 0;
            btnModoEdicion.Text = "Modo Edicion";
            btnModoEdicion.UseVisualStyleBackColor = false;
            btnModoEdicion.Click += btnModoEdicion_Click;
            // 
            // btnModoPrevisualizacion
            // 
            btnModoPrevisualizacion.BackColor = SystemColors.Info;
            btnModoPrevisualizacion.Cursor = Cursors.Hand;
            btnModoPrevisualizacion.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic);
            btnModoPrevisualizacion.Location = new Point(12, 314);
            btnModoPrevisualizacion.Name = "btnModoPrevisualizacion";
            btnModoPrevisualizacion.Size = new Size(243, 70);
            btnModoPrevisualizacion.TabIndex = 1;
            btnModoPrevisualizacion.Text = "Previsualizacion";
            btnModoPrevisualizacion.UseVisualStyleBackColor = false;
            btnModoPrevisualizacion.Click += btnModoPrevisualizacion_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 18);
            label1.Name = "label1";
            label1.Size = new Size(174, 42);
            label1.TabIndex = 2;
            label1.Text = "Bienvenido!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(33, 76);
            label2.Name = "label2";
            label2.Size = new Size(198, 42);
            label2.TabIndex = 3;
            label2.Text = "Elige tu modo";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(275, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(682, 519);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(80, 132);
            label3.Name = "label3";
            label3.Size = new Size(99, 42);
            label3.TabIndex = 5;
            label3.Text = "↓ ↓ ↓ ↓";
            // 
            // Form1Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(960, 519);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnModoPrevisualizacion);
            Controls.Add(btnModoEdicion);
            Name = "Form1Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Restaurant Builder";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnModoEdicion;
        private Button btnModoPrevisualizacion;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
    }
}
