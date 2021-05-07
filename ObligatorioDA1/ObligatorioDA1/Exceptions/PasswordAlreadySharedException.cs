using System;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    public class PasswordAlreadySharedException : Exception
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

        protected PasswordAlreadySharedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => base.Message;
    }
}