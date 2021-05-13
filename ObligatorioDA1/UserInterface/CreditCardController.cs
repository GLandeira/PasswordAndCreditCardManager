﻿using System;
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
    public partial class CreditCardController : UserControl
    {
        private UserManager _userManager;
        private User _currentUser;
        private CreditCard _selectedCreditCard;

        public CreditCardController(UserManager userManager)
        {
            _userManager = userManager;
            _currentUser = _userManager.LoggedUser;

            InitializeComponent();
            ButtonDeleteModifyEnabler(false);

            NewOrModifyCreditCardModal.onNewOrModifyCreditCard += CreditCardLoad;
        }

        private void CreditCardController_Load(object sender, EventArgs e)
        {
            CreditCardLoad();
        }

        private void CreditCardLoad()
        {
            BindingSource creditCardsDataSource = new BindingSource();
            List<CreditCard> creditCards = _currentUser.UserCreditCards.CreditCards.
                                                    OrderBy(p => p.Category.Name.ToUpper()).ToList();
            creditCardsDataSource.DataSource = creditCards;

            grdvwCreditCard.DataSource = creditCardsDataSource;

            ButtonDeleteModifyEnabler(creditCardsDataSource.Count != 0);
        }

        private void btnNewCreditCard_Click(object sender, EventArgs e)
        {
            Form newOrModifyCreditCardModal = new NewOrModifyCreditCardModal(_currentUser, null);
            newOrModifyCreditCardModal.ShowDialog();
        }

        private void btnDeleteCreditCard_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResultDeleteCreditCard = MessageBox.Show("Are you sure you want to delete " +
                                                             _selectedCreditCard.Name + " Credit Card?", "Confirmation",
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResultDeleteCreditCard == DialogResult.Yes)
                {
                    _currentUser.UserCreditCards.RemoveCreditCard(_selectedCreditCard);
                    CreditCardLoad();
                }
            }
            catch (CreditCardException creditCardException)
            {
                MessageBox.Show(creditCardException.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnModifyCreditCard_Click_1(object sender, EventArgs e)
        {
            try
            {
                Form newOrModifyCreditCardModal = new NewOrModifyCreditCardModal(_currentUser, _selectedCreditCard);
                newOrModifyCreditCardModal.ShowDialog();
            }
            catch (Exception creditCardException)
            {
                MessageBox.Show(creditCardException.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            NewOrModifyCreditCardModal.onNewOrModifyCreditCard -= CreditCardLoad;
        }

        private void grdvwCreditCard_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            CreditCard selectedRowCreditCard = (CreditCard)grdvwCreditCard.Rows[e.RowIndex].DataBoundItem;
            _selectedCreditCard = selectedRowCreditCard;
        }

        private void grdvwCreditCard_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form moreCreditCardInfo = new CreditCardMoreInfoModal(_selectedCreditCard);
            moreCreditCardInfo.ShowDialog();
        }

        private void grdvwCreditCard_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (this.grdvwCreditCard.Columns[e.ColumnIndex].Name == "numberDataGridViewTextBoxColumn")
                {
                    string numberValue = (string)e.Value;
                    e.Value = "XXXX-XXXX-XXXX-" + numberValue.Substring(12, 4);
                }
            }
            catch (Exception)
            {
            }
        }

        private void ButtonDeleteModifyEnabler(bool enable)
        {
            if (enable)
            {
                btnDeleteCreditCard.Enabled = true;
                btnModifyCreditCard.Enabled = true;
            }
            else
            {
                btnDeleteCreditCard.Enabled = false;
                btnModifyCreditCard.Enabled = false;
            }
        }
    }
}
