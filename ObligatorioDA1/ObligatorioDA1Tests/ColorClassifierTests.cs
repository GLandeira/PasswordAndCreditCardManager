﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Domain.PasswordSecurityFlagger;

namespace DomainTests
{
    [TestClass]
    public class ColorClassifierTests
    {
        [TestMethod]
        public void TestHasUpperCaseValidCase()
        {
            String password = "aA123bc#";
            bool passwordHasUpperCase = ColorClassifier.HasUpperCase(password);
            Assert.AreEqual(true, passwordHasUpperCase);
        }

        [TestMethod]
        public void TestHasUpperCaseInvalidCase()
        {
            String password = "cdf33b@#";
            bool passwordHasUpperCase = ColorClassifier.HasUpperCase(password);
            Assert.AreEqual(false, passwordHasUpperCase);
        }

        [TestMethod]
        public void TestHasLowerCaseValidCase()
        {
            String password = "JL@b2d3";
            bool passwordHasLowerCase = ColorClassifier.HasLowerCase(password);
            Assert.AreEqual(true, passwordHasLowerCase);
        }

        [TestMethod]
        public void TestHasLowerCaseInvalidCase()
        {
            String password = "L#$P23";
            bool passwordHasLowerCase = ColorClassifier.HasLowerCase(password);
            Assert.AreEqual(false, passwordHasLowerCase);
        }

        [TestMethod]
        public void TestHasDigitsValidCase()
        {
            String password = "12lmN@4";
            bool passwordHasDigits = ColorClassifier.HasDigits(password);
            Assert.AreEqual(true, passwordHasDigits);
        }

        [TestMethod]
        public void TestHasDigitsInvalidCase()
        {
            String password = "BDjavier@&ee";
            bool passwordHasDigits = ColorClassifier.HasDigits(password);
            Assert.AreEqual(false, passwordHasDigits);
        }

        [TestMethod]
        public void TestHasSpecialCharacterValidCase()
        {
            String password = "@&#abhaschars!";
            bool passwordHasSpecialCharacters = ColorClassifier.HasSpecialCharacters(password);
            Assert.AreEqual(true, passwordHasSpecialCharacters);
        }

        [TestMethod]
        public void TestHasSpecialCharacterInvalidCase()
        {
            String password = "contra23sin12characteresespeciales";
            bool passwordHasSpecialCharacters = ColorClassifier.HasSpecialCharacters(password);
            Assert.AreEqual(false, passwordHasSpecialCharacters);
        }

        [TestMethod]
        public void TestYellowClassifierMeetsCriteriaTrueCase()
        {
            String password = "aAaXefggwlmopre";
            bool meetsYellowCriteria = YellowClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsYellowCriteria);
        }

        [TestMethod]
        public void TestYellowClassifierMeetsCriteriaFalseCase()
        {
            String password = "defghij";
            bool meetsYellowCriteria = YellowClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsYellowCriteria);
        }

        [TestMethod]
        public void TestLightGreenClassifierMeetsCriteriaTrueCase1()
        {
            String password = "MaTiasGonZAlEzG";
            bool meetsLightGreenCriteria = LightGreenClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsLightGreenCriteria);
        }

        [TestMethod]
        public void TestLightGreenClassifierMeetsCriteriaTrueCase2()
        {
            String password = "matias1#2@3gonzalez";
            bool meetsLightGreenCriteria = LightGreenClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsLightGreenCriteria);
        }

        [TestMethod]
        public void TestLightGreenClassifierMeetsCriteriaTrueCase3()
        {
            String password = "MATIAS1#2@3GONZALEZ";
            bool meetsLightGreenCriteria = LightGreenClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsLightGreenCriteria);
        }

        [TestMethod]
        public void TestLightGreenClassifierMeetsCriteriaFalseCase1()
        {
            String password = "aB1@GD";
            bool meetsLightGreenCriteria = LightGreenClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsLightGreenCriteria);
        }

        [TestMethod]
        public void TestLightGreenClassifierMeetsCriteriaFalseCase2()
        {
            String password = "abc123de4f56";
            bool meetsLightGreenCriteria = LightGreenClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsLightGreenCriteria);
        }

        [TestMethod]
        public void TestDarkGreenClassifierMeetsCriteriaTrueCase()
        {
            String password = "Ab3D/%45zweXJcf16";
            bool meetsDarkGreenCriteria = DarkGreenClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsDarkGreenCriteria);
        }

        [TestMethod]
        public void TestDarkGreenClassifierMeetsCriteriaFalseCase1()
        {
            String password = "Az@#23D";
            bool meetsDarkGreenCriteria = DarkGreenClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsDarkGreenCriteria);
        }

        [TestMethod]
        public void TestDarkGreenClassifierMeetsCriteriaFalseCase2()
        {
            String password = "AjKl$$#[bdd]{}hhh";
            bool meetsDarkGreenCriteria = DarkGreenClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsDarkGreenCriteria);
        }

        [TestMethod]
        public void TestDarkGreenClassifierMeetsCriteriaFalseCase3()
        {
            String password = "A933lLM73bdd622hh";
            bool meetsDarkGreenCriteria = DarkGreenClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsDarkGreenCriteria);
        }

        [TestMethod]
        public void TestRedClassifierMeetsCriteriaTrueCase()
        {
            String password = "aaab";
            bool meetsRedCriteria = RedClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsRedCriteria);
        }

        [TestMethod]
        public void TestRedClassifierMeetsCriteriaFalseCase()
        {
            String password = "abcdefghijk";
            bool meetsRedCriteria = RedClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsRedCriteria);
        }

        [TestMethod]
        public void TestOrangeClassifierMeetsCriteriaTrueCase()
        {
            String password = "abc23dd$#45cj";
            bool meetsOrangeCriteria = OrangeClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsOrangeCriteria);
        }

        [TestMethod]
        public void TestOrangeClassifierMeetsCriteriaFalseCase1()
        {
            String password = "abc123";
            bool meetsOrangeCriteria = OrangeClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsOrangeCriteria);
        }

        [TestMethod]
        public void TestOrangeClassifierMeetsCriteriaFalseCase2()
        {
            String password = "abcDJ%&@123HelloMotto";
            bool meetsOrangeCriteria = OrangeClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsOrangeCriteria);
        }


    }
}
