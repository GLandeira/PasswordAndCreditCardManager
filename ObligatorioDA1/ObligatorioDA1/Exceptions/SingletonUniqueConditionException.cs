using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class SingletonUniqueConditionException : Exception
    {
        public SingletonUniqueConditionException()
        {
        }
        public override string Message => "Singleton unique property violated!";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}