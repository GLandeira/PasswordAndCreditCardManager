using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class CreditCard
    {
        string name;
        CardTypes type;
        string number;
        string securityCode;
        DateTime validDue;
        Category category;
        string notes;
        bool isBreached;
    }
}
