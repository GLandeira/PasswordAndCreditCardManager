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
        UserDataBreaches UserDataBreaches;
        public List<Category> Categories { get; set; }

        private const int MAXIMUM_CHARACTERS_CATEGORY_NAME = 15;
        private const int MINIMUM_CHARACTERS_CATEGORY_NAME = 3;
        public const string SHARED_PASSWORD_CATEGORY_NAME = "Shared With Me";

        public static Category SHARED_WITH_ME_CATEGORY = new Category(SHARED_PASSWORD_CATEGORY_NAME);

        public User()
        {
            Categories = new List<Category>();
            UserDataBreaches = new UserDataBreaches(this);
            UserCreditCards = new UserCreditCard();
            UserPasswords = new UserPassword();
            Categories.Add(SHARED_WITH_ME_CATEGORY);
        }

        public User(string name, string mainPassword)
        {
            Categories = new List<Category>();
            UserPasswords = new UserPassword();
            UserCreditCards = new UserCreditCard();
            Name = name;
            MainPassword = mainPassword;
            UserDataBreaches = new UserDataBreaches(this);
            UserCreditCards = new UserCreditCard();
            UserPasswords = new UserPassword();
        }

        public void AddCategory(Category aCategory)
        {
            Verifier.VerifyCategory(aCategory);
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

        public void ModifyCategory(Category categoryToModify, Category newCategory)
        {
            //modificar metodo modify, que el string ya sea otra categoria -> no lo hago para chequear antes con el team
            //por ahora hago esto
            Verifier.VerifyCategory(newCategory);

            // Find category in list
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

        public override bool Equals(object obj)
        {
            User theUser = (User)obj;
            return theUser.Name == this.Name;
        }
    }
}
