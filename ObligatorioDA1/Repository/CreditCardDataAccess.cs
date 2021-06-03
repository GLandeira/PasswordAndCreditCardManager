using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public class CreditCardDataAccess : IDataAccess<CreditCard>
    {
        public void Add(CreditCard entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.CreditCards.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(CreditCard entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.CreditCards.Remove(entity);
                context.SaveChanges();
            }
        }

        public CreditCard Get(int id)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                CreditCard creditCardFound = context.CreditCards.FirstOrDefault(creditCard => creditCard.CreditCardID == id);
                return creditCardFound;
            }
        }

        public IEnumerable<CreditCard> GetAll()
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                IEnumerable<CreditCard> allCreditCards = context.CreditCards.ToList();
                return allCreditCards;
            }
        }

        public void Modify(CreditCard entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                // Ver si esta bien
                var valueInDB = context.CreditCards.FirstOrDefault(creditCard => creditCard.CreditCardID == entity.CreditCardID);
                valueInDB.Category = entity.Category;
                valueInDB.Name = entity.Name;
                valueInDB.Notes = entity.Notes;
                valueInDB.Number = entity.Number;
                valueInDB.SecurityCode = entity.SecurityCode;
                valueInDB.Type = entity.Type;
                valueInDB.ValidDue = entity.ValidDue;

                //context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
