using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddCategory(Category aCategory)
        {
            Categories.Add(aCategory);
        }

        public Category GetACategory(string nameToTest)
        {
            return Categories.First(cat => cat.Name == nameToTest);
        }
    }
}
