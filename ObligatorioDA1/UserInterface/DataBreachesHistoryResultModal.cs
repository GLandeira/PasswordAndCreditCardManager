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
    public partial class DataBreachesHistoryResultModal : Form
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

        private PasswordHistory _auxPasswordHistoryForModificationChecks;
        private DataBreach _theDataBreach;
        private User _currentUser;

        public DataBreachesHistoryResultModal(DataBreach dataBreach)
        {
            InitializeComponent();
            _currentUser = UserManager.Instance.LoggedUser;
            _theDataBreach = dataBreach;
            AddOrModifyPasswordModal.onModifySinglePassword += OnPasswordModified;
        }

        private void DataBreachesHistoryResultModal_Load(object sender, EventArgs e)
        {
            DataBreach theDataBreaches = _theDataBreach;
            List<PasswordHistory> breachedPasswords = theDataBreaches.PasswordBreaches;
            List<CreditCard> breachedCreditCards = theDataBreaches.CreditCardBreaches;
            
            GenerateBreachedPasswordVisuals(breachedPasswords);

            GenerateBreachedCreditCardVisuals(breachedCreditCards);
        }

        private void GenerateBreachedPasswordVisuals(List<PasswordHistory> passwords)
        {
            DecryptPasswordsInPasswordHistory(passwords);

            fwlytBreachedPassword.Controls.Clear();
            for (int i = 0; i < passwords.Count; i++)
            {
                CreatePasswordListComponent(passwords[i]);
            }

            EncryptPasswordsInPasswordHistory(passwords);
        }

        private void DecryptPasswordsInPasswordHistory(List<PasswordHistory> breachedPasswords)
        {
            EncryptorIndirection encryption = new EncryptorIndirection(new EffortlessEncryptionWrapper());

            for (int i = 0; i < breachedPasswords.Count; i++)
            {
                encryption.PasswordDecryption(breachedPasswords[i].Password);
            }
        }

        private void EncryptPasswordsInPasswordHistory(List<PasswordHistory> breachedPasswords)
        {
            EncryptorIndirection encryption = new EncryptorIndirection(new EffortlessEncryptionWrapper());

            for (int i = 0; i < breachedPasswords.Count; i++)
            {
                encryption.PasswordEncryption(breachedPasswords[i].Password);
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

        private void CreatePasswordListComponent(PasswordHistory passwordHistory)
        {
            Panel pnlParentPanel = CreatePanelWithSize(PARENT_PANEL_SIZE_X, PARENT_PANEL_SIZE_Y);
            fwlytBreachedPassword.Controls.Add(pnlParentPanel);

            Label lblPassword = CreateLabelWithSettings(new Size(LABEL_SIZE_X, LABEL_SIZE_Y), new Point(LABEL_X, LABEL_Y), passwordHistory.Password.ToString(), passwordHistory.BreachedPasswordString);
            pnlParentPanel.Controls.Add(lblPassword);

            if (!passwordHistory.Password.Category.Equals(UserCategory.SHARED_WITH_ME_CATEGORY) && (passwordHistory.Password.PasswordString.Equals(passwordHistory.BreachedPasswordString)))
            {
                Button btnModifyPassword = CreateButtonWithSettings(BUTTON_MODIFY_TEXT, new Point(BUTTON_X, BUTTON_Y));

                // EventHandler takes a function of object and EventArgs parameters.
                // By providing a wrapper I can call any function that takes any parameter
                EventHandler onClickEvent = new EventHandler((obj, eventArgs) => ModifyButtonsOnClick(passwordHistory));
                btnModifyPassword.Click += onClickEvent;
                pnlParentPanel.Controls.Add(btnModifyPassword);
            }
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

        private Label CreateLabelWithSettings(Size size, Point location, string message, string passwordString)
        {
            Label newLabel = new Label();

            newLabel.Text = message + "Password breached: " + passwordString;
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

        private void ModifyButtonsOnClick(PasswordHistory passwordHistory)
        {
            _auxPasswordHistoryForModificationChecks = passwordHistory;
            Form modifyPassword = new AddOrModifyPasswordModal(passwordHistory.Password);
            modifyPassword.ShowDialog();
        }

        private void StopBreachedChecksIfNoMoreBreaches(List<PasswordHistory> breachedPasswords)
        {
            if (breachedPasswords.Count <= 0)
            {
                MessageBox.Show(NO_MORE_BREACHED_PASSWORDS, "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CloseIfNoCreditCardBreaches();
            }
        }

        private void CloseIfNoCreditCardBreaches()
        {
            if (_theDataBreach.CreditCardBreaches.Count <= 0)
            {
                Close();
            }
        }

        private void OnPasswordModified(Password modifiedPassword)
        {
            List<PasswordHistory> breachedPasswords = _theDataBreach.PasswordBreaches;
            PasswordHistory originalBreach = breachedPasswords.FirstOrDefault(pass => pass.AbsoluteEquals(_auxPasswordHistoryForModificationChecks));
            breachedPasswords.RemoveAll(pass => pass.AbsoluteEquals(_auxPasswordHistoryForModificationChecks));

            originalBreach.Password = modifiedPassword;
            breachedPasswords.Add(originalBreach);
            GenerateBreachedPasswordVisuals(breachedPasswords);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            AddOrModifyPasswordModal.onModifySinglePassword -= OnPasswordModified;
        }
    }
}
