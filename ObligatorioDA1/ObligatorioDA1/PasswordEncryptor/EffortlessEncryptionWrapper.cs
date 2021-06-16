using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effortless.Net.Encryption;
using Domain.Helpers;

namespace Domain.PasswordEncryptor
{
    public class EffortlessEncryptionWrapper : IEncryptor
    {
        private byte[] _iv;
        private byte[] _key;

        public EffortlessEncryptionWrapper()
        {
            _iv = Bytes.GenerateIV();
            _key = Bytes.GenerateKey();
        }

        public EffortlessEncryptionWrapper(string key, string iv)
        {
            _iv = ByteArrayStringTranslator.ToByteArray(iv);
            _key = ByteArrayStringTranslator.ToByteArray(key);
        }

        public string Encrypt(string password)
        {
            string encryptedPassword = Strings.Encrypt(password, _key, _iv);

            return encryptedPassword;
        }

        public string Decrypt(string encryptedPassword)
        {
            string decryptedPassword = Strings.Decrypt(encryptedPassword, _key, _iv);

            return decryptedPassword;
        }
    }
}
