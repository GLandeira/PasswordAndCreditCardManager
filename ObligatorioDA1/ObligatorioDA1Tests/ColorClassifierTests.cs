using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Domain.PasswordSecurityFlagger;

namespace DomainTests
{
    [TestClass]
    public class ColorClassifierTests
    {
        private ColorClassifier _colorClassifier;

        [TestInitialize]
        public void TestInitialize()
        {
            _colorClassifier = new ColorClassifier();
        }

        [TestMethod]
        public void TestHasUpperCaseValidCase()
        {
            string password = "aA123bc#";
            bool passwordHasUpperCase = _colorClassifier.HasUpperCase(password);
            Assert.AreEqual(true, passwordHasUpperCase);
        }

        [TestMethod]
        public void TestHasUpperCaseInvalidCase()
        {
            string password = "cdf33b@#";
            bool passwordHasUpperCase = _colorClassifier.HasUpperCase(password);
            Assert.AreEqual(false, passwordHasUpperCase);
        }

        [TestMethod]
        public void TestHasLowerCaseValidCase()
        {
            string password = "JL@b2d3";
            bool passwordHasLowerCase = _colorClassifier.HasLowerCase(password);
            Assert.AreEqual(true, passwordHasLowerCase);
        }

        [TestMethod]
        public void TestHasLowerCaseInvalidCase()
        {
            string password = "L#$P23";
            bool passwordHasLowerCase = _colorClassifier.HasLowerCase(password);
            Assert.AreEqual(false, passwordHasLowerCase);
        }

        [TestMethod]
        public void TestHasDigitsValidCase()
        {
            string password = "12lmN@4";
            bool passwordHasDigits = _colorClassifier.HasDigits(password);
            Assert.AreEqual(true, passwordHasDigits);
        }

        [TestMethod]
        public void TestHasDigitsInvalidCase()
        {
            string password = "BDjavier@&ee";
            bool passwordHasDigits = _colorClassifier.HasDigits(password);
            Assert.AreEqual(false, passwordHasDigits);
        }

        [TestMethod]
        public void TestHasSpecialCharacterValidCase()
        {
            string password = "@&#abhaschars!";
            bool passwordHasSpecialCharacters = _colorClassifier.HasSpecialCharacters(password);
            Assert.AreEqual(true, passwordHasSpecialCharacters);
        }

        [TestMethod]
        public void TestHasSpecialCharacterInvalidCase()
        {
            string password = "contra23sin12characteresespeciales";
            bool passwordHasSpecialCharacters = _colorClassifier.HasSpecialCharacters(password);
            Assert.AreEqual(false, passwordHasSpecialCharacters);
        }

        [TestMethod]
        public void TestYellowClassifierMeetsCriteriaTrueCase()
        {
            _colorClassifier = new YellowClassifier();

            string password = "aAaXefggwlmopre";
            bool meetsYellowCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsYellowCriteria);
        }

        [TestMethod]
        public void TestYellowClassifierMeetsCriteriaFalseCase()
        {
            _colorClassifier = new YellowClassifier();

            string password = "defghij";
            bool meetsYellowCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsYellowCriteria);
        }

        [TestMethod]
        public void TestLightGreenClassifierMeetsCriteriaTrueCase1()
        {
            _colorClassifier = new LightGreenClassifier();

            string password = "MaTiasGonZAlEzG";
            bool meetsLightGreenCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsLightGreenCriteria);
        }

        [TestMethod]
        public void TestLightGreenClassifierMeetsCriteriaTrueCase2()
        {
            _colorClassifier = new LightGreenClassifier();

            string password = "matias1#2@3gonzalez";
            bool meetsLightGreenCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsLightGreenCriteria);
        }

        [TestMethod]
        public void TestLightGreenClassifierMeetsCriteriaTrueCase3()
        {
            _colorClassifier = new LightGreenClassifier();

            string password = "MATIAS1#2@3GONZALEZ";
            bool meetsLightGreenCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsLightGreenCriteria);
        }

        [TestMethod]
        public void TestLightGreenClassifierMeetsCriteriaFalseCase1()
        {
            _colorClassifier = new LightGreenClassifier();

            string password = "aB1@GD";
            bool meetsLightGreenCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsLightGreenCriteria);
        }

        [TestMethod]
        public void TestLightGreenClassifierMeetsCriteriaFalseCase2()
        {
            _colorClassifier = new LightGreenClassifier();

            string password = "abc123de4f56";
            bool meetsLightGreenCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsLightGreenCriteria);
        }

        [TestMethod]
        public void TestDarkGreenClassifierMeetsCriteriaTrueCase()
        {
            _colorClassifier = new DarkGreenClassifier();

            string password = "Ab3D/%45zweXJcf16";
            bool meetsDarkGreenCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsDarkGreenCriteria);
        }

        [TestMethod]
        public void TestDarkGreenClassifierMeetsCriteriaFalseCase1()
        {
            _colorClassifier = new DarkGreenClassifier();

            string password = "Az@#23D";
            bool meetsDarkGreenCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsDarkGreenCriteria);
        }

        [TestMethod]
        public void TestDarkGreenClassifierMeetsCriteriaFalseCase2()
        {
            _colorClassifier = new DarkGreenClassifier();

            string password = "AjKl$$#[bdd]{}hhh";
            bool meetsDarkGreenCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsDarkGreenCriteria);
        }

        [TestMethod]
        public void TestDarkGreenClassifierMeetsCriteriaFalseCase3()
        {
            _colorClassifier = new DarkGreenClassifier();

            string password = "A933lLM73bdd622hh";
            bool meetsDarkGreenCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsDarkGreenCriteria);
        }

        [TestMethod]
        public void TestRedClassifierMeetsCriteriaTrueCase()
        {
            _colorClassifier = new RedClassifier();

            string password = "aaab";
            bool meetsRedCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsRedCriteria);
        }

        [TestMethod]
        public void TestRedClassifierMeetsCriteriaFalseCase()
        {
            _colorClassifier = new RedClassifier();

            string password = "abcdefghijk";
            bool meetsRedCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsRedCriteria);
        }

        [TestMethod]
        public void TestOrangeClassifierMeetsCriteriaTrueCase()
        {
            _colorClassifier = new OrangeClassifier();

            string password = "abc23dd$#45cj";
            bool meetsOrangeCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(true, meetsOrangeCriteria);
        }

        [TestMethod]
        public void TestOrangeClassifierMeetsCriteriaFalseCase1()
        {
            _colorClassifier = new OrangeClassifier();

            string password = "abc123";
            bool meetsOrangeCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsOrangeCriteria);
        }

        [TestMethod]
        public void TestOrangeClassifierMeetsCriteriaFalseCase2()
        {
            _colorClassifier = new OrangeClassifier();

            string password = "abcDJ%&@123HelloMotto";
            bool meetsOrangeCriteria = _colorClassifier.MeetsColorCriteria(password);
            Assert.AreEqual(false, meetsOrangeCriteria);
        }


    }
}
