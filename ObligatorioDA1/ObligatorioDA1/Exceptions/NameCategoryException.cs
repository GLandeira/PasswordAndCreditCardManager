using System;

namespace Domain.Exceptions
{
    public class NameCategoryException : Exception
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

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

