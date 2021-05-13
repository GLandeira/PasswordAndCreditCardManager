using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class CategoryAlreadyExistsException : UserException
    {
        public CategoryAlreadyExistsException()
        {
        }

        public override string Message => "That Category already exists!";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
