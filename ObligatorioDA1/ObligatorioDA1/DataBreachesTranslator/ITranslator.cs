using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataBreachesTranslator
{
    public interface ITranslator
    {
        string[] Translate(string entry);
    }
}
