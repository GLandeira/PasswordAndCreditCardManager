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

namespace UserInterface
{
    public partial class CreditCardMoreInfoModal : Form
    {
        private int _timeLeft;

        public CreditCardMoreInfoModal(CreditCard creditCard)
        {
            InitializeComponent();

            //set DateTimePicker to month/year format
            dtmCreditCardValidDue.Format = DateTimePickerFormat.Custom;
            dtmCreditCardValidDue.CustomFormat = "MM/yyyy";

            txtbxCreditCardCategory.Text = creditCard.Category.Name;
            txtbxCreditCardName.Text = creditCard.Name;
            txtbxCreditCardType.Text = creditCard.Type.ToString();
            txtbxCreditCardNumber.Text = creditCard.Number;
            txtbxCreditCardSecurityCode.Text = creditCard.SecurityCode;
            dtmCreditCardValidDue.Value = creditCard.ValidDue;
            txtbxCreditCardNotes.Text = creditCard.Notes;

            //timer settings
            _timeLeft = 30;
            timerCreditCardMoreInfo.Start();
        }

        private void timerCreditCardMoreInfo_Tick(object sender, EventArgs e)
        {
            txtbxTimer.Text = (_timeLeft).ToString();
            _timeLeft--;
            if (_timeLeft <= 0)
            {
                Close();
            }
        }
    }
}
