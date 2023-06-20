using RemoteMvpLib;

namespace RemoteMVPAdmin
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
            ApplicationConfiguration.Initialize();
            Application.Run(new AdminView());

           
            var client = new RemoteActionAdapter("localhost", 11000);
            var clientController = new AdminPresenter(client);
            clientController.OpenUI(true);
        }




    }
    }
}