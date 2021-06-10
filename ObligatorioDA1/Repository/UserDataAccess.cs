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
                context.Entry(entity).State = EntityState.Deleted;

                //var valueInDB = context.Users.FirstOrDefault(user => user.UserID == entity.UserID);
                //context.Users.Remove(valueInDB);

                context.SaveChanges();
            }
        }

        public User Get(int id)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                User UsersFound = context.Users
                                         .Include(u => u.UserCategories.Categories)
                                         .Include(u => u.UserPasswords.Passwords)
                                         .Include(u => u.UserCreditCards.CreditCards)
                                         .Include(u => u.UserDataBreaches).FirstOrDefault(user => user.UserID == id);
                return UsersFound;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (DomainDBContext context = new DomainDBContext())
            {

                IEnumerable<User> allUsers = context.Users.ToList();

                return allUsers;
            }
        }

        public void Modify(User entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                var valueInDB = context.Users.FirstOrDefault(user => user.UserID == entity.UserID);
                valueInDB.Name = entity.Name;
                valueInDB.MainPassword = entity.MainPassword;

                context.SaveChanges();
            }
        }

        public void Clear()
        {
            foreach (var record in GetAll())
            {
                Delete(record);
            }
        }
    }
}
