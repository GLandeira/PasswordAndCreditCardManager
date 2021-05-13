using System;

namespace Domain.Exceptions
{
    public class NameUserException : UserException
    {
        public NameUserException()
        {
        }

        public override string Message => "Name input is incorrect,  names are between 5 and 25 characters";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

