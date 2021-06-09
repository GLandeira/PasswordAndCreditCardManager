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
    public partial class SecurityReportGraphModal : Form
    {
        private User _currentUser;
        private UserPassword _currentUserPassword;

        public SecurityReportGraphModal()
        {
            _currentUser = UserManager.Instance.LoggedUser;
            _currentUserPassword = _currentUser.UserPasswords;
            InitializeComponent();
        }

        private void SecurityReportGraphModal_Load(object sender, EventArgs e)
        {
            chrtSecurityReport.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chrtSecurityReport.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            foreach (Category category in _currentUser.UserCategories.Categories)
            {
                GenerateGraphSectionForCategory(category);
            }
        }

        private void GenerateGraphSectionForCategory(Category category)
        {
            int redAmount = _currentUserPassword.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.RED, category);
            int OrangeAmount = _currentUserPassword.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.ORANGE, category);
            int YellowAmount = _currentUserPassword.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.YELLOW, category);
            int LightGreenAmount = _currentUserPassword.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.LIGHT_GREEN, category);
            int DarkGreenAmount = _currentUserPassword.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.DARK_GREEN, category);

            int amountOfPassworsWithCategory = redAmount + OrangeAmount + YellowAmount + LightGreenAmount + DarkGreenAmount;

            if (amountOfPassworsWithCategory > 0)
            {
                chrtSecurityReport.Series["Red"].Points.AddXY(category.Name, redAmount);
                chrtSecurityReport.Series["Orange"].Points.AddXY(category.Name, OrangeAmount);
                chrtSecurityReport.Series["Yellow"].Points.AddXY(category.Name, YellowAmount);
                chrtSecurityReport.Series["Light Green"].Points.AddXY(category.Name, LightGreenAmount);
                chrtSecurityReport.Series["Dark Green"].Points.AddXY(category.Name, DarkGreenAmount);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
