using System;

using System.Runtime.Serialization;

namespace Domain.Exceptions
{

    public class NotesPasswordException : PasswordExceptions
    {
        public NotesPasswordException()
        {
        }

        public NotesPasswordException(string message) : base(message)
        {
        }

        public NotesPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotesPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => base.Message;
    }
}

