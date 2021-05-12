using System;


namespace Domain.Exceptions
{
    public class NotesCreditCardException : CreditCardException

    {
        public NotesCreditCardException()
        {
        }

        public NotesCreditCardException(string message) : base(message)
        {
        }

        public NotesCreditCardException(string message, Exception innerException) : base(message, innerException)
        {
        }


        public override string Message => "Notes can not extend from 250 characters";


        public override string ToString()
        {
            return base.ToString();
        }
    }
}

