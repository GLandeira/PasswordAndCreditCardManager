using System;

namespace Domain.Exceptions
{
    public class PasswordNotFoundException : PasswordExceptions
    {
        public PasswordNotFoundException()
        {
        }
        public override string Message => "The password does not exist";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

