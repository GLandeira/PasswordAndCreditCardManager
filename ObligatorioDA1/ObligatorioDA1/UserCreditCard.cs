using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserCreditCard
    {
        private List<CreditCard> _creditCards;

        public List<CreditCard> CreditCards
        {
            get
            {
                return _creditCards;
            }
            set
            {
                _creditCards = value;
            }
        }
        public UserCreditCard()
        {
            this._creditCards = new List<CreditCard>();
        }
        public void AddCreditCard(CreditCard creditCard)
        {
            CreditCards.Add(creditCard);
        }

        public void RemoveCreditCard(CreditCard creditCard)
        {
            CreditCards.Remove(creditCard);
        }

        public void modifyCreditCard(CreditCard creditCard1, CreditCard creditCardChangeTest)
        {
            throw new NotImplementedException();
        }
    }


}
