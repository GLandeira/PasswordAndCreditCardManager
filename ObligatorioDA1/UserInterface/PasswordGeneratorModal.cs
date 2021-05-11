using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Exceptions;
using Domain.PasswordGenerator;

namespace UserInterface
{
    public partial class PasswordGeneratorModal : Form
    {

        public delegate void PasswordGeneratedEvent(string passwordGenerated);
        public static event PasswordGeneratedEvent onPasswordGeneration;
        public PasswordGeneratorModal()
        {
            InitializeComponent();

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            bool wantsMinus = chkBxMinus.Checked;
            bool wantsMayus = chkBxMayus.Checked;
            bool wantsDigits = chkBxDigits.Checked;
            bool wantsSymbols = chkBxSymbols.Checked;
            int lengthWanted;
            try
            {
                lengthWanted = int.Parse(txtBxLength.Text);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            try
            {
                PasswordGenerationSettings generationSettings = new PasswordGenerationSettings
                {
                    hasMayus = wantsMayus,
                    hasMinus = wantsMinus,
                    hasDigits = wantsDigits,
                    hasSymbols = wantsSymbols,
                    length = lengthWanted
                };
                string passwordString = PasswordGenerator.GeneratePassword(generationSettings);
                onPasswordGeneration?.Invoke(passwordString);
                this.Close();
            }
            catch (PasswordExceptions exception)
            {
                MessageBox.Show(exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
