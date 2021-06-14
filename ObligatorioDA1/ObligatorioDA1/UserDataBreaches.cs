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
        }

        public UserDataBreaches(User user)
        {
            DataBreachesChecker = new DataBreachesChecker(user);
        }

        public void AddDataBreach(DataBreach dataBreach)
        {
            // Verificaciones? Algo? Se identifica por fecha y hora.
            // Si el databreach es en la misma hora, hay que fijarse si hay contras/creditcards nuevas
            // Si hay se agregan al databreach original.
            // Si no hay, no se hace nada
            dataBreach.Date = DateTime.Now;

            bool dataBreachOnSameDate = DataBreaches.Any(db => db.Equals(dataBreach));

            if (dataBreachOnSameDate)
            {
                DataBreach dataBreachInMemory = DataBreaches.FirstOrDefault(db => db.Equals(dataBreach));

                DataBreach newDataBreach = GenerateDataBreachWithNewBreaches(dataBreach, dataBreachInMemory);

                dataBreachInMemory.CreditCardBreaches.AddRange(newDataBreach.CreditCardBreaches);
                dataBreachInMemory.PasswordBreaches.AddRange(newDataBreach.PasswordBreaches);

                // Dejar pasar solamente las nuevas al Modify

                RepositoryFacade.Instance.DataBreachDataAccess.Modify(newDataBreach);

                return;
            }

            DataBreaches.Add(dataBreach);
            RepositoryFacade.Instance.DataBreachDataAccess.Add(dataBreach);
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
                bool passwordNotPresent = !dataBreachInMemory.PasswordBreaches.Any(pb => pb.Equals(passwordHistory));
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
