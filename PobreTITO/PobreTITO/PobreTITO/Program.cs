namespace PobreTITO
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static Form4 form4 = new Form4();
        public static GestorPobreTITO gestorPobreTITO = new GestorPobreTITO();
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(form4);
        }
    }
}