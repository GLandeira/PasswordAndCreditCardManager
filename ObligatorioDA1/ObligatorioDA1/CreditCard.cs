using System;


namespace Domain
{
    public class CreditCard
    {
        public int CreditCardID { get; set; }
        public string Name { get; set; }
        public CardTypes Type { get; set; }
        public string Number { get; set; }
        public string SecurityCode { get; set; }
        public DateTime ValidDue { get; set; }
        public Category Category { get; set; }
        public string Notes { get; set; }
        public UserCreditCard UserCreditCard { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return Number == ((CreditCard)obj).Number;
        }

        public bool AbsoluteEquals(CreditCard creditcard)
        {
            bool equalName = this.Name == creditcard.Name;
            bool equalType = this.Type == creditcard.Type;
            bool equalNumber = this.Number == creditcard.Number;
            bool equalSecurityCode = this.SecurityCode == creditcard.SecurityCode;
            bool equalValidDue = this.ValidDue == creditcard.ValidDue;
            bool equalCategory = this.Category.Equals(creditcard.Category);
            bool equalNotes = this.Notes == creditcard.Notes;

            return (equalName && equalType && equalNumber && equalSecurityCode && equalValidDue && equalCategory && equalNotes);


        }
        public override string ToString()
        {
            return "[" + Name + "][" + Type.ToString() + "][" + Number + "]";
        }
    }

}
