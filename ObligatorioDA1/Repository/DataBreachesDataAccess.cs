using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity;

namespace Repository
{
    public class DataBreachesDataAccess : IDataAccess<DataBreach>
    {
        public int Add(DataBreach entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.UserDataBreaches.Attach(entity.UserDataBreaches);

                foreach(CreditCard c in entity.CreditCardBreaches)
                {
                    context.CreditCards.Attach(c);
                    context.Categories.Attach(c.Category);
                }

                foreach (PasswordHistory p in entity.PasswordBreaches)
                {
                    context.Passwords.Attach(p.Password);
                    context.Categories.Attach(p.Password.Category);
                }

                DataBreach addedDataBreach = context.DataBreaches.Add(entity);
                context.SaveChanges();

                return addedDataBreach.DataBreachID;
            }
        }

        public void Delete(DataBreach entity)
        {
            throw new NotImplementedException();
        }

        public DataBreach Get(int id)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                DataBreach dataBreachFound = context.DataBreaches
                                                    .Include(db => db.PasswordBreaches.Select(ph => ph.Password.Category))
                                                    .Include(db => db.CreditCardBreaches.Select(c => c.Category))
                                                    .FirstOrDefault(DataBreach => DataBreach.DataBreachID == id);

                return dataBreachFound;
            }
        }

        public IEnumerable<DataBreach> GetAll()
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                IEnumerable<DataBreach> allDataBreaches = context.DataBreaches.ToList();
                return allDataBreaches;
            }
        }

        public void Modify(DataBreach entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                var valueInDB = context.DataBreaches.FirstOrDefault(dataBreach => dataBreach.DataBreachID == entity.DataBreachID);

                foreach (CreditCard c in entity.CreditCardBreaches)
                {
                    context.CreditCards.Attach(c);
                    context.Categories.Attach(c.Category);
                }

                foreach (PasswordHistory p in entity.PasswordBreaches)
                {
                    if (!valueInDB.PasswordBreaches.Any(pb => pb.PasswordHistoryID == p.PasswordHistoryID))
                    {
                        //context.Entry(p).State = EntityState.Added;
                    }

                    //context.PasswordHistory.Attach(p);
                    //context.DataBreaches.Attach(p.DataBreachOrigin);
                    context.Passwords.Attach(p.Password);
                    context.Categories.Attach(p.Password.Category);
                }

                
                valueInDB.CreditCardBreaches = entity.CreditCardBreaches;
                valueInDB.PasswordBreaches = entity.PasswordBreaches;

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
