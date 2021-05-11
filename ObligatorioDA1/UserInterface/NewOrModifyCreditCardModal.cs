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
using Domain.Exceptions;

namespace UserInterface
{
    public partial class NewOrModifyCreditCardModal : Form
    {
        public delegate void ModifiedCreditCardEvent();
        public static event ModifiedCreditCardEvent onNewOrModifyCreditCard;

        private User _currentUser;

        public NewOrModifyCreditCardModal(User user, CreditCard creditCardModified)
        {
            _currentUser = user;
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";

            if (creditCardModified != null)
            {
                txtbxCreditCardName.Text = creditCardModified.Name;
                cmbbxCreditCardType.SelectedIndex = cmbbxCreditCardType.Items.IndexOf(creditCardModified.Type);
                txtbxCreditCardNumber.Text = creditCardModified.Number;
                txtbxCreditCardSecurityNumber.Text = creditCardModified.SecurityCode;
                //numCreditCardMonth
                //numCreditCardYear. = creditCardModified.ValidDue.Year;
                cmbbxCreditCardCategory.SelectedIndex = cmbbxCreditCardCategory.Items.IndexOf(creditCardModified.Category);
                txtbxCreditCardNotes.Text = creditCardModified.Notes;
            }
        }

        private void btnCreditCardConfirm_Click(object sender, EventArgs e)
        {
            CreditCard newCreditCard = new CreditCard
            {
                Name = txtbxCreditCardName.Text,
                Type = (CardTypes) cmbbxCreditCardType.SelectedItem,
                Number = txtbxCreditCardNumber.Text,
                SecurityCode = txtbxCreditCardSecurityNumber.Text,
                //ValidDue = Convert.ToDateTime(txtbxCreditCardDateDue.Text),
                Category = (Category) cmbbxCreditCardCategory.SelectedItem,
                Notes = txtbxCreditCardNotes.Text,
            };

            try
            {
                _currentUser.UserCreditCards.AddCreditCard(newCreditCard);
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
    }
}
