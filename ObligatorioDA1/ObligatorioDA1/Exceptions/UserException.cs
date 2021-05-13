using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UserException : Exception
    {
        public UserException()
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
