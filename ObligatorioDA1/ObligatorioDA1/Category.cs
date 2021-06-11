using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public UserCategory UserCategory { get; set; }
        public Category()
        {
        }
        public Category(string name)
        {
            Name = name;
        }
        public Category(int categoryId, string name)
        {
            CategoryID = categoryId;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == DBNull.Value) 
            {
                return false;
            }

            Category otherCategory = (Category)obj;
            return Name.ToLower() == otherCategory.Name.ToLower();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
