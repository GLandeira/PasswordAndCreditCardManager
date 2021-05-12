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
    public partial class PasswordMoreInfoModal : Form
    {

        private int _timeLeft;
        public PasswordMoreInfoModal(Password password)
        {
            InitializeComponent();
            _timeLeft = 30;
            timerPasswordMoreInfo.Start();
            lblCategoryFill.Text = password.Category.ToString();
            lblNotesFill.Text = password.Notes;
            lblSiteFill.Text = password.Site;
            lblPasswordFill.Text = password.PasswordString;
            lblSecurityLevelFill.Text = password.SecurityLevel.ToString();
            lblUsernameFill.Text = password.Username;
            Label userLabel;
            foreach (string username in password.UsersSharedWith)
            {
                userLabel = CreateSharedWithUserLabel(username);
                fwlytSharedWith.Controls.Add(userLabel);
            }
        }

        private Label CreateSharedWithUserLabel(string username)
        {
            Label newUserLabel = new Label();
            newUserLabel.Height = 20;
            newUserLabel.Width = 118;
            newUserLabel.Text = username;
            return newUserLabel;
        }

        private void timerPasswordMoreInfo_Tick(object sender, EventArgs e)
        {
            txtBxTimeLeft.Text = _timeLeft.ToString();
            _timeLeft--;
            if(_timeLeft <= 0)
            {
                this.Close();
            }
        }
    }
}
