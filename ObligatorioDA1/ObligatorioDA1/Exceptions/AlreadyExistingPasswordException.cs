using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class AlreadyExistingPasswordException : PasswordExceptions
    {
        public AlreadyExistingPasswordException()
        {
        }

        public AlreadyExistingPasswordException(string message) : base(message)
        {
        }

        public AlreadyExistingPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => "The password already exists";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
