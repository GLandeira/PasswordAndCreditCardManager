using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordGenerator
{
    public struct PasswordGenerationSettings
    {
        public int length;
        public bool hasMayus;
        public bool hasMinus;
        public bool hasDigits;
        public bool hasSymbols;
    }
}
