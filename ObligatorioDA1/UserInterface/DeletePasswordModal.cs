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
    public partial class DeletePasswordModal : Form
    {
        User _currentUser;
        Password toDeletePassword;
        public DeletePasswordModal(User loggedUser, Password passwordToDelete)
        {
            _currentUser = loggedUser;
            toDeletePassword = passwordToDelete;
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            _currentUser.UserPasswords.RemovePassword(toDeletePassword);
            this.Close();
        }
    }
}
