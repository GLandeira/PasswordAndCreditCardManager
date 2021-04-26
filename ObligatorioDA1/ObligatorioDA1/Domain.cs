using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Domain
    {
        public List<User> Users { get; set; }

        public Domain()
        {
            Users = new List<User>();
        }

        public void AddUser(User newUser)
        {
            Users.Add(newUser);
        }
    }
}
