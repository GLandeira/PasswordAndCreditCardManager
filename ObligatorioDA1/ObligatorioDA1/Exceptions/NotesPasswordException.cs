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

        public override string Message => "Notes can not extend from 250 characters";

        public override string ToString()
        {
            return base.ToString();
        }

    }
}

