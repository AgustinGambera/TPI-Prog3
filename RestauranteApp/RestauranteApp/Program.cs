namespace RestauranteApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            /*ESTA PORCION DE CODIGO SIRVE TAMBIEN PARA NO DEPENDER DE UN FORM 1 PARA ENTRAR EN MODO DISE�ADOR O PREVISUALIZACION.
            
              //Mostrar mensaje inicial
            var result = MessageBox.Show("Seleccione el modo:\nS�: Modo Edici�n\nNo: Modo Previsualizaci�n",
                                         "Seleccionar Modo",
                                         MessageBoxButtons.YesNoCancel,
                                         MessageBoxIcon.Question);
            

            // Abrir el formulario correspondiente
            switch (result)
            {
                case DialogResult.Yes:
                    Application.Run(new EditForm());        // LE DA VIDA AL FORM Y LO ABRE XD
                    break;
                case DialogResult.No:
                    Application.Run(new PreviewForm());    // 
                    break;
                case DialogResult.Cancel:
                    // Si el usuario cancela, salimos de la aplicaci�n
                    Application.Exit();
                    break;*/



            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles(); // habilita los estilos visuales para la aplicaci�n de Windows Forms
            Application.SetCompatibleTextRenderingDefault(false); // establece que la aplicaci�n debe usar GDI+ para renderizar texto en lugar de GDI
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1Principal());
        }
    }
}