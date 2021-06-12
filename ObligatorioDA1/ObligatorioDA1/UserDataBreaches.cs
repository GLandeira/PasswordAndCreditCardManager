﻿using System;
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
            bool alreadyThere = DataBreaches.Any(db => db.Equals(dataBreach));

            if (alreadyThere)
            {
                DataBreach dataBreachInMemory = DataBreaches.FirstOrDefault(db => db.Equals(dataBreach));

                foreach (PasswordHistory passwordHistory in dataBreach.PasswordBreaches)
                {
                    bool passwordNotPresent = !dataBreachInMemory.PasswordBreaches.Any(pb => pb.Equals(passwordHistory));
                    if (passwordNotPresent)
                    {
                        dataBreachInMemory.PasswordBreaches.Add(passwordHistory);
                    }
                }

                return;
            }

            DataBreaches.Add(dataBreach);
        }

        public DataBreach GetDataBreach(DateTime fecha)
        {
            DataBreach searcherDataBreach = new DataBreach();
            searcherDataBreach.Date = fecha;

            return DataBreaches.FirstOrDefault(db => db.Equals(searcherDataBreach));
        }
    }
}
