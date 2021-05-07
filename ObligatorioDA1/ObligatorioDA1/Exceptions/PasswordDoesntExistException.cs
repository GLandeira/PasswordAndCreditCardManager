using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class PasswordDoesntExistException : Exception
    {
        public PasswordDoesntExistException()
        {
        }

        public PasswordDoesntExistException(string message) : base(message)
        {
        }

        public PasswordDoesntExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
