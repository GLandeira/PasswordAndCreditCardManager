using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity;

namespace Repository
{
    public class CreditCardDataAccess : IDataAccess<CreditCard>
    {
        public int Add(CreditCard entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.UserCreditCards.Attach(entity.UserCreditCard);
                context.Categories.Attach(entity.Category);
                CreditCard addedCreditCard = context.CreditCards.Add(entity);
                context.SaveChanges();

                return addedCreditCard.CreditCardID;
               
            }
        }

        public void Delete(CreditCard entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                var creditcardFound = context.CreditCards.FirstOrDefault(c => c.CreditCardID == entity.CreditCardID);
                context.CreditCards.Remove(creditcardFound);
                context.SaveChanges();


            }
        }

        public CreditCard Get(int id)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                CreditCard CreditcardFound = context.CreditCards.Include(c => c.Category.UserCategory).Include(c => c.UserCreditCard).FirstOrDefault(Creditcards => Creditcards.CreditCardID == id);
                return CreditcardFound;
            }
        }

        public IEnumerable<CreditCard> GetAll()
        {
            using (DomainDBContext context = new DomainDBContext())
            {

                IEnumerable<CreditCard> allCreditCards = context.CreditCards.Include(c => c.Category).ToList();
                return allCreditCards;
            }
        }

        public void Modify(CreditCard entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {

                context.Categories.Attach(entity.Category);
                context.Entry(entity).State = EntityState.Modified;

                var valueInDB = context.CreditCards.FirstOrDefault(creditCard => creditCard.CreditCardID == entity.CreditCardID);
                valueInDB.Category = entity.Category;
                valueInDB.Name = entity.Name;
                valueInDB.Notes = entity.Notes;
                valueInDB.Number = entity.Number;
                valueInDB.SecurityCode = entity.SecurityCode;
                valueInDB.Type = entity.Type;
                valueInDB.ValidDue = entity.ValidDue;

                
                context.SaveChanges();
            }
        }
    }
}
