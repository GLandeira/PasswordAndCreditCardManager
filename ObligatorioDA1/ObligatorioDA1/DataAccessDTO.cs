using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public struct DataAccessDTO
    {
        public IDataAccess<User> UserDataAccess;
        public IDataAccess<Category> CategoryDataAccess;
        public IDataAccess<CreditCard> CreditCardDataAccess;
        public IDataAccess<Password> PasswordDataAccess;
    }
}
