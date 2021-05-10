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
    public partial class DataBreachMatchesModal : Form
    {
        private DataBreaches _theDataBreaches;

        public DataBreachMatchesModal(DataBreaches dataBreaches)
        {
            InitializeComponent();
            _theDataBreaches = dataBreaches;
        }

        private void DataBreachMatchesModal_Load(object sender, EventArgs e)
        {
            List<Password> breachedPasswords = _theDataBreaches.PasswordBreaches;

            foreach(Password p in breachedPasswords)
            {
                ListViewItem row = new ListViewItem(p.ToString());
                lstvwPasswordLists.Items.Add(row);
            }
        }
    }
}
