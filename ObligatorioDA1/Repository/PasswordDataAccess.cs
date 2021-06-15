using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity;

namespace Repository
{
    public class PasswordDataAccess : IDataAccess<Password>
    {
        public int Add(Password entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.UserPasswords.Attach(entity.UserPassword);
                context.Categories.Attach(entity.Category);

                Password addedPassword = context.Passwords.Add(entity);
                context.SaveChanges();

                return addedPassword.PasswordID;
            }
        }

        public void Delete(Password entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.PasswordHistory.Where(p => p.Password.PasswordID == entity.PasswordID).Load();
                var PasswordFound = context.Passwords.FirstOrDefault(password => password.PasswordID == entity.PasswordID);
                context.Passwords.Remove(PasswordFound);
                context.SaveChanges();
            }
        }

        public Password Get(int id)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                Password PasswordFound = context.Passwords
                                                    .Include(u => u.UserPassword)
                                                    .Include(c => c.Category)
                                                    .Include(u => u.UsersSharedWith).FirstOrDefault(password => password.PasswordID == id);

                return PasswordFound;
            }
        }

        public IEnumerable<Password> GetAll()
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                IEnumerable<Password> allPasswords = context.Passwords.ToList();
                return allPasswords;
            }
        }

        public void Modify(Password entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.Categories.Attach(entity.Category);
                foreach (User u in entity.UsersSharedWith)
                {
                    context.Users.Attach(u);
                }

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
