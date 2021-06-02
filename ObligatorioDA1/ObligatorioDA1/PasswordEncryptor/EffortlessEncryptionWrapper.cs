using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effortless.Net.Encryption;

namespace Domain.PasswordEncryptor
{
    public class EffortlessEncryptionWrapper : IEncryptor
    {
        public string Encrypt(string password)
        {
            return password;
        }

        public string Decrypt(string encryptedPassword)
        {
            return encryptedPassword;
        }
    }
}
