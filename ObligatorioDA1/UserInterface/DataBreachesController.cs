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
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string fieldsWithoutSeparation = txtbxDataBreaches.Text;
            string[] separator = new string[] { Environment.NewLine };

            string[] fields = fieldsWithoutSeparation.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            DataBreaches dataBreaches = _currentUser.UserDataBreaches.CheckDataBreaches(fields);

            Form matchesDataBreaches = new DataBreachMatchesModal(dataBreaches);
            matchesDataBreaches.ShowDialog();
        }
    }
}
