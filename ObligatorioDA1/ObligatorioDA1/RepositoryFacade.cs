using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RepositoryFacade
    {
        private static RepositoryFacade _instance;
        public static RepositoryFacade Instance
        {
            get
            {
                return _instance;
            }
        }

        public RepositoryFacade(DataAccessDTO dataAccess)
        {
            if (_instance == null)
            {
                _instance = this;
            }

            UserDataAccess = dataAccess.UserDataAccess;
            CategoryDataAccess = dataAccess.CategoryDataAccess;
            CreditCardDataAccess = dataAccess.CreditCardDataAccess;
            PasswordDataAccess = dataAccess.PasswordDataAccess;
            DataBreachDataAccess = dataAccess.DataBreachDataAccess;
        }

        public IDataAccess<User> UserDataAccess { get; set; }
        public IDataAccess<Category> CategoryDataAccess { get; set; }
        public IDataAccess<CreditCard> CreditCardDataAccess { get; set; }
        public IDataAccess<Password> PasswordDataAccess { get; set; }
        public IDataAccess<DataBreach> DataBreachDataAccess { get; set; }
    }
}
