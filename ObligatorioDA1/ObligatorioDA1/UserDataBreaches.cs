using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.DataBreachesTranslator;

namespace Domain
{
    public class UserDataBreaches
    {
        public User User { get; set; }

        private const int CREDIT_CARD_MAX_LENGTH_WITH_SPACES = 19;
        private const int FIRST_CREDIT_CARD_SPACE_POSITION = 4;
        private const int SECOND_CREDIT_CARD_SPACE_POSITION = 9;
        private const int THIRD_CREDIT_CARD_SPACE_POSITION = 14;

        private User _theUser;
        public int UserDataBreachesID { get; set; }

        public UserDataBreaches()
        {

        }
        public UserDataBreaches(User theUser)
        {
            _theUser = theUser;
        }

        public DataBreaches CheckDataBreaches(string inputBreaches, ITranslator translator)
        {
            string[] translatedBreaches = translator.Translate(inputBreaches);

            DataBreaches breach = new DataBreaches()
            {
                CreditCardsBreaches = new List<CreditCard>(),
                PasswordBreaches = new List<Password>(),
            };

            for (int i = 0; i != translatedBreaches.Length; i++)
            {
                BuildDataBreachStructure(translatedBreaches[i], breach);
            }

            return breach;
        }

        private void BuildDataBreachStructure(string aBreach, DataBreaches breach)
        {
            if (IsCreditCard(aBreach))
            {
                aBreach = CreditCardFormatTransformer(aBreach);
                CheckDataBreachesCreditCard(aBreach, breach);
            }
            else
            {
                CheckDataBreachesPassword(aBreach, breach);
            }
        }

        private void CheckDataBreachesCreditCard(string inputBreach, DataBreaches breach)
        {
            try
            {
                CreditCard creditCardBreached = _theUser.UserCreditCards.GetCreditCard(inputBreach);

                if (!breach.CreditCardsBreaches.Any(pass => pass.Equals(creditCardBreached)))
                {
                    breach.CreditCardsBreaches.Add(creditCardBreached);
                }
            }
            catch (CreditCardNotFoundException ex)
            {

            }
        }

        private void CheckDataBreachesPassword(string inputBreach, DataBreaches breach)
        {
            try
            {
                List<Password> passwordBreached = _theUser.UserPasswords.GetPasswordsByPasswordString(inputBreach);

                foreach(Password password in passwordBreached)
                {
                    if(!breach.PasswordBreaches.Any(pass => pass.Equals(password)))
                    {
                        breach.PasswordBreaches.Add(password);
                    }
                }
            }
            catch (PasswordNotFoundException ex)
            {

            }
        }

        private bool IsCreditCard(string inputBreach)
        {
            bool isCreditCard = false;
            if (inputBreach.Length == CREDIT_CARD_MAX_LENGTH_WITH_SPACES &&
                                    FollowsCreditCardPattern(inputBreach))
            {
                isCreditCard = true;
            }
            return isCreditCard;
        }

        private bool FollowsCreditCardPattern(string inputBreach)
        {
            bool followsPattern = true;

            for(int i = 0; i != CREDIT_CARD_MAX_LENGTH_WITH_SPACES && followsPattern; i++)
            {
                bool isDigitCharacter = inputBreach[i] < '0' || inputBreach[i] > '9';

                if (isDigitCharacter)
                {
                    bool atSpacePosition = i == FIRST_CREDIT_CARD_SPACE_POSITION || 
                                           i == SECOND_CREDIT_CARD_SPACE_POSITION || 
                                           i == THIRD_CREDIT_CARD_SPACE_POSITION;

                    bool isSpaceCharacter = inputBreach[i] == (' ');

                    if (!atSpacePosition && !isSpaceCharacter)
                    {
                        followsPattern = false;
                    }
                }
            }

            return followsPattern;
        }

        private string CreditCardFormatTransformer(string inputCreditCard)
        {
            string outputCreditCard = inputCreditCard.Substring(0, 4) + inputCreditCard.Substring(FIRST_CREDIT_CARD_SPACE_POSITION + 1, 4) +
                                      inputCreditCard.Substring(SECOND_CREDIT_CARD_SPACE_POSITION + 1, 4) + inputCreditCard.Substring(THIRD_CREDIT_CARD_SPACE_POSITION + 1, 4);
            return outputCreditCard;
        }
    }
}
