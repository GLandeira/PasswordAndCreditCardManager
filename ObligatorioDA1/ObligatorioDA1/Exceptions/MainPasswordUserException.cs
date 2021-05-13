using System;

namespace Domain.Exceptions
{
    public class MainPasswordUserException : UserException
    {
        public MainPasswordUserException()
        {
        }

        public override string Message => "That Password is too long or too short!";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
