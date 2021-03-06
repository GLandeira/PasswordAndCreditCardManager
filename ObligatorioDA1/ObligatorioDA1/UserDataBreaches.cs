using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserDataBreaches
    {
        public int UserDataBreachesID { get; set; }
        public List<DataBreach> DataBreaches { get; set; }
        public DataBreachesChecker DataBreachesChecker;

        public UserDataBreaches()
        {
            DataBreaches = new List<DataBreach>();
            DataBreachesChecker = new DataBreachesChecker(this);
        }

        public void AddDataBreach(DataBreach dataBreach)
        {
            
            if (!(dataBreach.CreditCardBreaches.Count() + dataBreach.PasswordBreaches.Count() == 0))
            {
                dataBreach.Date = DateTime.Now;

                bool dataBreachOnSameDate = DataBreaches.Any(db => db.Equals(dataBreach));

                if (dataBreachOnSameDate)
                {
                    DataBreach dataBreachInMemory = DataBreaches.FirstOrDefault(db => db.Equals(dataBreach));

                    DataBreach newDataBreach = GenerateDataBreachWithNewBreaches(dataBreach, dataBreachInMemory);

                    dataBreachInMemory.CreditCardBreaches.AddRange(newDataBreach.CreditCardBreaches);
                    dataBreachInMemory.PasswordBreaches.AddRange(newDataBreach.PasswordBreaches);

                    RepositoryFacade.Instance.DataBreachDataAccess.Modify(newDataBreach);

                    return;
                }
                DataBreaches.Add(dataBreach);
                RepositoryFacade.Instance.DataBreachDataAccess.Add(dataBreach);
            }
        }

        public DataBreach GetDataBreach(DateTime fecha)
        {
            DataBreach searcherDataBreach = new DataBreach();
            searcherDataBreach.Date = fecha;
            int id = DataBreaches.FirstOrDefault(db => db.Equals(searcherDataBreach)).DataBreachID;

            return RepositoryFacade.Instance.DataBreachDataAccess.Get(id);
        }

        private DataBreach GenerateDataBreachWithNewBreaches(DataBreach entryBreach, DataBreach dataBreachInMemory)
        {
            DataBreach newBreachesOnly = new DataBreach(this);
            newBreachesOnly.DataBreachID = dataBreachInMemory.DataBreachID;
            newBreachesOnly.Date = DateTime.Now;

            newBreachesOnly.PasswordBreaches = GenerateListOfNewPasswordBreaches(entryBreach, dataBreachInMemory);
            newBreachesOnly.CreditCardBreaches = GenerateListOfNewCreditCardBreaches(entryBreach, dataBreachInMemory);

            return newBreachesOnly;
        }

        private List<PasswordHistory> GenerateListOfNewPasswordBreaches(DataBreach entryDataBreach, DataBreach dataBreachInMemory)
        {
            List<PasswordHistory> newPasswordHistories = new List<PasswordHistory>();

            foreach (PasswordHistory passwordHistory in entryDataBreach.PasswordBreaches)
            {
                bool passwordNotPresent = !dataBreachInMemory.PasswordBreaches.Any(pb => pb.AbsoluteEquals(passwordHistory));
                if (passwordNotPresent)
                {
                    newPasswordHistories.Add(passwordHistory);
                }
            }

            return newPasswordHistories;
        }
        
        private List<CreditCard> GenerateListOfNewCreditCardBreaches(DataBreach entryDataBreach, DataBreach dataBreachInMemory)
        {
            List<CreditCard> newCreditCards = new List<CreditCard>();

            foreach (CreditCard creditCard in entryDataBreach.CreditCardBreaches)
            {
                bool creditCardNotPresent = !dataBreachInMemory.CreditCardBreaches.Any(ccb => ccb.Equals(creditCard));
                if (creditCardNotPresent)
                {
                    newCreditCards.Add(creditCard);
                }
            }

            return newCreditCards;
        }
    }
}
