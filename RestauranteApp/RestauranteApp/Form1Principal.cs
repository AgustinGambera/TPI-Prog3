namespace RestauranteApp
{
    public partial class Form1Principal : Form
    {
        private ModoEdicionControl modoEdicionControl;
        private ModoPrevisualizacionControl modoPrevisualizacionControl;

        public Form1Principal()
        {
            InitializeComponent();
            this.Text = "Restaurant Builder 1.0";

            // Instanciamiento de los controles de edición y previsualización
            modoEdicionControl = new ModoEdicionControl();
            modoPrevisualizacionControl = new ModoPrevisualizacionControl();
            modoPrevisualizacionControl.Dock = DockStyle.Fill;

            //Botones para volver al form principal.
            modoEdicionControl.BackToMainFormRequested += ModoEdicionControl_BackToMainFormRequested;
            modoPrevisualizacionControl.BackToMainFormRequested += ModoPrevisualizacionControl_BackToMainFormRequested;
            modoPrevisualizacionControl.BackToEditFormRequested += ModoPrevisualizacionControl_BackToEditFormRequested;
            modoEdicionControl.BackToPreviewFormRequested += ModoEdicionControl_BackToPreviewFormRequested;

            // Añadir controles al formulario principal
            this.Controls.Add(modoEdicionControl);
            this.Controls.Add(modoPrevisualizacionControl);

            // Configurar la visibilidad según el modo
            modoEdicionControl.Visible = false;
            modoPrevisualizacionControl.Visible = false;
        }

        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            // Ocultar todos los controles del main form
            btnModoEdicion.Visible = false;
            btnModoPrevisualizacion.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            pictureBox1.Visible = false;
            btnExit.Visible = false;

            this.WindowState = FormWindowState.Maximized;

            // Mostrar el control de edición y ocultar el de previsualización
            modoEdicionControl.Visible = true;
            modoPrevisualizacionControl.Visible = false;
        }

        private void btnModoPrevisualizacion_Click(object sender, EventArgs e)
        {
            // Ocultar todos los controles del main form
            btnModoEdicion.Visible = false;
            btnModoPrevisualizacion.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            pictureBox1.Visible = false;
            btnExit.Visible = false;

            this.WindowState = FormWindowState.Maximized;

            // Mostrar el control de previsualización y ocultar el de edición
            modoPrevisualizacionControl.Visible = true;
            modoEdicionControl.Visible = false;
        }

        private void ModoEdicionControl_BackToMainFormRequested(object sender, EventArgs e)
        {
            // Mostrar todos los controles del main form que estaban ocultos
            btnModoEdicion.Visible = true;
            btnModoPrevisualizacion.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            pictureBox1.Visible = true;
            btnExit.Visible = true;

            modoEdicionControl.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void ModoPrevisualizacionControl_BackToMainFormRequested(object sender, EventArgs e)
        {
            // Mostrar todos los controles del main form que estaban ocultos
            btnModoEdicion.Visible = true;
            btnModoPrevisualizacion.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            pictureBox1.Visible = true;
            btnExit.Visible = true;

            modoPrevisualizacionControl.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void ModoPrevisualizacionControl_BackToEditFormRequested(object sender, EventArgs e)
        {
            // Mostrar el control de edición y ocultar el de previsualización
            modoEdicionControl.Visible = true;
            modoPrevisualizacionControl.Visible = false;
        }

        private void ModoEdicionControl_BackToPreviewFormRequested(object sender, EventArgs e)
        {
            modoPrevisualizacionControl.Visible = true;
            modoEdicionControl.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
