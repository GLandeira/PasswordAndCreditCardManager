using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Repository;

namespace UserInterface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataAccessDTO dataAccessInterfaces = new DataAccessDTO();
            dataAccessInterfaces.CategoryDataAccess = new CategoryDataAccess();
            dataAccessInterfaces.PasswordDataAccess = new PasswordDataAccess();
            dataAccessInterfaces.UserDataAccess = new UserDataAccess();
            new RepositoryFacade(dataAccessInterfaces);

            new UserManager();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
