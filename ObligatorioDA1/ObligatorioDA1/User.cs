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
        public List<Category> Categories { get; set; }

        private const int MAXIMUM_CHARACTERS_CATEGORY_NAME = 15;
        private const int MINIMUM_CHARACTERS_CATEGORY_NAME = 3;
        public const string SHARED_PASSWORD_CATEGORY_NAME = "Shared With Me";

        public static Category SHARED_WITH_ME_CATEGORY = new Category(SHARED_PASSWORD_CATEGORY_NAME);

        public User()
        {
            Categories = new List<Category>();
            Categories.Add(SHARED_WITH_ME_CATEGORY);
            UserPasswords = new UserPassword();
            UserCreditCards = new UserCreditCard();
        }

        public User(string name, string mainPassword)
        {
            Categories = new List<Category>();
            UserPasswords = new UserPassword();
            UserCreditCards = new UserCreditCard();
            Name = name;
            MainPassword = mainPassword;
        }

        public void AddCategory(Category aCategory)
        {
            if (aCategory.Name.Length > MAXIMUM_CHARACTERS_CATEGORY_NAME)
            {
                throw new LongCategoryNameException();
            }

            if (aCategory.Name.Length < MINIMUM_CHARACTERS_CATEGORY_NAME)
            {
                throw new ShortCategoryNameException();
            }

            Categories.Add(aCategory);
        }

        public Category GetACategory(string nameToTest)
        {
            try
            {
                Category foundCategory = Categories.First(cat => cat.Name == nameToTest);

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

        public void ModifyCategory(Category categoryToModify, string newName)
        {
            if (newName.Length > MAXIMUM_CHARACTERS_CATEGORY_NAME)
            {
                throw new LongCategoryNameException();
            }

            if (newName.Length < MINIMUM_CHARACTERS_CATEGORY_NAME)
            {
                throw new ShortCategoryNameException();
            }

            // Find category in list
            try
            {
                Categories.First(cat => cat.Equals(categoryToModify)).Name = newName;
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

        public override bool Equals(object obj)
        {
            User theUser = (User)obj;
            return theUser.Name == this.Name;
        }
    }
}
