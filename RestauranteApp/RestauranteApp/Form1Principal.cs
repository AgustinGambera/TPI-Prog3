namespace RestauranteApp
{
    public partial class Form1Principal : Form
    {

        private ModoEdicionControl modoEdicionControl;
        private ModoPrevisualizacionControl modoPrevisualizacionControl;

        public Form1Principal()
        {

            InitializeComponent();
            this.Text = "Restaurant Builder 1.0"; // Establece el título de la ventana

            // Instanciamiento de los controles de edición y previsualización
            modoEdicionControl = new ModoEdicionControl();
            modoPrevisualizacionControl = new ModoPrevisualizacionControl();

            //
            modoEdicionControl.BackToMainFormRequested += ModoEdicionControl_BackToMainFormRequested;
            this.Controls.Add(modoEdicionControl);

            // Añadir controles al formulario principal (los establece como sus hijos).
            this.Controls.Add(modoEdicionControl);
            this.Controls.Add(modoPrevisualizacionControl);

            // Configurar la visibilidad según el modo
            // Facilmente podemos decidir cuando mostrarlo o no.
            modoEdicionControl.Visible = false;
            modoPrevisualizacionControl.Visible = false;
        }


        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            //Ocultamos todos los controles del main form. (Se superpone sino, con el modo edicion).
            btnModoEdicion.Visible = false;
            btnModoPrevisualizacion.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            pictureBox1.Visible = false;

            this.WindowState = FormWindowState.Maximized;   //Maximizamos :)

            // Mostrar el control de edición y ocultar el de previsualización
            modoEdicionControl.Visible = true;
            modoPrevisualizacionControl.Visible = false;

        }


        private void btnModoPrevisualizacion_Click(object sender, EventArgs e)
        {
            // Mostrar el control de previsualización y ocultar el de edición
            modoEdicionControl.Visible = false;
            modoPrevisualizacionControl.Visible = true;
        }

        private void ModoEdicionControl_BackToMainFormRequested(object sender, EventArgs e)
        {
            //Mostramos todos los controles del main form que estaban ocultos.
            btnModoEdicion.Visible = true;
            btnModoPrevisualizacion.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            pictureBox1.Visible = true;



            // Aquí decides qué hacer cuando el UserControl solicita volver al formulario principal
            modoEdicionControl.Visible = false;
            modoEdicionControl.Hide();                  // Oculta el ModoEdicionControl

            this.WindowState = FormWindowState.Normal;  // Restaura el tamaño original del MainForm

        }

        // Boton "Cargar" para implementar la logica de cargar un disenio por XML
        private void button1_Click(object sender, EventArgs e)
        {
            // Abre el diálogo para seleccionar un archivo XML
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Cargar el diseño desde el archivo XML usando LayoutManager
                //modoEdicionControl.BotonCargar_Click(sender, e);
            }
            
        }
    }
}