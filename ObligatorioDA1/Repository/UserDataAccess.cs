using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;

namespace Repository
{
    public class UserDataAccess : IDataAccess<User>
    {
        public int Add(User entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {

                User addedUser = context.Users.Add(entity);
                context.SaveChanges();
                return addedUser.UserID;
            }
        }

        public void Delete(User entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.Users.Remove(entity);
                context.SaveChanges();
            }
        }

        public User Get(int id)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                User UsersFound = context.Users.FirstOrDefault(user => user.UserID == id);
                return UsersFound;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                IEnumerable<User> allUsers = context.Users.Include(u => u.UserCreditCards).Include(u => u.UserPasswords).Include(u => u.UserCategories).Include(u => u.UserDataBreaches).ToList();

                return allUsers;
            }
        }

        public void Modify(User entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                //context.UserCreditCards.Attach(entity.UserCreditCards);
                //context.UserPasswords.Attach(entity.UserPasswords);
                //context.UserDataBreaches.Attach(entity.UserDataBreaches);
                //context.UserCategories.Attach(entity.UserCategories);

                context.Entry(entity).State = EntityState.Modified;
                // Ver si esta bien
                var valueInDB = context.Users.FirstOrDefault(user => user.UserID == entity.UserID);
                valueInDB.Name = entity.Name;
                valueInDB.MainPassword = entity.MainPassword;



                //context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Clear()
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
            }
        }
    }
}
