using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        string name;
        string mainPassword;
        UserPassword userPasswords;
        UserCreditCard userCreditCards;
        List<Category> categories;
    }
}
