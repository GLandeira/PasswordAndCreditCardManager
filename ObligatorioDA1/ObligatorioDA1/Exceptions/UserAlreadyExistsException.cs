using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UserAlreadyExistsException : DomainException
    {
        public UserAlreadyExistsException()
        {
        }

        public override string Message => "This user already exists";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
