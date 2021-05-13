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
        public override string Message => "The password already exists";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
