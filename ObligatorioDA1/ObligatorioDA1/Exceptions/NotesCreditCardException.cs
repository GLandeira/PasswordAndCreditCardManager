using System;


namespace Domain.Exceptions
{
    public class NotesCreditCardException : CreditCardException
    {
        public NotesCreditCardException()
        {
        }

        public override string Message => "Notes can not extend from 250 characters";


        public override string ToString()
        {
            return base.ToString();
        }
    }
}

