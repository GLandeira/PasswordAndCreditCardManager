﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace Domain
{
    [TestClass]
    public class PasswordSecurityFlaggerTests
    {

        [TestMethod]
        public void TestHasUpperCaseValidCase()
        {
            String password = "aA123bc#";
            bool passwordHasUpperCase = PasswordSecurityFlagger.HasUpperCase(password);
            Assert.AreEqual(true, passwordHasUpperCase);
        }

        [TestMethod]
        public void TestHasUpperCaseInvalidCase()
        {
            String password = "cdf33b@#";
            bool passwordHasUpperCase = PasswordSecurityFlagger.HasUpperCase(password);
            Assert.AreEqual(false, passwordHasUpperCase);
        }

        [TestMethod]
        public void TestHasLowerCaseValidCase()
        {
            String password = "JL@b2d3";
            bool passwordHasLowerCase = PasswordSecurityFlagger.HasLowerCase(password);
            Assert.AreEqual(true, passwordHasLowerCase);
        }

        [TestMethod]
        public void TestHasLowerCaseInvalidCase()
        {
            String password = "L#$P23";
            bool passwordHasLowerCase = PasswordSecurityFlagger.HasLowerCase(password);
            Assert.AreEqual(false, passwordHasLowerCase);
        }

        [TestMethod]
        public void TestHasDigitsValidCase()
        {
            String password = "12lmN@4";
            bool passwordHasDigits = PasswordSecurityFlagger.HasDigits(password);
            Assert.AreEqual(true, passwordHasDigits);
        }

        [TestMethod]
        public void TestHasDigitsInvalidCase()
        {
            String password = "BDjavier@&ee";
            bool passwordHasDigits = PasswordSecurityFlagger.HasDigits(password);
            Assert.AreEqual(false, passwordHasDigits);
        }

        [TestMethod]
        public void TestHasSpecialCharacterValidCase()
        {
            String password = "@&#abhaschars!";
            bool passwordHasSpecialCharacters = PasswordSecurityFlagger.HasSpecialCharacters(password);
            Assert.AreEqual(true, passwordHasSpecialCharacters);
        }

        [TestMethod]
        public void TestHasSpecialCharacterInvalidCase()
        {
            String password = "contra23sin12characteresespeciales";
            bool passwordHasSpecialCharacters = PasswordSecurityFlagger.HasSpecialCharacters(password);
            Assert.AreEqual(false, passwordHasSpecialCharacters);
        }

        
}

