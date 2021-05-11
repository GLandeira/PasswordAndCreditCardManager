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

        private DataBreaches _theDataBreaches;

        private List<Password> _testPasswords = new List<Password>();
        private List<CreditCard> _testCreditCards = new List<CreditCard>();

        public DataBreachMatchesModal(DataBreaches dataBreaches)
        {
            InitializeComponent();
            _theDataBreaches = dataBreaches;

            // Temporary passwords and credit cards for testing
            Password p1 = new Password()
            {
                Username = "Popi",
                Site = "www.pops.com",
                Category = new Category("Personal"),
                Notes = "Aiaiai popi popaa aiaiai",
                PasswordString = "1234abc",
                SecurityLevel = Domain.PasswordSecurityFlagger.SecurityLevelPasswords.RED,
                LastModification = DateTime.Today
            };

            Password p2 = new Password()
            {
                Username = "Pogdgi",
                Site = "www.popsddd.com",
                Category = new Category("Personal"),
                Notes = "A aiaiai",
                PasswordString = "12bc",
                SecurityLevel = Domain.PasswordSecurityFlagger.SecurityLevelPasswords.RED,
                LastModification = DateTime.Today
            };

            Password p3 = new Password()
            {
                Username = "Popaaai",
                Site = "www.poasdasdps.com",
                Category = new Category("Personal"),
                Notes = "Aiaiai popi popaa aiaiai",
                PasswordString = "abc123",
                SecurityLevel = Domain.PasswordSecurityFlagger.SecurityLevelPasswords.RED,
                LastModification = DateTime.Today
            };

            _testPasswords.Add(p1);
            _testPasswords.Add(p2);
            _testPasswords.Add(p3);

            CreditCard c1 = new CreditCard()
            {
                Number = "1111111111112222",
                Category = new Category("Personal"),
                Notes = "Aiaiai popi popaa aiaiai",
                Name = "Visa Gold",
                Type = CardTypes.VISA,
                ValidDue = DateTime.Today,
                SecurityCode = "111"
            };

            CreditCard c2 = new CreditCard()
            {
                Number = "1331111111112222",
                Category = new Category("Personal"),
                Notes = "Aiaiai popi popaa aiaiai",
                Name = "Visa Gold",
                Type = CardTypes.VISA,
                ValidDue = DateTime.Today,
                SecurityCode = "211"
            };

            CreditCard c3 = new CreditCard()
            {
                Number = "1111111661112222",
                Category = new Category("Personal"),
                Notes = "Aiaiai popi popaa aiaiai",
                Name = "Visa Gold",
                Type = CardTypes.VISA,
                ValidDue = DateTime.Today,
                SecurityCode = "131"
            };

            _testCreditCards.Add(c1);
            _testCreditCards.Add(c2);
            _testCreditCards.Add(c3);
        }

        private void DataBreachMatchesModal_Load(object sender, EventArgs e)
        {
            List<Password> breachedPasswords = _theDataBreaches.PasswordBreaches;

            GenerateBreachedPasswordVisuals(_testPasswords);

            GenerateBreachedCreditCardVisuals(_testCreditCards);
        }

        private void GenerateBreachedPasswordVisuals(List<Password> passwords)
        {
            for (int i = 0; i < passwords.Count; i++)
            {
                Password currentPassword = passwords[i];

                CreatePasswordListComponent(currentPassword);
            }
        }

        private void GenerateBreachedCreditCardVisuals(List<CreditCard> creditCards)
        {
            for (int i = 0; i < _testCreditCards.Count; i++)
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
            btnModifyPassword.Click += new EventHandler((obj, eventArgs) => ModifyButtonsOnClick(password));
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
            //TODO Add PasswordModify call
        }
    }
}
