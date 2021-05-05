using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidPasswordGenerationSettingsException : Exception
    {
        public InvalidPasswordGenerationSettingsException()
        {
        }

        public InvalidPasswordGenerationSettingsException(string message) : base(message)
        {
        }

        public InvalidPasswordGenerationSettingsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
