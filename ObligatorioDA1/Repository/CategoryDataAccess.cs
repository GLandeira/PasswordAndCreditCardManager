using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public class CategoriesDataAccess : IDataAccess<Category>
    {
        public void Add(Category entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.Categories.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Category entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                context.Categories.Remove(entity);
                context.SaveChanges();
            }
        }

        public Category Get(int id)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                Category CategoriesFound = context.Categories.FirstOrDefault(Categories => Categories.CategoryID == id);
                return CategoriesFound;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                IEnumerable<Category> allCategories = context.Categories.ToList();
                return allCategories;
            }
        }

        public void Modify(Category entity)
        {
            using (DomainDBContext context = new DomainDBContext())
            {
                // Ver si esta bien
                var valueInDB = context.Categories.FirstOrDefault(Categories => Categories.CategoryID == entity.CategoryID);
                valueInDB.Name = entity.Name;

                //context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}