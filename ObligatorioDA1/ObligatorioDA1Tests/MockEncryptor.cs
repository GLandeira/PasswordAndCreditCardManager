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
        public string Decrypt(EncryptionData encryptionData)
        {
            string encryptedPassword = encryptionData.Password;
            string decryptedPassword = "";

            for (int i = 0; i < encryptedPassword.Length; i++)
            {
                decryptedPassword += (char)((byte)encryptedPassword[i] - 1);
            }

            return decryptedPassword;
        }

        public string Encrypt(EncryptionData encryptionData)
        {
            string password = encryptionData.Password;
            string encryptedPassword = "";

            for (int i = 0; i < password.Length; i++)
            {
                encryptedPassword += (char)((byte)password[i] + 1);
            }

            return encryptedPassword;
        }

        public EncryptionData GenerateEncryptionData()
        {
            throw new NotImplementedException();
        }
    }
}
