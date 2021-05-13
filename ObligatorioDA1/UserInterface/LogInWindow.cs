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
        private const string WRONG_CREDENTIALS = "Incorrect Username or Password.";
        private const string USER_CREATED_SUCCESS = "User {0} created successfully!";
        private const string PASSWORD_MODIFY_FAILURE = "Password and confirmation do not match.";

        private UserManager _userManager;
        private bool _loggedIn;

        public LogInWindow(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtbxSignUpUsername.Text;
            string password = txtbxSignUpPassword.Text;
            string passwordConfirm = txtbxConfirmPassword.Text;

            if(password == passwordConfirm)
            {
                TryToAddUser(password, username);
            }
            else
            {
                MessageBox.Show(PASSWORD_MODIFY_FAILURE, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtbxLogInUsername.Text;
            string password = txtbxLogInPassword.Text;

            if (_userManager.LogIn(username, password))
            {
                _loggedIn = true;
                Close();
            }
            else
            {
                MessageBox.Show(WRONG_CREDENTIALS, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogInWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_loggedIn)
            {
                Application.Exit();
            }
        }

        private void TryToAddUser(string username, string password)
        {
            User newUser = new User(username, password, _userManager);

            try
            {
                _userManager.AddUser(newUser);
                txtbxSignUpUsername.Text = "";
                txtbxSignUpPassword.Text = "";
                txtbxConfirmPassword.Text = "";

                MessageBox.Show(string.Format(USER_CREATED_SUCCESS, username), "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MainPasswordUserException me)
            {
                MessageBox.Show(me.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
