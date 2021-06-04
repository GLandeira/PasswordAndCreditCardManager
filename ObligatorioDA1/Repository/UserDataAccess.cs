using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public class UserDataAccess : IDataAccess<User>
    {
        public void Add(User entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.Users.Add(entity);
                context.SaveChanges();
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
                IEnumerable<User> allUsers = context.Users.ToList();
                return allUsers;
            }
        }

        public void Modify(User entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                // Ver si esta bien
                var valueInDB = context.Users.FirstOrDefault(user => user.UserID == entity.UserID);
                valueInDB.Name = entity.Name;
                valueInDB.MainPassword = entity.MainPassword;

                //context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
