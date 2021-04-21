using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class User
    {
        string name;
        string mainPassword;
        List<Password> passwords;
        List<CreditCard> creditCards;
        List<Category> categories;
    }
}
