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
    public partial class CheckSecurityPasswordsModal : Form
    {
        private const int PARENT_PANEL_SIZE_X = 500;
        private const int PARENT_PANEL_SIZE_Y = 34;

        private const int LABEL_SIZE_Y = 15;
        private const int LABEL_SIZE_X = 396;
        private const int LABEL_Y = 9;
        private const int LABEL_X = 3;

        private const int BUTTON_Y = 6;
        private const int BUTTON_X = 425;

        private const string BUTTON_MODIFY_TEXT = "Modify";

        private Password _auxPasswordForModificationChecks;
        private List<Password> _passwords;
        private User _currentUser;
        private SecurityLevelPasswords _securityLevelChecking;
        public CheckSecurityPasswordsModal(User loggedUser, List<Password> passwords, SecurityLevelPasswords securityLevelChecking)
        {
            InitializeComponent();
            _passwords = passwords;
            _currentUser = loggedUser;
            _securityLevelChecking = securityLevelChecking;
            AddOrModifyPasswordModal.onModifySinglePassword += OnPasswordModified;
        }

        private void CheckSecurityPasswordsModal_Load(object sender, EventArgs e)
        {
            this.Text = _securityLevelChecking.ToString().ToLower() + " level passwords";
            GeneratePasswordVisuals(_passwords);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnPasswordModified(Password modifiedPassword)
        {
            List<Password> breachedPasswords = _passwords;
            breachedPasswords.RemoveAll(pass => pass.PasswordString == _auxPasswordForModificationChecks.PasswordString);

            if (PasswordSecurityFlagger.GetSecurityLevel(modifiedPassword.PasswordString) == _securityLevelChecking)
            {
                breachedPasswords.Add(modifiedPassword);
            }

            GeneratePasswordVisuals(breachedPasswords);
        }

        private void GeneratePasswordVisuals(List<Password> passwords)
        {
            fwlytPasswords.Controls.Clear();
            for (int i = 0; i < passwords.Count; i++)
            {
                Password currentPassword = passwords[i];

                GeneratePasswordListElement(currentPassword);
            }
        }

        private void GeneratePasswordListElement(Password password)
        {
            Panel pnlParentPanel = CreatePanelWithSize(PARENT_PANEL_SIZE_X, PARENT_PANEL_SIZE_Y);
            fwlytPasswords.Controls.Add(pnlParentPanel);

            Label lblPassword = CreateLabelWithSettings(new Size(LABEL_SIZE_X, LABEL_SIZE_Y), new Point(LABEL_X, LABEL_Y), password.ToString());
            pnlParentPanel.Controls.Add(lblPassword);

            Button btnModifyPassword = CreateButtonWithSettings(BUTTON_MODIFY_TEXT, new Point(BUTTON_X, BUTTON_Y));

            // EventHandler takes a function of object and EventArgs parameters.
            // By providing a wrapper I can call any function that takes any parameter
            EventHandler clickEvent = new EventHandler((obj, eventArgs) => ModifyButtonsOnClick(password));
            btnModifyPassword.Click += clickEvent;
            pnlParentPanel.Controls.Add(btnModifyPassword);
        }

        private Panel CreatePanelWithSize(int sizeX, int sizeY)
        {
            Panel newPanel = new Panel();
            newPanel.Size = new Size(sizeX, sizeY);

            return newPanel;
        }

        private Label CreateLabelWithSettings(Size size, Point location, string message)
        {
            Label newLabel = new Label();

            newLabel.Text = message;
            newLabel.Size = size;
            newLabel.Location = location;

            return newLabel;
        }

        private Button CreateButtonWithSettings(string buttonText, Point location)
        {
            Button newButton = new Button();

            newButton.Text = buttonText;
            newButton.Location = location;

            return newButton;
        }

        private void ModifyButtonsOnClick(Password thePassword)
        {
            _auxPasswordForModificationChecks = thePassword;
            Form modifyPassword = new AddOrModifyPasswordModal(_currentUser, thePassword);
            modifyPassword.ShowDialog();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            AddOrModifyPasswordModal.onModifySinglePassword -= OnPasswordModified;
        }
    }
}
