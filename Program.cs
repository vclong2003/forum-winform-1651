namespace VCLForum
{
    internal static class Program
    {
        public static RegisterForm registerForm;
        public static LoginForm loginForm;
        public static ForumForm forumForm;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            registerForm = new RegisterForm();
            loginForm = new LoginForm();
            forumForm = new ForumForm();

            Application.Run(loginForm);
        }
    }
}