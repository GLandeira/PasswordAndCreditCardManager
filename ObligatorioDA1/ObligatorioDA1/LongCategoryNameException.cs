using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class LongCategoryNameException : UserException
    {
        public LongCategoryNameException()
        {
        }

        public LongCategoryNameException(string message) : base(message)
        {
        }

        public LongCategoryNameException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
