using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataBreachesTranslator
{
    public class TextBoxTranslator : ITranslator
    {
        public string[] Translate(string entry)
        {
            string[] separator = new string[] { Environment.NewLine };
            string[] fields = entry.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            return fields;
        }
    }
}
