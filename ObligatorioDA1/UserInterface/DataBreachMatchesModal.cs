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
    public partial class DataBreachMatchesModal : Form
    {
        private const int PARENT_PANEL_SIZE_X = 500;
        private const int PARENT_PANEL_SIZE_Y = 23;

        private const int LABEL_SIZE_Y = 13;
        private const int LABEL_SIZE_X = 415;
        private const int LABEL_Y = 4;
        private const int LABEL_X = 0;

        private const int BUTTON_Y = 0;
        private const int BUTTON_X = 422;

        private const string BUTTON_MODIFY_TEXT = "Modify";
        private const string NO_MORE_BREACHED_PASSWORDS = "There are no more breached passwords.";

        private Password _auxPasswordForModificationChecks;
        private DataBreaches _theDataBreaches;
        private User _currentUser;

        public DataBreachMatchesModal(User loggedUser, DataBreaches dataBreaches)
        {
            InitializeComponent();
            _theDataBreaches = dataBreaches;
            _currentUser = loggedUser;
            AddOrModifyPasswordModal.onModifySinglePassword += OnPasswordModified;
        }

        private void DataBreachMatchesModal_Load(object sender, EventArgs e)
        {
            List<Password> breachedPasswords = _theDataBreaches.PasswordBreaches;
            List<CreditCard> breachedCreditCards = _theDataBreaches.CreditCardsBreaches;

            GenerateBreachedPasswordVisuals(breachedPasswords);

            GenerateBreachedCreditCardVisuals(breachedCreditCards);
        }

        private void OnPasswordModified(Password modifiedPassword)
        {
            List<Password> breachedPasswords = _theDataBreaches.PasswordBreaches;
            breachedPasswords.RemoveAll(pass => pass.PasswordString == _auxPasswordForModificationChecks.PasswordString);
            if (modifiedPassword.PasswordString != _auxPasswordForModificationChecks.PasswordString)
            {
                StopBreachedChecksIfNoMoreBreaches(breachedPasswords);
            }
            else
            {
                breachedPasswords.Add(modifiedPassword);
            }
            GenerateBreachedPasswordVisuals(breachedPasswords);
        }

        private void GenerateBreachedPasswordVisuals(List<Password> passwords)
        {
            fwlytBreachedPassword.Controls.Clear();
            for (int i = 0; i < passwords.Count; i++)
            {
                Password currentPassword = passwords[i];

                CreatePasswordListComponent(currentPassword);
            }
        }

        private void GenerateBreachedCreditCardVisuals(List<CreditCard> creditCards)
        {
            fwlytBreachedCreditCards.Controls.Clear();
            for (int i = 0; i < creditCards.Count; i++)
            {
                CreditCard currentCreditCard = creditCards[i];

                CreateCreditCardListComponent(currentCreditCard);
            }
        }

        private void CreatePasswordListComponent(Password password)
        {
            Panel pnlParentPanel = CreatePanelWithSize(PARENT_PANEL_SIZE_X, PARENT_PANEL_SIZE_Y);
            fwlytBreachedPassword.Controls.Add(pnlParentPanel);

            Label lblPassword = CreateLabelWithSettings(new Size(LABEL_SIZE_X, LABEL_SIZE_Y), new Point(LABEL_X, LABEL_Y), password.ToString());
            pnlParentPanel.Controls.Add(lblPassword);

            Button btnModifyPassword = CreateButtonWithSettings(BUTTON_MODIFY_TEXT, new Point(BUTTON_X, BUTTON_Y));

            // EventHandler takes a function of object and EventArgs parameters.
            // By providing a wrapper I can call any function that takes any parameter
            EventHandler onClickEvent = new EventHandler((obj, eventArgs) => ModifyButtonsOnClick(password));
            btnModifyPassword.Click += onClickEvent;
            pnlParentPanel.Controls.Add(btnModifyPassword);
        }

        private void CreateCreditCardListComponent(CreditCard creditCard)
        {
            Panel pnlParentPanel = CreatePanelWithSize(PARENT_PANEL_SIZE_X, PARENT_PANEL_SIZE_Y);
            fwlytBreachedCreditCards.Controls.Add(pnlParentPanel);

            Label lblCreditCard = CreateLabelWithSettings(new Size(LABEL_SIZE_X, LABEL_SIZE_Y), new Point(LABEL_X, LABEL_Y), creditCard.ToString());
            pnlParentPanel.Controls.Add(lblCreditCard);
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

        private void StopBreachedChecksIfNoMoreBreaches(List<Password> breachedPasswords)
        {
            if(breachedPasswords.Count <= 0)
            {
                MessageBox.Show(NO_MORE_BREACHED_PASSWORDS, "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CloseIfNoCreditCardBreaches();
            }
        }

        private void CloseIfNoCreditCardBreaches()
        {
            if (_theDataBreaches.CreditCardsBreaches.Count <= 0)
            {
                Close();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            AddOrModifyPasswordModal.onModifySinglePassword -= OnPasswordModified;
        }
    }
}
