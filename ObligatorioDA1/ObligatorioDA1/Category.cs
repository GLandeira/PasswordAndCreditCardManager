using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        string name { get; set; }

        public Category(string cName)
        {
            name = cName;
        }
    }
}
