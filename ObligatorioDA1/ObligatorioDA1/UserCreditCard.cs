using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserCreditCard
    {
        public List<CreditCard> creditCards { get; set; }

        public UserCreditCard()
        {
            creditCards = new List<CreditCard>();
        }
        public void AddCreditCard(string cName, CardTypes cType, string cNumber, string cSecurityCode, DateTime cValidDue, Category cCategory, string cNotes)
        {
            throw new NotImplementedException();
        }

    }


}
