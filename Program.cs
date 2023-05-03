namespace VCLForum
{
    internal static class Program
    {
        public static LoginForm loginForm = new();
        public static RegisterForm registerForm = new();
        public static ForumForm forumForm = new();

        public static User currentUser;
        public static bool moderatorMode = false;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(loginForm);
        }
    }
}