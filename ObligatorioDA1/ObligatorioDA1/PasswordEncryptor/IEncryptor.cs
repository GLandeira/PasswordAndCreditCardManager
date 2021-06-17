using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordEncryptor
{
    public interface IEncryptor
    {
        string Encrypt(EncryptionData encryptionData);
        string Decrypt(EncryptionData encryptionData);
        EncryptionData GenerateEncryptionData();
    }
}
