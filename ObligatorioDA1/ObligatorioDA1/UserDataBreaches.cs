using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain
{
    public class UserDataBreaches
    {
        private User _theUser;

        public UserDataBreaches(User theUser)
        {
            _theUser = theUser;
        }

        public DataBreaches CheckDataBreaches(String [] inputBreaches)
        {
            DataBreaches breach = new DataBreaches()
            {
                CreditCardsBreaches = new List<CreditCard>(),
                PasswordBreaches = new List<Password>(),
            };

            for (int i = 0; i != inputBreaches.Length; i++)
            {
                if (IsCreditCard(inputBreaches[i]))
                {
                    inputBreaches[i] = CreditCardFormatTransformer(inputBreaches[i]);
                    CheckDataBreachesCreditCard(inputBreaches[i], breach);
                }
                else
                {
                    CheckDataBreachesPassword(inputBreaches[i], breach);
                }
            }
            return breach;
        }

        private void CheckDataBreachesCreditCard(String inputBreach, DataBreaches breach)
        {
            try
            {
                CreditCard creditCardBreached = _theUser.UserCreditCards.GetCreditCard(inputBreach);
                breach.CreditCardsBreaches.Add(creditCardBreached);
            }
            catch (CreditCardNotFoundException ex)
            {
            }
        }

        private void CheckDataBreachesPassword(String inputBreach, DataBreaches breach)
        {
            try
            {
                List<Password> passwordBreached = _theUser.UserPasswords.GetPasswordsByPasswordString(inputBreach);
                foreach(Password password in passwordBreached)
                {
                    breach.PasswordBreaches.Add(password);
                }
            }
            catch (PasswordNotFoundException ex)
            {
            }
        }

        //input dataBreaches CreditCards = "XXXX XXXX XXXX XXXX"
        private bool IsCreditCard(String inputBreach)
        {
            bool isCreditCard = false;
            if (inputBreach.Length == 19 &&
                                    FollowsCreditCardPattern(inputBreach))
            {
                isCreditCard = true;
            }
            return isCreditCard;
        }

        private bool FollowsCreditCardPattern(String inputBreach)
        {
            bool followsPattern = true;
            for(int i=0; i != 19 && followsPattern != false; i++)
            {
                if ((inputBreach[i] < '0' || inputBreach[i] > '9'))
                {
                    if (!(i == 4 || i == 9 || i == 14) && !(inputBreach[i] == (' ')))
                    {
                        followsPattern = false;
                    }
                }
            }
            return followsPattern;
        }

        private string CreditCardFormatTransformer(string inputCreditCard)
        {
            string outputCreditCard = inputCreditCard.Substring(0,4) + inputCreditCard.Substring(5, 4) +
                                      inputCreditCard.Substring(10, 4) + inputCreditCard.Substring(15, 4);
            return outputCreditCard;
        }
    }
}
