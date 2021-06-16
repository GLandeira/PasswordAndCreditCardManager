using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.PasswordEncryptor;

namespace DomainTests
{
    /// <summary>
    /// Summary description for EffortlessEncryptorWrapperTests
    /// </summary>
    [TestClass]
    public class EffortlessEncryptorWrapperTests
    {
        private EffortlessEncryptionWrapper _effortlessEncryptor;
        private string _string1;
        private string _string2;
        private string _string3;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _effortlessEncryptor = new EffortlessEncryptionWrapper();
            _string1 = "papas";
            _string2 = "mayonesa123";
            _string3 = "%Sa2@4loPlaAws124324_";
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestEncrypt1()
        {
            EncryptionData encryptionData = _effortlessEncryptor.GenerateEncryptionData();
            encryptionData.Password = _string1;

            string encrypted = _effortlessEncryptor.Encrypt(encryptionData);
            encryptionData.Password = encrypted;

            Assert.AreEqual(_string1, _effortlessEncryptor.Decrypt(encryptionData));
        }

        [TestMethod]
        public void TestEncrypt2()
        {
            EncryptionData encryptionData1 = _effortlessEncryptor.GenerateEncryptionData();
            encryptionData1.Password = _string1;

            EncryptionData encryptionData2 = _effortlessEncryptor.GenerateEncryptionData();
            encryptionData2.Password = _string3;

            string encrypted1 = _effortlessEncryptor.Encrypt(encryptionData1);
            encryptionData1.Password = encrypted1;

            string encrypted2 = _effortlessEncryptor.Encrypt(encryptionData2);
            encryptionData2.Password = encrypted2;

            Assert.AreEqual(_string1, _effortlessEncryptor.Decrypt(encryptionData1));
            Assert.AreEqual(_string3, _effortlessEncryptor.Decrypt(encryptionData2));
        }

        [TestMethod]
        public void TestTwoEncryptedPasswordsArentTheSame1()
        {
            EncryptionData encryptionData1 = _effortlessEncryptor.GenerateEncryptionData();
            encryptionData1.Password = _string1;

            EncryptionData encryptionData2 = _effortlessEncryptor.GenerateEncryptionData();
            encryptionData2.Password = _string2;

            string encrypted1 = _effortlessEncryptor.Encrypt(encryptionData1);
            string encrypted2 = _effortlessEncryptor.Encrypt(encryptionData2);
            Assert.AreNotEqual(encrypted1, encrypted2);
        }

        [TestMethod]
        public void TestTwoEncryptedPasswordsArentTheSame2()
        {
            EncryptionData encryptionData1 = _effortlessEncryptor.GenerateEncryptionData();
            encryptionData1.Password = _string1;

            EncryptionData encryptionData2 = _effortlessEncryptor.GenerateEncryptionData();
            encryptionData2.Password = _string1;

            string encrypted1 = _effortlessEncryptor.Encrypt(encryptionData1);
            string encrypted2 = _effortlessEncryptor.Encrypt(encryptionData2);
            Assert.AreNotEqual(encrypted1, encrypted2);
        }
    }
}
