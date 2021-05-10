using System;

namespace Domain.Exceptions
{
    public class NameCategoryException : UserException
    {
        public NameCategoryException()
        {
        }

        public NameCategoryException(string message) : base(message)
        {
        }

        public NameCategoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => "That name is either too long or too short!";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

