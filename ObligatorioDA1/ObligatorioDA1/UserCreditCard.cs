using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

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
            IsAlreadyInTheList(creditCard);
            CreditCards.Add(creditCard);
        }

        public void RemoveCreditCard(CreditCard creditCard)
        {
            CreditCards.Remove(creditCard);
        }

        public void ModifyCreditCard(CreditCard creditCardToRemove, CreditCard creditCardToAdd)
        {
            if (!creditCardToRemove.Equals(creditCardToAdd))
            {
                IsAlreadyInTheList(creditCardToAdd);
            }
            RemoveCreditCard(creditCardToRemove);
            AddCreditCard(creditCardToAdd);
        }

        public CreditCard GetCreditCard(String creditCardNumberToLook)
        {
            if (!CreditCards.Exists(creditCardInList => creditCardInList.Number.Equals(creditCardNumberToLook)))
            {
                throw new CreditCardNotFoundException();
            }
            return CreditCards.Find(creditCardInList => creditCardInList.Number.Equals(creditCardNumberToLook));
        }

        private void IsAlreadyInTheList(CreditCard creditCard)
        {
            if (CreditCards.Exists(creditCardInList => creditCardInList.Equals(creditCard)))
            {
                throw new CreditCardRepeatedException();
            }
        }
    }
}
