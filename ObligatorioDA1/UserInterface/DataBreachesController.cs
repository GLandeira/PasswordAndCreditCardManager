using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
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

        private User _currentUser;
        private OpenFileDialog _fileDialog;
        private DataBreachMediator _dataBreachMediator;

        public DataBreachesController()
        {
            InitializeComponent();
            _currentUser = UserManager.Instance.LoggedUser;

            _dataBreachMediator = new DataBreachMediator(this, _currentUser.UserDataBreaches);

            _fileDialog = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };
        }

        public void DataBreachModalOpening(DataBreach dataBreaches)
        {
            if (dataBreaches.CreditCardBreaches.Count == 0 && dataBreaches.PasswordBreaches.Count == 0)
            {
                MessageBox.Show(NO_BREACHED_PASSWORDS, "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form matchesDataBreaches = new DataBreachMatchesModal(dataBreaches);
            matchesDataBreaches.ShowDialog();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            ITranslator textBoxTranslator = new TextBoxTranslator();
            string field = txtbxDataBreaches.Text;

            _dataBreachMediator.CheckAndRegisterDataBreach(field, textBoxTranslator, _currentUser.UserPasswords.Passwords);
        }

        private void btnImportTextFile_Click(object sender, EventArgs e)
        {
            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader importFile = new StreamReader(_fileDialog.FileName);
                    ITranslator textFileTranslator = new TextFileTranslator();
                    
                    _dataBreachMediator.CheckAndRegisterDataBreach(importFile.ReadToEnd(), textFileTranslator, _currentUser.UserPasswords.Passwords);
                }
                catch (SecurityException a)
                {
                }
            }
        }
    }
}
