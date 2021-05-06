using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //try
            //{
            //    CreditCard creditCardBreached = _theUser.UserCreditCards.GetCreditCard();
            //    breach.CreditCardsBreaches.Add(creditCardBreached);
            //}
            //catch ()
            //{

            //}
        }

        private void CheckDataBreachesPassword(String inputBreach, DataBreaches breach)
        {

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
            for(int i=0; i != 19; i++)
            {
                if((i==4 || i==9 || i == 14) && !inputBreach[i].Equals(" "))
                {
                    followsPattern = false;
                }
                else if ((inputBreach[i] < '0' || inputBreach[i] > '9'))
                {
                    followsPattern = false;
                }
            }
            return followsPattern;
        }
    }
}
