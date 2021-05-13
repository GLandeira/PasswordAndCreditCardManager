using System;

namespace Domain.Exceptions
{
    public class PasswordStringPasswordException : PasswordExceptions
    {
        public PasswordStringPasswordException()
        {
        }
        public override string Message => "Password needs to be between 5 and 25 characters";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}