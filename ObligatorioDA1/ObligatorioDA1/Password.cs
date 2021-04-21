using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Password
    {
        string password;
        string site;
        string username;
        DateTime lastModification;
        SecurityLevelPasswords securityLevel;
        Category category;
        string notes;
        bool isBreached;
        List<string> usersSharedWith;
    }
}
