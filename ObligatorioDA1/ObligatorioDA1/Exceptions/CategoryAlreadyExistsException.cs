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

        public CategoryAlreadyExistsException(string message) : base(message)
        {
        }

        public CategoryAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => "That Category already exists!";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
