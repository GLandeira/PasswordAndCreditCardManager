using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CreditCard
    {
        private string _name;
        private CardTypes _type;
        private string _number;
        private string _securityCode;
        private DateTime _validDue;
        private Category _category;
        private string _notes;
        private bool _isBreached = false;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public CardTypes Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }
        public string SecurityCode
        {
            get
            {
                return _securityCode;
            }
            set
            {
                _securityCode = value;
            }
        }
        public DateTime ValidDue
        {
            get
            {
                return _validDue;
            }
            set
            {
                _validDue = value;
            }
        }
        public Category Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }
        public bool IsBreached
        {
            get
            {
                return _isBreached;
            }
            set
            {
                _isBreached = value;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.Number == ((CreditCard)obj).Number;
        }
    }



}
