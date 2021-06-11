using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain
{
    public class UserCategory
    {
        public int UserCategoryID { get; set; }
        public List<Category> Categories { get; set; }
        public const string SHARED_PASSWORD_CATEGORY_NAME = "Shared With Me";
        public static Category SHARED_WITH_ME_CATEGORY = new Category(SHARED_PASSWORD_CATEGORY_NAME);

        public UserCategory()
        {
            
        }

        public void AddCategory(Category aCategory)
        {
            Verifier.VerifyCategory(aCategory);

            if (Categories.Any(cat => cat.Equals(aCategory)))
            {
                throw new CategoryAlreadyExistsException();
            }

            AddCategoryToListAndDB(aCategory);
        }

        public Category GetACategory(string category)
        {
            try
            {
                Category foundCategory = Categories.First(cat => cat.Name == category);

                return foundCategory;
            }
            catch (InvalidOperationException isEmptyOrNotPresent)
            {
                throw new CategoryNotFoundException();
            }
            catch (ArgumentNullException isNull)
            {
                throw new CategoryNotFoundException();
            }
        }

        public void AddSharedWithMeCategoryToDB()
        {
            Categories = new List<Category>();
            AddCategoryToListAndDB(SHARED_WITH_ME_CATEGORY);
        }

        public void ModifyCategory(Category categoryToModify, Category newCategory)
        {
            Verifier.VerifyCategory(newCategory);

            try
            {
                Category foundCategory = Categories.First(cat => cat.Equals(categoryToModify));
                Categories.Remove(foundCategory);
                Categories.Add(newCategory);
                RepositoryFacade.Instance.CategoryDataAccess.Modify(newCategory);
            }
            catch (InvalidOperationException isEmptyOrNotPresent)
            {
                throw new CategoryNotFoundException();
            }
            catch (ArgumentNullException isNull)
            {
                throw new CategoryNotFoundException();
            }
        }

        private void AddCategoryToListAndDB(Category categoryToAdd)
        {
            categoryToAdd.UserCategory = this;
            Categories.Add(categoryToAdd);
            RepositoryFacade.Instance.CategoryDataAccess.Add(categoryToAdd);
        }
    }
}
