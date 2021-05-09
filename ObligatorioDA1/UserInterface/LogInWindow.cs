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
using Domain.Exceptions;

namespace UserInterface
{
    public partial class LogInWindow : Form
    {
        private UserManager _userManager;
        private bool _loggedIn;

        public LogInWindow(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
        }

        private void LogInPage_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtbxSignUpUsername.Text;
            string password = txtbxSignUpPassword.Text;
            string passwordConfirm = txtbxConfirmPassword.Text;

            if(password == passwordConfirm)
            {
                User newUser = new User(username, password);

                try
                {
                    _userManager.AddUser(newUser);
                    lblSignUpStatusLabel.Text = newUser.ToString();
                    txtbxSignUpUsername.Text = "";
                    txtbxSignUpPassword.Text = "";
                    txtbxConfirmPassword.Text = "";
                }
                catch(MainPasswordUserException me)
                {
                    lblSignUpStatusLabel.Text = me.Message;
                }
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtbxLogInUsername.Text;
            string password = txtbxLogInPassword.Text;

            if (_userManager.LogIn(username, password))
            {
                _loggedIn = true;
                this.Close();
            }
        }

        private void LogInWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_loggedIn)
            {
                Application.Exit();
            }
        }
    }
}
