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
            btnModoEdicion = new Button();
            btnModoPrevisualizacion = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnModoEdicion
            // 
            btnModoEdicion.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic);
            btnModoEdicion.Location = new Point(12, 195);
            btnModoEdicion.Name = "btnModoEdicion";
            btnModoEdicion.Size = new Size(243, 128);
            btnModoEdicion.TabIndex = 0;
            btnModoEdicion.Text = "Modo Edicion";
            btnModoEdicion.UseVisualStyleBackColor = true;
            btnModoEdicion.Click += btnModoEdicion_Click;
            // 
            // btnModoPrevisualizacion
            // 
            btnModoPrevisualizacion.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic);
            btnModoPrevisualizacion.Location = new Point(12, 359);
            btnModoPrevisualizacion.Name = "btnModoPrevisualizacion";
            btnModoPrevisualizacion.Size = new Size(243, 132);
            btnModoPrevisualizacion.TabIndex = 1;
            btnModoPrevisualizacion.Text = "Previsualizacion";
            btnModoPrevisualizacion.UseVisualStyleBackColor = true;
            btnModoPrevisualizacion.Click += btnModoPrevisualizacion_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 40);
            label1.Name = "label1";
            label1.Size = new Size(260, 40);
            label1.TabIndex = 2;
            label1.Text = "Restaurant Builder";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 133);
            label2.Name = "label2";
            label2.Size = new Size(196, 40);
            label2.TabIndex = 3;
            label2.Text = "Elige tu modo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(507, 227);
            label3.Name = "label3";
            label3.Size = new Size(277, 40);
            label3.TabIndex = 4;
            label3.Text = "Logo o Imagen Aqui";
            // 
            // Form1Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 527);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnModoPrevisualizacion);
            Controls.Add(btnModoEdicion);
            Name = "Form1Principal";
            Text = "Restaurant Builder";
            Load += Form1Principal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnModoEdicion;
        private Button btnModoPrevisualizacion;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
