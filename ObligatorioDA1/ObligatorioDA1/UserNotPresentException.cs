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

        public UserNotPresentException(string message) : base(message)
        {
        }

        public UserNotPresentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
