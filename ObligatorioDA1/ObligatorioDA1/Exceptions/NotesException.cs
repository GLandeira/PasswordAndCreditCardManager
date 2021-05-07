using System;

namespace Domain.Exceptions
{
    public class NotesException : Exception
    {
        public NotesException()
        {
        }

        public NotesException(string message) : base(message)
        {
        }

        public NotesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}