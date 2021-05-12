using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{

    public class NotesCreditCardException : Exception
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

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
