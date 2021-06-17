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
            byte[] translatedKey = ByteArrayStringTranslator.ToByteArray(encryptionData.PasswordKey);
            byte[] translatedIV = ByteArrayStringTranslator.ToByteArray(encryptionData.PasswordIV);
            
            byte[] passwordAsByteArray = ByteArrayStringTranslator.ToByteArray(encryptionData.Password);
            string base64ValidPassword = Convert.ToBase64String(passwordAsByteArray);

            string encryptedPassword = Strings.Encrypt(base64ValidPassword, translatedKey, translatedIV);

            return encryptedPassword;
        }

        public string Decrypt(EncryptionData encryptionData)
        {
            byte[] translatedKey = ByteArrayStringTranslator.ToByteArray(encryptionData.PasswordKey);
            byte[] translatedIV = ByteArrayStringTranslator.ToByteArray(encryptionData.PasswordIV);

            string decryptedPassword = Strings.Decrypt(encryptionData.Password, translatedKey, translatedIV);

            byte[] base64ValidPassword = Convert.FromBase64String(decryptedPassword);

            string finalValidPassword = ByteArrayStringTranslator.ToString(base64ValidPassword);

            return finalValidPassword;
        }

        public EncryptionData GenerateEncryptionData()
        {
            EncryptionData encryptionData = new EncryptionData();
            encryptionData.PasswordIV = ByteArrayStringTranslator.ToString(Bytes.GenerateIV());
            encryptionData.PasswordKey = ByteArrayStringTranslator.ToString(Bytes.GenerateKey());

            return encryptionData;
        }
    }
}
