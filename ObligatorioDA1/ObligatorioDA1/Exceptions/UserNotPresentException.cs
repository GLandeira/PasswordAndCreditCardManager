using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UserNotPresentException : DomainException
    {
        public UserNotPresentException()
        {
        }

        public override string Message => "The user is not present";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
