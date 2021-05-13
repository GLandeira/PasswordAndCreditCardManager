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
using Domain.PasswordSecurityFlagger;

namespace UserInterface
{
    public partial class SecurityReportController : UserControl
    {
        private const string NO_PASSWORDS_OF_THAT_COLOR = "There are no passwords of that color.";

        private UserManager _userManager;
        private User _currentUser;
        private UserPassword _currentUserPassword;
        public SecurityReportController(UserManager userManager)
        {
            _userManager = userManager;
            _currentUser = _userManager.LoggedUser;
            _currentUserPassword = _currentUser.UserPasswords;
            InitializeComponent();
        }

        private void SecurityReportController_Load(object sender, EventArgs e)
        {
            LoadSecurityCounters();   
        }

        private void btnCheckRed_Click(object sender, EventArgs e)
        {
            LoadCheckForm(SecurityLevelPasswords.RED);
        }

        private void btnCheckOrange_Click(object sender, EventArgs e)
        {
            LoadCheckForm(SecurityLevelPasswords.ORANGE);
        }

        private void btnCheckYellow_Click(object sender, EventArgs e)
        {
            LoadCheckForm(SecurityLevelPasswords.YELLOW);
        }

        private void btnCheckLightGreen_Click(object sender, EventArgs e)
        {
            LoadCheckForm(SecurityLevelPasswords.LIGHT_GREEN);
        }

        private void btnCheckDarkGreen_Click(object sender, EventArgs e)
        {
            LoadCheckForm(SecurityLevelPasswords.DARK_GREEN);
        }

        private void LoadCheckForm(SecurityLevelPasswords securityLevel)
        {
            List<Password> passwordsOfSecurityLevel = _currentUserPassword.GetPasswordsWithSecurityLevel(securityLevel);

            if(passwordsOfSecurityLevel.Count <= 0)
            {
                MessageBox.Show(NO_PASSWORDS_OF_THAT_COLOR, "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form checkForm = new CheckSecurityPasswordsModal(_currentUser, passwordsOfSecurityLevel, securityLevel);
            checkForm.ShowDialog();

            LoadSecurityCounters();
        }

        private void LoadSecurityCounters()
        {
            List<Password> redPasswords = _currentUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.RED);
            List<Password> orangePasswords = _currentUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.ORANGE);
            List<Password> yellowPasswords = _currentUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.YELLOW);
            List<Password> lightGreenPasswords = _currentUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.LIGHT_GREEN);
            List<Password> darkGreenPasswords = _currentUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.DARK_GREEN);

            lblRedAmount.Text = redPasswords.Count.ToString();
            lblOrangeAmount.Text = orangePasswords.Count.ToString();
            lblYellowAmount.Text = yellowPasswords.Count.ToString();
            lblLightGreenAmount.Text = lightGreenPasswords.Count.ToString();
            lblDarkGreenAmount.Text = darkGreenPasswords.Count.ToString();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Form securityReportGraphModal = new SecurityReportGraphModal(_userManager);
            securityReportGraphModal.ShowDialog();
        }
    }
}
