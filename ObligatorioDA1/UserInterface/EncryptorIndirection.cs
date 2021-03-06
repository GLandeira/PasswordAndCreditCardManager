using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.PasswordEncryptor;
using Domain;

namespace UserInterface
{
    public class EncryptorIndirection
    {
        private IEncryptor _encryptor;

        public EncryptorIndirection(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public Password PasswordEncryption(Password password)
        {
            EncryptionData encryptionData = new EncryptionData();

            if (password.PasswordIV == null || password.PasswordKey == null)
            {
                encryptionData = _encryptor.GenerateEncryptionData();
                password.PasswordIV = encryptionData.PasswordIV;
                password.PasswordKey = encryptionData.PasswordKey;
            }
            else
            {
                encryptionData.PasswordIV = password.PasswordIV;
                encryptionData.PasswordKey = password.PasswordKey;
            }

            encryptionData.Password = password.PasswordString;

            password.PasswordString = _encryptor.Encrypt(encryptionData);

            return password;
        }

        public Password PasswordDecryption(Password password)
        {
            EncryptionData encryptionData = new EncryptionData();
            encryptionData.Password = password.PasswordString;
            encryptionData.PasswordIV = password.PasswordIV;
            encryptionData.PasswordKey = password.PasswordKey;

            password.PasswordString = _encryptor.Decrypt(encryptionData);

            return password;
        }

        public List<Password> GenerateDecryptedPasswordsList(List<Password> entryList)
        {
            List<Password> returnList = new List<Password>();

            foreach(Password p in entryList)
            {
                returnList.Add(PasswordDecryption(p));
            }

            return returnList;
        }

        public List<Password> GenerateEncryptedPasswordsList(List<Password> entryList)
        {
            List<Password> returnList = new List<Password>();

            foreach (Password p in entryList)
            {
                returnList.Add(PasswordEncryption(p));
            }

            return returnList;
        }

        public User UserMainPasswordEncryption(User user)
        {
            EncryptionData encryptionData = new EncryptionData();

            if (user.PasswordIV == null || user.PasswordKeys == null)
            {
                encryptionData = _encryptor.GenerateEncryptionData();
                user.PasswordIV = encryptionData.PasswordIV;
                user.PasswordKeys = encryptionData.PasswordKey;
            }
            else
            {
                encryptionData.PasswordIV = user.PasswordIV;
                encryptionData.PasswordKey = user.PasswordKeys;
            }

            encryptionData.Password = user.MainPassword;

            user.MainPassword = _encryptor.Encrypt(encryptionData);

            return user;
        }

        public User UserMainPasswordDecryption(User user)
        {
            EncryptionData encryptionData = new EncryptionData();
            encryptionData.Password = user.MainPassword;
            encryptionData.PasswordIV = user.PasswordIV;
            encryptionData.PasswordKey = user.PasswordKeys;

            user.MainPassword = _encryptor.Decrypt(encryptionData);

            return user;
        }

        public List<User> GenerateDecryptedUsersList(List<User> entryList)
        {
            List<User> returnList = new List<User>();

            foreach (User u in entryList)
            {
                returnList.Add(UserMainPasswordDecryption(u));
            }

            return returnList;
        }

        public List<User> GenerateEncryptedUsersList(List<User> entryList)
        {
            List<User> returnList = new List<User>();

            foreach (User u in entryList)
            {
                returnList.Add(UserMainPasswordEncryption(u));
            }

            return returnList;
        }
    }
}
