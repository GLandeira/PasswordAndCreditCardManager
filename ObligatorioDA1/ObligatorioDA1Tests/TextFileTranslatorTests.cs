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
    }
}
