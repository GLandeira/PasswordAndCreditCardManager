using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain
{
    public class User
    {
        public string Name { get; set; }
        public string MainPassword { get; set; }
        public UserPassword UserPasswords { get; private set; }
        public UserCreditCard UserCreditCards { get; private set; }
        public UserDataBreaches UserDataBreaches { get; private set; }
        public List<Category> Categories { get; set; }
        public const string SHARED_PASSWORD_CATEGORY_NAME = "Shared With Me";
        public static Category SHARED_WITH_ME_CATEGORY = new Category(SHARED_PASSWORD_CATEGORY_NAME);

        public User(UserManager userManager)
        {
            Categories = new List<Category>();
            UserPasswords = new UserPassword(userManager);
            UserCreditCards = new UserCreditCard();
            UserDataBreaches = new UserDataBreaches(this);
            Categories.Add(SHARED_WITH_ME_CATEGORY);
        }

        public User(string name, string mainPassword, UserManager userManager)
        {
            Categories = new List<Category>();
            UserPasswords = new UserPassword(userManager);
            UserCreditCards = new UserCreditCard();
            UserDataBreaches = new UserDataBreaches(this);
            Name = name;
            MainPassword = mainPassword;
            Categories.Add(SHARED_WITH_ME_CATEGORY);
        }

        public void AddCategory(Category aCategory)
        {
            Verifier.VerifyCategory(aCategory);

            if(Categories.Any(cat => cat.Equals(aCategory)))
            {
                throw new CategoryAlreadyExistsException();
            }

            Categories.Add(aCategory);
        }

        public Category GetACategory(string category)
        {
            try
            {
                Category foundCategory = Categories.First(cat => cat.Name == category);

                return foundCategory;
            }
            catch(InvalidOperationException isEmptyOrNotPresent)
            {
                throw new CategoryNotFoundException();
            }
            catch(ArgumentNullException isNull)
            {
                throw new CategoryNotFoundException();
            }
        }

        public void ModifyCategory(Category categoryToModify, Category newCategory)
        {
            Verifier.VerifyCategory(newCategory);

            try
            {
                Category a = Categories.First(cat => cat.Equals(categoryToModify));
                Categories.Remove(a);
                Categories.Add(newCategory);

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

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            User theUser = (User)obj;
            return theUser.Name == this.Name;
        }
    }
}
