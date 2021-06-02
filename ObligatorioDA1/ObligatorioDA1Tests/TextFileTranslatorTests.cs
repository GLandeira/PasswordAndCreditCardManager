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
        public void TestTextBoxTranslatorGeneratesCorrectAmountOfStrings()
        {
            string _test = "abc/t123"; //‘\t

            Assert.AreEqual(2, _translator.Translate(_test).Length);
        }
    }
}
