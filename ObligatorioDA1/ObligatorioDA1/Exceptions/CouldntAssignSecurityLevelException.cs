using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class CouldntAssignSecurityLevelException : UserException
    {
        public CouldntAssignSecurityLevelException()
        {
        }

        public CouldntAssignSecurityLevelException(string message) : base(message)
        {
        }

        public CouldntAssignSecurityLevelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => "Couldnt assing security level";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

