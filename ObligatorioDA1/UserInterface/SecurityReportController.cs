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

        public Panel creatPanelComponent(int securityLevelCount)
        {
            Panel panel = new Panel();
            Label label = new Label();
            Button button = new Button();
            label.Text = securityLevelCount.ToString();
            return panel;
        }

        private void SecurityReportController_Load(object sender, EventArgs e)
        {
            lblRedAmount.Text = _currentUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.RED).Count.ToString();
            lblOrangeAmount.Text = _currentUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.ORANGE).Count.ToString();
            lblYellowAmount.Text = _currentUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.YELLOW).Count.ToString();
            lblLightGreenAmount.Text = _currentUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.LIGHT_GREEN).Count.ToString();
            lblDarkGreenAmount.Text = _currentUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.DARK_GREEN).Count.ToString();
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
            //Form checkForm = new Form();
        }
    }
}
