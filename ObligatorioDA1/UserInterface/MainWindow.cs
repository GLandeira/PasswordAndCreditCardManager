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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInPage_Load(object sender, EventArgs e)
        {
            UserControl logInPage = new LogIn(_userManager);
            pnlLogIn.Controls.Add(logInPage);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
