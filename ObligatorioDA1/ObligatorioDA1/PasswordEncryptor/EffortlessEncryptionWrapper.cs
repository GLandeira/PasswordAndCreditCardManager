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
        private const string SALT = "saldemesa";
        private byte[] _iv;
        private byte[] _key;

        public string Encrypt(string password)
        {
            _iv = Bytes.GenerateIV();
            _key = Bytes.GenerateKey();

            string encryptedPassword = Strings.Encrypt(SALT + password, _key, _iv);

            return encryptedPassword;
        }

        public string Decrypt(string encryptedPassword)
        {
            string decryptedPassword = Strings.Decrypt(encryptedPassword, _key, _iv);
            string saltlessPassword = decryptedPassword.Substring(SALT.Length, decryptedPassword.Length - SALT.Length);

            return saltlessPassword;
        }
    }
}
