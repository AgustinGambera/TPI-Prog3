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
            SuspendLayout();
            // 
            // btnModoEdicion
            // 
            btnModoEdicion.Location = new Point(383, 139);
            btnModoEdicion.Name = "btnModoEdicion";
            btnModoEdicion.Size = new Size(114, 35);
            btnModoEdicion.TabIndex = 0;
            btnModoEdicion.Text = "Modo Edicion";
            btnModoEdicion.UseVisualStyleBackColor = true;
            btnModoEdicion.Click += btnModoEdicion_Click;
            // 
            // btnModoPrevisualizacion
            // 
            btnModoPrevisualizacion.Location = new Point(383, 207);
            btnModoPrevisualizacion.Name = "btnModoPrevisualizacion";
            btnModoPrevisualizacion.Size = new Size(100, 29);
            btnModoPrevisualizacion.TabIndex = 1;
            btnModoPrevisualizacion.Text = "Previsualizacion";
            btnModoPrevisualizacion.UseVisualStyleBackColor = true;
            btnModoPrevisualizacion.Click += btnModoPrevisualizacion_Click;
            // 
            // Form1Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnModoPrevisualizacion);
            Controls.Add(btnModoEdicion);
            Name = "Form1Principal";
            Text = "Form1";
            Load += Form1Principal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnModoEdicion;
        private Button btnModoPrevisualizacion;
    }
}
