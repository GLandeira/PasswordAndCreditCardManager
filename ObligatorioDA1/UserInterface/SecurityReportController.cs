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

        private User _currentUser;
        private UserPassword _currentUserPassword;

        private bool _passwordsPresentForGraph;
        public SecurityReportController()
        {
            _currentUser = UserManager.Instance.LoggedUser;
            _currentUserPassword = _currentUser.UserPasswords;
            InitializeComponent();
        }

        private void SecurityReportController_Load(object sender, EventArgs e)
        {
            LoadSecurityCounters();

            if (!_passwordsPresentForGraph)
            {
                btnSecurityGraph.Enabled = false;
            }
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

            Form checkForm = new CheckSecurityPasswordsModal(passwordsOfSecurityLevel, securityLevel);
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

            int amountRedPasswords = redPasswords.Count;
            int amountOrangePasswords = orangePasswords.Count;
            int amountYellowPasswords = yellowPasswords.Count;
            int amountLightGreenPasswords = lightGreenPasswords.Count;
            int amountDarkGreenPasswords = darkGreenPasswords.Count;

            lblRedAmount.Text = amountRedPasswords.ToString();
            lblOrangeAmount.Text = amountOrangePasswords.ToString();
            lblYellowAmount.Text = amountYellowPasswords.ToString();
            lblLightGreenAmount.Text = amountLightGreenPasswords.ToString();
            lblDarkGreenAmount.Text = amountDarkGreenPasswords.ToString();

            int totalAmountOfPasswords = amountRedPasswords + amountYellowPasswords + 
                                        amountOrangePasswords + amountDarkGreenPasswords + 
                                        amountLightGreenPasswords;

            _passwordsPresentForGraph = totalAmountOfPasswords != 0;
        }

        private void btnSecurityGraph_Click(object sender, EventArgs e)
        {
            Form securityReportGraphModal = new SecurityReportGraphModal();
            securityReportGraphModal.ShowDialog();
        }
    }
}
