using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ShortCategoryNameException : UserException
    {
        public ShortCategoryNameException()
        {
        }

        public ShortCategoryNameException(string message) : base(message)
        {
        }

        public ShortCategoryNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
