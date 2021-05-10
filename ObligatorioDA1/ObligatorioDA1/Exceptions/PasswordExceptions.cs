using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class PasswordExceptions : Exception
    {
        public PasswordExceptions()
        {
        }

        public PasswordExceptions(string message) : base(message)
        {
        }

        public PasswordExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
