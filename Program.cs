namespace VCLForum
{
    internal static class Program
    {
        public static User currentUser;
        public static bool moderatorMode = false;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(LoginForm.Instance);
        }
    }
}