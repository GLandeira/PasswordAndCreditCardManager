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
    public partial class CreditCardController : UserControl
    {
        private UserManager _userManager;
        private User _currentUser;
        private CreditCard _selectedCreditCard;

        //pruebas
        private Category _trabajo = new Category("Trabajo");
        private CardTypes _visa = CardTypes.VISA;
        private CreditCard _creditCard1 = new CreditCard
        {
            Name = "Visa Gold",
            Number = "1111111111111111",
            SecurityCode = "1234",
            ValidDue = DateTime.Today,
            Notes = "super secreta, no compartir"
        };

        public CreditCardController(UserManager userManager)
        {
            _userManager = userManager;
            _currentUser = _userManager.LoggedUser;
            _currentUser.UserCreditCards.AddCreditCard(_creditCard1);
            InitializeComponent();
            NewOrModifyCreditCardModal.onNewOrModifyCreditCard += CreditCardLoad;
        }

        private void CreditCardController_Load(object sender, EventArgs e)
        {
            CreditCardLoad();
        }

        private void CreditCardLoad()
        {
            List<CreditCard> bs = _currentUser.UserCreditCards.CreditCards;
            grdvwCreditCard.AutoGenerateColumns = false;
            grdvwCreditCard.DataSource = bs;
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
                _currentUser.UserCreditCards.RemoveCreditCard(_selectedCreditCard);
            }
            catch(CreditCardException creditCardException)
            {
                MessageBox.Show(creditCardException.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    
        }

        private void btnModifyCreditCard_Click(object sender, EventArgs e)
        {;
            Form newOrModifyCreditCardModal = new NewOrModifyCreditCardModal(_currentUser, _selectedCreditCard);
            newOrModifyCreditCardModal.ShowDialog();
        }

        private void grdvwCreditCard_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CreditCard selectedRowCreditCard = (CreditCard)grdvwCreditCard.Rows[e.RowIndex].DataBoundItem;
            _selectedCreditCard = selectedRowCreditCard;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            NewOrModifyCreditCardModal.onNewOrModifyCreditCard -= CreditCardLoad;
        }
    }
}
