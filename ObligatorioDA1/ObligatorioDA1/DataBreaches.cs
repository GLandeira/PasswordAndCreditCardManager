using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{ 
    public struct DataBreaches
    {
        public List<CreditCard> CreditCardsBreaches { get; set;}
        public List<Password> PasswordBreaches { get; set; }
    }
}