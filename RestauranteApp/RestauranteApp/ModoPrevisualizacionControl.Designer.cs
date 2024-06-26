namespace RestauranteApp
{
    partial class ModoPrevisualizacionControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelMesas = new Panel();
            dgvDetallesMesa = new DataGridView();
            btnCargarJSON = new Button();
            btnGuardarJson = new Button();
            btnGuardarXML = new Button();
            botonInicioPreview = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesMesa).BeginInit();
            SuspendLayout();
            // 
            // panelMesas
            // 
            panelMesas.BackColor = SystemColors.Info;
            panelMesas.BorderStyle = BorderStyle.FixedSingle;
            panelMesas.Location = new Point(15, 18);
            panelMesas.Name = "panelMesas";
            panelMesas.Size = new Size(600, 600);
            panelMesas.TabIndex = 4;
            // 
            // dgvDetallesMesa
            // 
            dgvDetallesMesa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetallesMesa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDetallesMesa.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDetallesMesa.BackgroundColor = SystemColors.Info;
            dgvDetallesMesa.BorderStyle = BorderStyle.None;
            dgvDetallesMesa.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.SteelBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDetallesMesa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetallesMesa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.SteelBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.AliceBlue;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDetallesMesa.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDetallesMesa.EnableHeadersVisualStyles = false;
            dgvDetallesMesa.GridColor = SystemColors.GrayText;
            dgvDetallesMesa.Location = new Point(662, 18);
            dgvDetallesMesa.Name = "dgvDetallesMesa";
            dgvDetallesMesa.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.SteelBlue;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.AliceBlue;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvDetallesMesa.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDetallesMesa.Size = new Size(853, 600);
            dgvDetallesMesa.TabIndex = 5;
            // 
            // btnCargarJSON
            // 
            btnCargarJSON.BackColor = Color.FromArgb(70, 130, 180);
            btnCargarJSON.FlatStyle = FlatStyle.Flat;
            btnCargarJSON.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCargarJSON.ForeColor = Color.White;
            btnCargarJSON.Location = new Point(1029, 548);
            btnCargarJSON.Name = "btnCargarJSON";
            btnCargarJSON.Size = new Size(144, 45);
            btnCargarJSON.TabIndex = 6;
            btnCargarJSON.Text = "Cargar JSON";
            btnCargarJSON.UseVisualStyleBackColor = false;
            // 
            // btnGuardarJson
            // 
            btnGuardarJson.BackColor = Color.FromArgb(70, 130, 180);
            btnGuardarJson.FlatStyle = FlatStyle.Flat;
            btnGuardarJson.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarJson.ForeColor = Color.White;
            btnGuardarJson.Location = new Point(662, 624);
            btnGuardarJson.Name = "btnGuardarJson";
            btnGuardarJson.Size = new Size(322, 55);
            btnGuardarJson.TabIndex = 7;
            btnGuardarJson.Text = "Guardar como JSON";
            btnGuardarJson.UseVisualStyleBackColor = false;
            // 
            // btnGuardarXML
            // 
            btnGuardarXML.BackColor = Color.FromArgb(70, 130, 180);
            btnGuardarXML.FlatStyle = FlatStyle.Flat;
            btnGuardarXML.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarXML.ForeColor = Color.White;
            btnGuardarXML.Location = new Point(1182, 624);
            btnGuardarXML.Name = "btnGuardarXML";
            btnGuardarXML.Size = new Size(322, 55);
            btnGuardarXML.TabIndex = 8;
            btnGuardarXML.Text = "Guardar como XML";
            btnGuardarXML.UseVisualStyleBackColor = false;
            // 
            // botonInicioPreview
            // 
            botonInicioPreview.Location = new Point(1019, 636);
            botonInicioPreview.Name = "botonInicioPreview";
            botonInicioPreview.Size = new Size(118, 36);
            botonInicioPreview.TabIndex = 9;
            botonInicioPreview.Text = "Inicio";
            botonInicioPreview.UseVisualStyleBackColor = true;
            botonInicioPreview.Click += botonInicioPreview_Click;
            // 
            // ModoPrevisualizacionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            Controls.Add(botonInicioPreview);
            Controls.Add(btnGuardarXML);
            Controls.Add(btnGuardarJson);
            Controls.Add(btnCargarJSON);
            Controls.Add(dgvDetallesMesa);
            Controls.Add(panelMesas);
            Name = "ModoPrevisualizacionControl";
            Size = new Size(1550, 814);
            ((System.ComponentModel.ISupportInitialize)dgvDetallesMesa).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMesas;
        private DataGridView dgvDetallesMesa;
        private Button btnCargarJSON;
        private Button btnGuardarJson;
        private Button btnGuardarXML;
        private Button botonInicioPreview;
    }
}
