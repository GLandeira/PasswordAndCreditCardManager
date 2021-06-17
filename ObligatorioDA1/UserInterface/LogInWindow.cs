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
using Domain.PasswordEncryptor;

namespace UserInterface
{
    public partial class LogInWindow : Form
    {
        private const string WRONG_CREDENTIALS = "Incorrect Username or Password.";
        private const string USER_CREATED_SUCCESS = "User {0} created successfully!";
        private const string PASSWORD_MODIFY_FAILURE = "Password and confirmation do not match.";

        private bool _loggedIn;
        private EncryptorIndirection _encryption;

        public LogInWindow()
        {
            InitializeComponent();
            _encryption = new EncryptorIndirection(new EffortlessEncryptionWrapper());
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtbxSignUpUsername.Text;
            string password = txtbxSignUpPassword.Text;
            string passwordConfirm = txtbxConfirmPassword.Text;

            if(password == passwordConfirm)
            {
                TryToAddUser(username, password);
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
            User userToLogInWith = UserManager.Instance.GetUser(username);
            _encryption.UserMainPasswordDecryption(userToLogInWith);

            _encryption.GenerateDecryptedUsersList(UserManager.Instance.Users);
            if (UserManager.Instance.LogIn(userToLogInWith, password))
            {
                _loggedIn = true;
                _encryption.GenerateEncryptedUsersList(UserManager.Instance.Users);
                Close();
            }
            else
            {
                _encryption.GenerateEncryptedUsersList(UserManager.Instance.Users);
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
            User newUser = new User(username, password);
            
            try
            {
                Verifier.VerifyUser(newUser);
                _encryption.UserMainPasswordEncryption(newUser);
                UserManager.Instance.AddUser(newUser);
                txtbxSignUpUsername.Text = "";
                txtbxSignUpPassword.Text = "";
                txtbxConfirmPassword.Text = "";

                MessageBox.Show(string.Format(USER_CREATED_SUCCESS, username), "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception me)
            {
                MessageBox.Show(me.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
