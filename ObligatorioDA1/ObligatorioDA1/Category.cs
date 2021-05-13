using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category : ICloneable
    {
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == DBNull.Value) return false;
            Category otherCategory = (Category)obj;
            return this.Name.ToLower() == otherCategory.Name.ToLower();
        }

        public object Clone()
        {
            Category clone = new Category(this.Name);
            return clone;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
