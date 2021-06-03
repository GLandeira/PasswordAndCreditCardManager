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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return Number == ((CreditCard)obj).Number;
        }

        public override string ToString()
        {
            return "[" + Name + "][" + Type.ToString() + "][" + Number + "]";
        }
    }

}
