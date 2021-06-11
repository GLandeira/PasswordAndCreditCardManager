using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public class PasswordDataAccess : IDataAccess<Password>
    {
        public int Add(Password entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.UserPasswords.Attach(entity.UserPassword);
                Password addedPassword = context.Passwords.Add(entity);
                context.SaveChanges();

                return addedPassword.PasswordID;
            }
        }

        public void Delete(Password entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                var PasswordFound = context.Passwords.FirstOrDefault(password => password.PasswordID == entity.PasswordID);
                context.Passwords.Remove(PasswordFound);
                context.SaveChanges();
            }
        }

        public Password Get(int id)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                Password PasswordFound = context.Passwords.FirstOrDefault(password => password.PasswordID == id);
                return PasswordFound;
            }
        }

        public IEnumerable<Password> GetAll()
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                IEnumerable<Password> allCategories = context.Passwords.ToList();
                return allCategories;
            }
        }

        public void Modify(Password entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                var valueInDB = context.Passwords.FirstOrDefault(password => password.PasswordID == entity.PasswordID);
                valueInDB.Category = entity.Category;
                valueInDB.PasswordString = entity.PasswordString;
                valueInDB.Site = entity.Site;
                valueInDB.Username = entity.Username;
                valueInDB.LastModification = entity.LastModification;
                valueInDB.SecurityLevel = entity.SecurityLevel;
                valueInDB.Notes = entity.Notes;

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
