using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effortless.Net.Encryption;

namespace Domain.PasswordEncryptor
{
    class EffortlessEncryptionWrapper : IEncryptor
    {
        public string Encrypt(string password)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string encryptedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
