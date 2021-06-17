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
        public EffortlessEncryptionWrapper()
        {
        }

        public string Encrypt(EncryptionData encryptionData)
        {
            byte[] translatedKey = encryptionData.PasswordKey;
            byte[] translatedIV = encryptionData.PasswordIV;

            string encryptedPassword = Strings.Encrypt(encryptionData.Password, translatedKey, translatedIV);

            return encryptedPassword;
        }

        public string Decrypt(EncryptionData encryptionData)
        {
            byte[] translatedKey = encryptionData.PasswordKey;
            byte[] translatedIV = encryptionData.PasswordIV;

            string decryptedPassword = Strings.Decrypt(encryptionData.Password, translatedKey, translatedIV);

            return decryptedPassword;
        }

        public EncryptionData GenerateEncryptionData()
        {
            EncryptionData encryptionData = new EncryptionData();
            encryptionData.PasswordIV = Bytes.GenerateIV();
            encryptionData.PasswordKey = Bytes.GenerateKey();

            return encryptionData;
        }
    }
}
