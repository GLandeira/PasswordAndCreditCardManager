using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidPasswordGenerationSettingsException : PasswordExceptions
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

        public override string Message => "Invalid password generation settings";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
