using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Exceptions;

namespace Domain
{
    public class UserCreditCard
    {
        //public User User { get; set; }
        public int UserCreditCardID { get; set; }
        public List<CreditCard> CreditCards { get; private set; }

        public UserCreditCard()
        {
            CreditCards = new List<CreditCard>();
        }

        public void AddCreditCard(CreditCard creditCard)
        {
            Verifier.VerifyCreditCard(creditCard);
            IsAlreadyInTheList(creditCard);
            AddCreditCardToListAndDB(creditCard);
        }

        public void RemoveCreditCard(CreditCard creditCardToRemove)
        {
            CheckIfCreditCardExists(creditCardToRemove);

            CreditCards.Remove(creditCardToRemove);
            RepositoryFacade.Instance.CreditCardDataAccess.Delete(creditCardToRemove);
        }

        public void ModifyCreditCard(CreditCard creditCardToRemove, CreditCard creditCardToAdd)
        {
            CheckIfCreditCardExists(creditCardToRemove);

            Verifier.VerifyCreditCard(creditCardToAdd);

            if (!creditCardToRemove.Equals(creditCardToAdd))
            {
                IsAlreadyInTheList(creditCardToAdd);
            }

            CreditCards.Remove(creditCardToRemove);
            CreditCards.Add(creditCardToAdd);
            RepositoryFacade.Instance.CreditCardDataAccess.Modify(creditCardToAdd);
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

        private void CheckIfCreditCardExists(CreditCard creditCard)
        {
            if (!CreditCards.Exists(creditCardInList => creditCardInList.Equals(creditCard)))
            {
                throw new CreditCardNotFoundException();
            }
        }

        private void AddCreditCardToListAndDB(CreditCard creditcardToAdd)
        {
            creditcardToAdd.UserCreditCard = this;
            CreditCards.Add(creditcardToAdd);
            RepositoryFacade.Instance.CreditCardDataAccess.Add(creditcardToAdd);
        }
    }
}
