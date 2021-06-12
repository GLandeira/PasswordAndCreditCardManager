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

        public DataBreachesController()
        {
            InitializeComponent();
            _currentUser = UserManager.Instance.LoggedUser;

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

            DataBreach dataBreaches = CheckDataBreaches(field, textBoxTranslator);

            DataBreachModalOpening(dataBreaches);
        }

        private void btnImportTextFile_Click(object sender, EventArgs e)
        {
            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader importFile = new StreamReader(_fileDialog.FileName);
                    ITranslator textFileTranslator = new TextFileTranslator();

                    DataBreach dataBreaches = CheckDataBreaches(importFile.ReadToEnd(), textFileTranslator);

                    DataBreachModalOpening(dataBreaches);
                }
                catch (SecurityException a)
                {
                }
            }
        }

        private DataBreach CheckDataBreaches(string breachesText, ITranslator translator)
        {
            DataBreach dataBreaches = _currentUser.UserDataBreaches.CheckDataBreaches(breachesText, translator);
            return dataBreaches;
        }

        
    }
}
