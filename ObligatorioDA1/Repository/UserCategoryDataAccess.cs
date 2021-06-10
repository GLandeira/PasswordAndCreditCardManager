using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;

namespace Repository
{
    public class UserCategoryDataAccess : IDataAccess<UserCategory>
    {
        public int Add(UserCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserCategory entity)
        {
            throw new NotImplementedException();
        }

        public UserCategory Get(int id)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                UserCategory userCategoryInDB = context.UserCategories.Include(uc => uc.Categories).FirstOrDefault(uc => uc.UserCategoryID == id);
                return userCategoryInDB;
            }
        }

        public IEnumerable<UserCategory> GetAll()
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                IEnumerable<UserCategory> allUserCategories = context.UserCategories.Include(uc => uc.Categories).ToList();
                return allUserCategories;
            }
        }

        public void Modify(UserCategory entity)
        {
            using(DomainDBContext context = new DomainDBContext())
            {
                UserCategory userCategoryInDB = context.UserCategories.FirstOrDefault(uc => uc.UserCategoryID == entity.UserCategoryID);
                userCategoryInDB.Categories = entity.Categories;

                context.SaveChanges();
            }
        }
    }
}
