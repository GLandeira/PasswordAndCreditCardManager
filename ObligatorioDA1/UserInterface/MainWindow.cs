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
        private User _loggedUser;
        private UserManager _userManager;
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
            Form logIn = new LogInWindow(_userManager);
            logIn.ShowDialog();
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
            UserControl creditCardController = new CreditCardController(_userManager);
            pnlMain.Controls.Add(creditCardController);
        }
    }
}
