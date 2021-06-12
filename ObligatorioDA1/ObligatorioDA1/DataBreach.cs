using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{ 
    public class DataBreach
    {
        public int DataBreachID { get; set; }
        public DateTime Date { get; set; }
        public List<CreditCard> CreditCardBreaches { get; set;}
        public List<PasswordHistory> PasswordBreaches { get; set; }

        public DataBreach()
        {

        }

        public override bool Equals(object obj)
        {
            DataBreach incomingDataBreach = (DataBreach)obj;
            DateTime incomingDate = incomingDataBreach.Date;
            bool areEqual = incomingDate.Year == Date.Year
                         && incomingDate.Month == Date.Month
                         && incomingDate.Day == Date.Day
                         && incomingDate.Hour == Date.Hour;
                               

            return areEqual;
        }
    }
}