using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public struct PasswordGenerationSettings
    {
        int length;
        bool hasMayus;
        bool hasMinus;
        bool hasDigits;
        bool hasSymbols;
    }
}
