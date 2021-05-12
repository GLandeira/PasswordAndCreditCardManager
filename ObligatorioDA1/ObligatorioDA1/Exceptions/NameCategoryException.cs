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

        public override string Message => "Name input is incorrect, categorie's names are between 3 and 15 characters long";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

