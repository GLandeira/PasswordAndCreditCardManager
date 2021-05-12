using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Domain.Exceptions;

namespace UserInterface
{
    public partial class NewOrModifyCreditCardModal : Form
    {
        public delegate void ModifiedCreditCardEvent();
        public static event ModifiedCreditCardEvent onNewOrModifyCreditCard;

        private User _currentUser;
        private bool _isModification;
        private CreditCard _CreditCardToModify;

        public NewOrModifyCreditCardModal(User user, CreditCard creditCardModified)
        {
            _currentUser = user;
            _CreditCardToModify = creditCardModified;
            InitializeComponent();

            //set DateTimePicker to month/year format
            dtmCreditCardDateDue.Format = DateTimePickerFormat.Custom;
            dtmCreditCardDateDue.CustomFormat = "MM/yyyy";

            if (creditCardModified != null)
            {
                _isModification = true;

                txtbxCreditCardName.Text = creditCardModified.Name;
                cmbbxCreditCardType.SelectedIndex = cmbbxCreditCardType.Items.IndexOf(creditCardModified.Type);
                txtbxCreditCardNumber.Text = creditCardModified.Number;
                txtbxCreditCardSecurityNumber.Text = creditCardModified.SecurityCode;
                dtmCreditCardDateDue.Value = creditCardModified.ValidDue;
                cmbbxCreditCardCategory.SelectedIndex = cmbbxCreditCardCategory.Items.IndexOf(creditCardModified.Category);
                txtbxCreditCardNotes.Text = creditCardModified.Notes;
            }
        }

        private void btnCreditCardConfirm_Click(object sender, EventArgs e)
        {
            CreditCard newCreditCard = new CreditCard
            {
                Name = txtbxCreditCardName.Text,
                Type = (CardTypes)cmbbxCreditCardType.SelectedItem,
                Number = NumberCreditCardFormatter(txtbxCreditCardNumber.Text),
                SecurityCode = txtbxCreditCardSecurityNumber.Text,
                ValidDue = dtmCreditCardDateDue.Value,
                Category = (Category) cmbbxCreditCardCategory.SelectedItem,
                Notes = txtbxCreditCardNotes.Text,
            };

            try
            {
                if(_isModification == false)
                {
                    _currentUser.UserCreditCards.AddCreditCard(newCreditCard);
                }
                else
                {
                    _currentUser.UserCreditCards.ModifyCreditCard(_CreditCardToModify, newCreditCard);
                }
                
                onNewOrModifyCreditCard?.Invoke();
                Close();
            }
            catch(CreditCardException creditCardException)
            {
                MessageBox.Show(creditCardException.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewOrModifyCreditCardModal_Load(object sender, EventArgs e)
        {
            List<Category> categoryList = _currentUser.Categories;
            categoryList.Remove(User.SHARED_WITH_ME_CATEGORY);
            

            cmbbxCreditCardCategory.DataSource = categoryList;
            cmbbxCreditCardType.DataSource = System.Enum.GetValues(typeof(CardTypes));
        }

        //malismo el metodo
        private void txtbxCreditCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0'
                        && e.KeyChar <= '9') 
                            && !(e.KeyChar == '\b'))
            {
                e.Handled = true;
            }
        }



        private void txtbxCreditCardNumber_TextChanged(object sender, EventArgs e)
        {
            string numberFormatted = Regex.Replace(txtbxCreditCardNumber.Text, "-", "");
            int numberFormattedSize = numberFormatted.Length;

            if (numberFormattedSize >= 4)
            {
                numberFormatted = numberFormatted.Insert(4, "-");
                numberFormattedSize++;
                if (numberFormattedSize > 9)
                {
                    numberFormatted = numberFormatted.Insert(9, "-");
                    numberFormattedSize++;
                    if (numberFormattedSize > 14)
                    {
                        numberFormatted = numberFormatted.Insert(14, "-");
                    }
                }

                txtbxCreditCardNumber.Text = numberFormatted;
                txtbxCreditCardNumber.Select(txtbxCreditCardNumber.Text.Length, 0);
            }
        }

        private string NumberCreditCardFormatter(string number)
        {
            return Regex.Replace(number, "-", "");
        }
    }
}
