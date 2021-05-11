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
    public partial class DataBreachesController : UserControl
    {
        private UserManager _userManager;
        private User _currentUser;

        public DataBreachesController(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _currentUser = _userManager.LoggedUser;

            // Temporary passwords and credit cards for testing
            Password p1 = new Password()
            {
                Username = "Popis",
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
                PasswordString = "12bca",
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

            _currentUser.UserPasswords.AddPassword(p1);
            _currentUser.UserPasswords.AddPassword(p2);
            _currentUser.UserPasswords.AddPassword(p3);

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

            _currentUser.UserCreditCards.AddCreditCard(c1);
            _currentUser.UserCreditCards.AddCreditCard(c2);
            _currentUser.UserCreditCards.AddCreditCard(c3);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string[] fields = GetEntryFieldsSeparatedWithEnter(txtbxDataBreaches.Text);

            DataBreaches dataBreaches = _currentUser.UserDataBreaches.CheckDataBreaches(fields);

            Form matchesDataBreaches = new DataBreachMatchesModal(dataBreaches);
            matchesDataBreaches.ShowDialog();
        }

        private string[] GetEntryFieldsSeparatedWithEnter(string entry)
        {
            string[] separator = new string[] { Environment.NewLine };
            string[] fields = entry.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            return fields;
        }
    }
}
