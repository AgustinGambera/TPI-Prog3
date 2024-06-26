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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles(); // habilita los estilos visuales para la aplicación de Windows Forms
            Application.SetCompatibleTextRenderingDefault(false); // establece que la aplicación debe usar GDI+ para renderizar texto en lugar de GDI
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1Principal());
        }
    }
}