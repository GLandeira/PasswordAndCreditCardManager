using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordEncryptor
{
    public struct EncryptionData
    {
        public string Password;
        public byte[] PasswordKey;
        public byte[] PasswordIV;
    }
}
