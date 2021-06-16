using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.PasswordEncryptor;

namespace DomainTests
{
    public class MockEncryptor : IEncryptor
    {
        public string Decrypt(string encryptedPassword)
        {
            string decryptedPassword = "";

            for (int i = 0; i < encryptedPassword.Length; i++)
            {
                decryptedPassword += (char)((byte)encryptedPassword[i] - 1);
            }

            return decryptedPassword;
        }

        public string Encrypt(string password)
        {
            string encryptedPassword = "";

            for (int i = 0; i < password.Length; i++)
            {
                encryptedPassword += (char)((byte)password[i] + 1);
            }

            return encryptedPassword;
        }
    }
}
