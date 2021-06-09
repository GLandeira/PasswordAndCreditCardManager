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
using Repository;

namespace UserInterface
{
    public partial class MainWindow : Form
    {

        private const string WELCOME_TEXT_BASE = "Welcome {0}!";
        public MainWindow()
        {
            InitializeComponent();
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
            UserControl categoryController = new CategoryController();
            pnlMain.Controls.Add(categoryController);
        }

        private void btnPasswords_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            UserControl passwordController = new PasswordsController();
            pnlMain.Controls.Add(passwordController);
        }


        private void btnCreditCard_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            UserControl creditCardController = new CreditCardController();
            pnlMain.Controls.Add(creditCardController);
        }
        
        private void btnDataBreaches_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            UserControl dataBreachesController = new DataBreachesController();
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
            Form changePassword = new ChangePasswordModal();
            changePassword.ShowDialog();
        }

        private void ActivateLogInSequence()
        {
            Form logIn = new LogInWindow();
            Hide();
            logIn.ShowDialog();
            Show();

            if(UserManager.Instance.LoggedUser != null)
            {
                lblWelcome.Text = string.Format(WELCOME_TEXT_BASE, UserManager.Instance.LoggedUser.Name);
            }
        }

        private void btnSecurityReport_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            UserControl securityLevelController = new SecurityReportController();
            pnlMain.Controls.Add(securityLevelController);
        }
    }
}
