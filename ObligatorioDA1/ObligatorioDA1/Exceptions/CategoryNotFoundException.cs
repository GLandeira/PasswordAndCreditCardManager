using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class CategoryNotFoundException : UserException
    {
        public CategoryNotFoundException()
        {
        }

        public override string Message => "That Category doesn't exist!";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
