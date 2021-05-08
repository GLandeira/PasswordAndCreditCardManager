using System;
using System.Collections.Generic;
using Domain.Exceptions;

namespace Domain
{
    public class UserCreditCard
    {
        public List<CreditCard> CreditCards { get; private set; }

        public UserCreditCard()
        {
            this.CreditCards = new List<CreditCard>();
        }

        public void AddCreditCard(CreditCard creditCard)
        {
            Verifier.VerifyCreditCard(creditCard);
            IsAlreadyInTheList(creditCard);
            CreditCards.Add(creditCard);
        }

        public void RemoveCreditCard(CreditCard creditCard)
        {
            CreditCards.Remove(creditCard);
        }

        public void ModifyCreditCard(CreditCard creditCardToRemove, CreditCard creditCardToAdd)
        {
            Verifier.VerifyCreditCard(creditCardToAdd);
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
