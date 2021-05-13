using System;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    public class PasswordAlreadySharedException : PasswordExceptions
    {
        public PasswordAlreadySharedException()
        {
        }

        public override string Message => "This password is already shared with that user";
    }
}