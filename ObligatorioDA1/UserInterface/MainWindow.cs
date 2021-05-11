using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace UserInterface
{
    public partial class MainWindow : Form
    {
        private UserManager _userManager;

        private const string WELCOME_TEXT_BASE = "Welcome {0}!";
        public MainWindow()
        {
            InitializeComponent();
            _userManager = new UserManager();

            User mati = new User("matixitam", "1234abcd");
            mati.AddCategory(new Category("Personal"));
            _userManager.AddUser(mati);

            User gastao = new User("GLandeira", "bardo");
            gastao.AddCategory(new Category("Personal"));
            _userManager.AddUser(gastao);

            User sleepz = new User("sleepz", "milia");
            sleepz.AddCategory(new Category("Personal"));
            _userManager.AddUser(sleepz);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ActivateLogInSequence();

            pnlMain.Controls.Clear();
            UserControl passwordController = new LogoController();
            pnlMain.Controls.Add(passwordController);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            UserControl categoryController = new CategoryController(_userManager);
            pnlMain.Controls.Add(categoryController);
        }

        private void btnPasswords_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            UserControl passwordController = new PasswordsController();
            pnlMain.Controls.Add(passwordController);
        }

        private void btnDataBreaches_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            UserControl dataBreachesController = new DataBreachesController(_userManager);
            pnlMain.Controls.Add(dataBreachesController);
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            ActivateLogInSequence();

            pnlMain.Controls.Clear();
            UserControl passwordController = new LogoController();
            pnlMain.Controls.Add(passwordController);
        }

        private void lblChangePassword_Click(object sender, EventArgs e)
        {
            Form changePassword = new ChangePasswordModal(_userManager);
            changePassword.ShowDialog();
        }

        private void ActivateLogInSequence()
        {
            Form logIn = new LogInWindow(_userManager);
            Hide();
            logIn.ShowDialog();
            Show();

            if(_userManager.LoggedUser != null)
            {
                lblWelcome.Text = string.Format(WELCOME_TEXT_BASE, _userManager.LoggedUser.Name);
            }
        }
    }
}
