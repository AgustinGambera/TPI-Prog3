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
            menuStrip1 = new MenuStrip();
            navegacionToolStripMenuItem = new ToolStripMenuItem();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            edicionToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesMesa).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMesas
            // 
            panelMesas.BackColor = SystemColors.Info;
            panelMesas.BorderStyle = BorderStyle.FixedSingle;
            panelMesas.Location = new Point(12, 50);
            panelMesas.Name = "panelMesas";
            panelMesas.Size = new Size(600, 600);
            panelMesas.TabIndex = 1;
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
            dgvDetallesMesa.Location = new Point(662, 50);
            dgvDetallesMesa.MaximumSize = new Size(1225, 600);
            dgvDetallesMesa.MinimumSize = new Size(853, 600);
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
            dgvDetallesMesa.TabIndex = 2;
            // 
            // btnCargarJSON
            // 
            btnCargarJSON.BackColor = Color.FromArgb(70, 130, 180);
            btnCargarJSON.FlatStyle = FlatStyle.Flat;
            btnCargarJSON.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCargarJSON.ForeColor = Color.White;
            btnCargarJSON.Location = new Point(662, 656);
            btnCargarJSON.Name = "btnCargarJSON";
            btnCargarJSON.Size = new Size(276, 55);
            btnCargarJSON.TabIndex = 4;
            btnCargarJSON.Text = "Cargar JSON";
            btnCargarJSON.UseVisualStyleBackColor = false;
            btnCargarJSON.Click += btnCargarJSON_Click;
            // 
            // btnGuardarJson
            // 
            btnGuardarJson.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardarJson.BackColor = Color.FromArgb(70, 130, 180);
            btnGuardarJson.FlatStyle = FlatStyle.Flat;
            btnGuardarJson.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarJson.ForeColor = Color.White;
            btnGuardarJson.Location = new Point(1063, 656);
            btnGuardarJson.Name = "btnGuardarJson";
            btnGuardarJson.Size = new Size(223, 55);
            btnGuardarJson.TabIndex = 2;
            btnGuardarJson.Text = "Guardar como JSON";
            btnGuardarJson.UseVisualStyleBackColor = false;
            btnGuardarJson.Click += btnGuardarJson_Click;
            // 
            // btnGuardarXML
            // 
            btnGuardarXML.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardarXML.BackColor = Color.FromArgb(70, 130, 180);
            btnGuardarXML.FlatStyle = FlatStyle.Flat;
            btnGuardarXML.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarXML.ForeColor = Color.White;
            btnGuardarXML.Location = new Point(1292, 656);
            btnGuardarXML.Name = "btnGuardarXML";
            btnGuardarXML.Size = new Size(223, 55);
            btnGuardarXML.TabIndex = 3;
            btnGuardarXML.Text = "Guardar como XML";
            btnGuardarXML.UseVisualStyleBackColor = false;
            btnGuardarXML.Click += btnGuardarXML_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(240, 248, 255);
            menuStrip1.Items.AddRange(new ToolStripItem[] { navegacionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1550, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // navegacionToolStripMenuItem
            // 
            navegacionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, edicionToolStripMenuItem });
            navegacionToolStripMenuItem.Name = "navegacionToolStripMenuItem";
            navegacionToolStripMenuItem.Size = new Size(82, 20);
            navegacionToolStripMenuItem.Text = "Navegación";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(180, 22);
            inicioToolStripMenuItem.Text = "Inicio";
            inicioToolStripMenuItem.Click += inicioToolStripMenuItem_Click;
            // 
            // edicionToolStripMenuItem
            // 
            edicionToolStripMenuItem.Name = "edicionToolStripMenuItem";
            edicionToolStripMenuItem.Size = new Size(180, 22);
            edicionToolStripMenuItem.Text = "Edición";
            edicionToolStripMenuItem.Click += edicionToolStripMenuItem_Click;
            // 
            // ModoPrevisualizacionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            Controls.Add(btnGuardarXML);
            Controls.Add(btnGuardarJson);
            Controls.Add(btnCargarJSON);
            Controls.Add(dgvDetallesMesa);
            Controls.Add(panelMesas);
            Controls.Add(menuStrip1);
            Name = "ModoPrevisualizacionControl";
            Size = new Size(1550, 814);
            ((System.ComponentModel.ISupportInitialize)dgvDetallesMesa).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelMesas;
        private DataGridView dgvDetallesMesa;
        private Button btnCargarJSON;
        private Button btnGuardarJson;
        private Button btnGuardarXML;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem navegacionToolStripMenuItem;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem edicionToolStripMenuItem;
    }
}
