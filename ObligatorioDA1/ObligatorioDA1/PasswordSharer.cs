using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PasswordSharer
    {
        private const string SHARED_PASSWORD_CATEGORY = "";

        private Domain _theDomain;

        public static PasswordSharer Instance { get; private set; }

        private PasswordSharer(Domain theDomain)
        {
            _theDomain = theDomain;
        }

        public static void Init(Domain theDomain)
        {
            Instance = new PasswordSharer(theDomain);
        }

        internal void SharePassword(PasswordShareDetails shareDetails)
        {
            // Buscar al user y darle la password
            // Asegurarse que la password tiene la categoria
            string sharerName = shareDetails.sharerName;
            string shareeName = shareDetails.shareeName;
            Password sharedPassword = shareDetails.sharedPassword;

            // Change the passwords category
            sharedPassword.Category.Name = SHARED_PASSWORD_CATEGORY;

            _theDomain.GetUser(shareeName).UserPasswords.AddPassword(sharedPassword);


        }
    }
}
