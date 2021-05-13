using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
