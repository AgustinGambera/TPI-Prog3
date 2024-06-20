namespace RestauranteApp
{
    public partial class Form1Principal : Form
    {
        public Form1Principal()
        {
            InitializeComponent();
            this.Text = "Restaurant Builder 1.0";
        }

        //El form_load tiene 2 funciones. Mi idea es solo elegir una de ellas. O utilizar la alternativa de la clase Program.cs (ver)
        //Ambas funciones estan siendo invocadas, por lo cual se mostrar�n 2 formas de entrar al ModoEdicion y al ModoPrevisualizacion, uno mediante un formprincipal y otro mediante un messagebox (una ventaja si/no/cancel).
        private void Form1Principal_Load(object sender, EventArgs e)
        {
            MostrarMensajeInicial(); //Muestra un message box de bienvenida y da paso al form1Principal para elegir el modo dise�o o previsualizacion. Ventaja: Hay un Form principal para dar estilo
            MostrarBienvenida(); //Muestra un message box antes del form1principal, permitiendo directamente ir al modo dise�o o preview. Ventaja: Directo al grano
        }

        private void MostrarBienvenida()
        {
            // Mostrar un mensaje de bienvenida al usuario
            MessageBox.Show("Bienvenido a nuestra aplicaci�n de gesti�n de restaurantes.\n" +
                            "Por favor, elija una opci�n para continuar.",
                            "Bienvenida",
                            MessageBoxButtons.OK, //Boton aceptar
                            MessageBoxIcon.Information);
        }

        private void MostrarMensajeInicial()
        {
            var result = MessageBox.Show("Seleccione el modo:\n1: Modo Edici�n\n2: Modo Previsualizaci�n",
                                         "Seleccionar Modo",
                                         MessageBoxButtons.YesNoCancel,
                                         MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    AbrirModoEdicion();
                    break;
                case DialogResult.No:
                    AbrirModoPrevisualizacion();
                    break;
                case DialogResult.Cancel:
                    Application.Exit();
                    break;
            }
        }
        
        private void AbrirModoEdicion() //Abre el formulario de edicion, resultado del switch
        {
            this.Hide(); // Oculta el MainForm
            ModoEdicion editForm = new ModoEdicion();
            editForm.FormClosed += (s, args) => this.Close(); // Cierra el MainForm cuando el EditForm se cierra
            editForm.Show();
        }

        private void AbrirModoPrevisualizacion() //abre el form de preview, tambien resultado del switch
        {
            ModoPrevisualizacion previewForm = new ModoPrevisualizacion();
            //supongo que aqu� faltar�a la opci�n para cerrar el mainform cuando se cierre el previewForm
            previewForm.Show();
        }

        //Estos botones son los del form1Principal. (el main).
        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            // Abrir el modo edici�n cuando el usuario haga clic en el bot�n correspondiente
            Hide();
            ModoEdicion modoEdicion = new ModoEdicion();
            modoEdicion.FormClosed += (s, args) => Show();  // Mostrar el formulario principal al cerrar modo edici�n
            modoEdicion.Show();
        }

        private void btnModoPrevisualizacion_Click(object sender, EventArgs e)
        {
            // Abrir el modo previsualizaci�n cuando el usuario haga clic en el bot�n correspondiente
            Hide();
            ModoPrevisualizacion modoPrevisualizacion = new ModoPrevisualizacion();
            modoPrevisualizacion.FormClosed += (s, args) => Show();  // Mostrar el formulario principal al cerrar modo previsualizaci�n
            modoPrevisualizacion.Show();
        }
    }
}
    

