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
using Domain.PasswordEncryptor;

namespace UserInterface
{
    public partial class PasswordMoreInfoModal : Form
    {

        private int _timeLeft;
        public PasswordMoreInfoModal(Password password)
        {
            InitializeComponent();
            EncryptorIndirection encryption = new EncryptorIndirection(new EffortlessEncryptionWrapper());

            dtmPasswordLastModified.Format = DateTimePickerFormat.Custom;
            dtmPasswordLastModified.CustomFormat = "MM/yyyy";

            encryption.PasswordDecryption(password);
            _timeLeft = 30;
            timerPasswordMoreInfo.Start();
            txtbxPasswordCategory.Text = password.Category.ToString();
            txtbxPasswordNotes.Text = password.Notes;
            txtbxPasswordSite.Text = password.Site;
            txtbxPasswordString.Text = password.PasswordString;
            txtbxPasswordSecurityLevel.Text = password.SecurityLevel.ToString();
            txtbxPasswordUsername.Text = password.Username;
            dtmPasswordLastModified.Value = password.LastModification;
            encryption.PasswordEncryption(password);

            Label userLabel;
            foreach (User user in password.UsersSharedWith)
            {
                userLabel = CreateSharedWithUserLabel(user);
                fwlytSharedWith.Controls.Add(userLabel);
            }
        }

        private Label CreateSharedWithUserLabel(User user)
        {
            Label newUserLabel = new Label();
            newUserLabel.Height = 20;
            newUserLabel.Width = 118;
            newUserLabel.Text = user.Name;
            return newUserLabel;
        }

        private void timerPasswordMoreInfo_Tick(object sender, EventArgs e)
        {
            txtbxTimeLeft.Text = _timeLeft.ToString();
            _timeLeft--;
            if(_timeLeft <= 0)
            {
                this.Close();
            }
        }
    }
}
