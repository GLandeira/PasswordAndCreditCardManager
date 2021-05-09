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
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Form logIn = new LogInWindow(_userManager);
            logIn.ShowDialog();
        }
    }
}
