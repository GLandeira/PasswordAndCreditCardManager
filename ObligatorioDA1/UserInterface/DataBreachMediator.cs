using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.DataBreachesTranslator;

namespace UserInterface
{
    public class DataBreachMediator
    {
        public DataBreachesChecker DataBreachChecker { get; set; }
        public UserDataBreaches UserDataBreaches { get; set; }
        public DataBreachesController DataBreachesUIController { get; set; }

        public DataBreachMediator(DataBreachesController uiController, UserDataBreaches userDataBreaches)
        {
            DataBreachesUIController = uiController;
            UserDataBreaches = userDataBreaches;
            DataBreachChecker = UserDataBreaches.DataBreachesChecker;
        }

        public void CheckAndRegisterDataBreach(string entry, ITranslator translator)
        {
            DataBreach theDataBreach = DataBreachChecker.CheckDataBreaches(entry, translator);

            UserDataBreaches.AddDataBreach(theDataBreach);

            DataBreachesUIController.DataBreachModalOpening(theDataBreach);
        }
    }
}
