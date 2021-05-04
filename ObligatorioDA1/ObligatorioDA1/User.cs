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
        UserPassword UserPasswords;
        UserCreditCard UserCreditCards;
        public List<Category> Categories { get; set; }

        public User()
        {
            Categories = new List<Category>();
        }

        public User(string name, string mainPassword)
        {
            Categories = new List<Category>();
            Name = name;
            MainPassword = mainPassword;
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

        public void ModifyCategory(Category categoryToModify, string newName)
        {
            //modificar metodo modify, que el string ya sea otra categoria -> no lo hago para chequear antes con el team
            //por ahora hago esto
            Category newCategory = new Category(newName);
            Verifier.VerifyCategory(newCategory);

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
