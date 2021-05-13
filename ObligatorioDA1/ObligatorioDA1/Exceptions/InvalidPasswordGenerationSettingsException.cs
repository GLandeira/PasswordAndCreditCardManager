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

        public override string Message => "Invalid password generation settings";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
