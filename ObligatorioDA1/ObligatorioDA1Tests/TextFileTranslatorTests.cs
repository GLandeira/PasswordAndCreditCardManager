using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataBreachesTranslator;

namespace DomainTests
{

    [TestClass]
    public class TextFileTranslatorTests
    {
        private ITranslator _translator;
        private string _test;

        [TestInitialize]
        public void TestInitialize()
        {
            _translator = new TextFileTranslator();
        }

        [TestMethod]
        public void TestTextFileTranslatorGeneratesCorrectAmountOfStrings()
        {
            _test = "abc\t123";

            Assert.AreEqual(2, _translator.Translate(_test).Length);
        }

        [TestMethod]
        public void TestTextFileTranslatorGeneratesCorrectAmountOfStringsComplicated()
        {
            _test = "abc asgasg\t123asasf\tasfdasf asgf\t\t\tasfasflll";

            Assert.AreEqual(4, _translator.Translate(_test).Length);
        }

        [TestMethod]
        public void TestFileBoxTranslatorGetsStringsRight()
        {
            string string1 = "johnas";
            string string2 = "p$$5asA@";
            string string3 = "af  aasf  Kak";
            string testString = string1 + "\t" + string3 + "\t" + string2;

            string[] result = _translator.Translate(testString);

            Assert.AreEqual(string1, result[0]);
            Assert.AreEqual(string2, result[2]);
            Assert.AreEqual(string3, result[1]);
        }

        [TestMethod]
        public void TestFileBoxTranslatorGetsStringsRightComplicated()
        {
            string string1 = "johnas";
            string string2 = "p$$5asA@" + "\t";
            string string3 = "af #%%#%f";
            string string4 = "24241124";
            string testString = string2 + "\t" + string4 + "\t" + string1 + "\t" + string3
                                + "\t" + string3 + string4;

            string[] result = _translator.Translate(testString);

            Assert.AreEqual(string1, result[2]);
            Assert.AreEqual(string2.Substring(0, string2.Length - 1), result[0]);
            Assert.AreEqual(string3, result[3]);
            Assert.AreEqual(string4, result[1]);
            Assert.AreEqual(string3 + string4, result[4]);
        }
    }
}
