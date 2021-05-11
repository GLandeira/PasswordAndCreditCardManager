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

            for(int i = 0; i < _testPasswords.Count; i++)
            {
                Panel pnlParentPanel = new Panel();
                fwlytBreachedPassword.Controls.Add(pnlParentPanel);
                pnlParentPanel.Size = new Size(500, 23);

                Label lblPassword = new Label();
                pnlParentPanel.Controls.Add(lblPassword);
                lblPassword.Text = _testPasswords[i].ToString();
                lblPassword.Size = new Size(415, 13);
                lblPassword.Location = new Point(LABEL_X, LABEL_Y);

                Button btnModifyPassword = new Button();
                pnlParentPanel.Controls.Add(btnModifyPassword);
                btnModifyPassword.Text = BUTTON_MODIFY_TEXT;
                btnModifyPassword.Location = new Point(BUTTON_X, BUTTON_Y);
            }

            for(int i = 0; i < _testPasswords.Count; i++)
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void fwlytBreachedCreditCards_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
