﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private IEncryptor _effortlessEncryptor;
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
            string encrypted = _effortlessEncryptor.Encrypt(_string1);
            Assert.AreEqual(_string1, _effortlessEncryptor.Decrypt(encrypted));
        }

        [TestMethod]
        public void TestEncrypt2()
        {
            string encrypted1 = _effortlessEncryptor.Encrypt(_string1);
            string encrypted2 = _effortlessEncryptor.Encrypt(_string3);
            Assert.AreEqual(_string1, _effortlessEncryptor.Decrypt(encrypted1));
            Assert.AreEqual(_string3, _effortlessEncryptor.Decrypt(encrypted2));
        }

        [TestMethod]
        public void TestTwoEncryptedPasswordsArentTheSame1()
        {
            string encrypted1 = _effortlessEncryptor.Encrypt(_string1);
            string encrypted2 = _effortlessEncryptor.Encrypt(_string2);
            Assert.AreNotEqual(encrypted1, encrypted2);
        }

        [TestMethod]
        public void TestTwoEncryptedPasswordsArentTheSame2()
        {
            string encrypted1 = _effortlessEncryptor.Encrypt(_string1);
            string encrypted2 = _effortlessEncryptor.Encrypt(_string1);
            Assert.AreNotEqual(encrypted1, encrypted2);
        }
    }
}