using System;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    public class PasswordAlreadySharedException : PasswordExceptions
    {
        public PasswordAlreadySharedException()
        {
        }

        public PasswordAlreadySharedException(string message) : base(message)
        {
        }

        public PasswordAlreadySharedException(string message, Exception innerException) : base(message, innerException)
        {
        }


        public override string Message => "This password is already shared with that user";
    }
}