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
using Domain.DataBreachesTranslator;

namespace UserInterface
{
    public partial class DataBreachesController : UserControl
    {
        private const string NO_BREACHED_PASSWORDS = "No breaches found.";

        private UserManager _userManager;
        private User _currentUser;

        public DataBreachesController(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _currentUser = _userManager.LoggedUser;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            ITranslator textBoxTranslator = new TextBoxTranslator();
            string[] fields = textBoxTranslator.Translate(txtbxDataBreaches.Text);

            DataBreaches dataBreaches = _currentUser.UserDataBreaches.CheckDataBreaches(fields);

            if(dataBreaches.CreditCardsBreaches.Count == 0 && dataBreaches.PasswordBreaches.Count == 0)
            {
                MessageBox.Show(NO_BREACHED_PASSWORDS, "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form matchesDataBreaches = new DataBreachMatchesModal(_currentUser, dataBreaches);
            matchesDataBreaches.ShowDialog();
        }
    }
}
