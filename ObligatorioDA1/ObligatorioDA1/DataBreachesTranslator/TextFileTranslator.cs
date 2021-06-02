using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataBreachesTranslator
{
    public class TextFileTranslator : ITranslator
    {
        public string[] Translate(string entry)
        {
            string[] translation = { "a", "a" };
            return translation;
        }
    }
}


