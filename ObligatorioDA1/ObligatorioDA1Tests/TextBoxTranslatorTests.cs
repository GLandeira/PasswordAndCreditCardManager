using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataBreachesTranslator;

namespace DomainTests
{

    [TestClass]
    public class TextBoxTranslatorTests
    {
        [TestMethod]
        public void TestTextBoxTranslatorGeneratesCorrectAmountOfStrings()
        {
            ITranslator translator = new TextBoxTranslator();
            string testString = "abc" + Environment.NewLine + "123";

            Assert.AreEqual(2, translator.Translate(testString).Length);
        }

        [TestMethod]
        public void TestTextBoxTranslatorGeneratesCorrectAmountOfStringsComplicated()
        {
            ITranslator translator = new TextBoxTranslator();
            string testString = "abc asgasg" + Environment.NewLine + "123asasf" + Environment.NewLine + "asfdasf asgf"
                                + Environment.NewLine + Environment.NewLine + "asfasflll";

            Assert.AreEqual(4, translator.Translate(testString).Length);
        }

        [TestMethod]
        public void TestTextBoxTranslatorGetsStringsRight()
        {
            ITranslator translator = new TextBoxTranslator();
            string string1 = "johnas";
            string string2 = "p$$5asA@";
            string string3 = "af  aasf  Kak";
            string testString = string1 + Environment.NewLine + string3 + Environment.NewLine + string2;

            string[] result = translator.Translate(testString);

            Assert.AreEqual(string1, result[0]);
            Assert.AreEqual(string2, result[2]);
            Assert.AreEqual(string3, result[1]);
        }

        [TestMethod]
        public void TestTextBoxTranslatorGetsStringsRightComplicated()
        {
            ITranslator translator = new TextBoxTranslator();
            string string1 = "johnas";
            string string2 = "p$$5asA@" + Environment.NewLine;
            string string3 = "af #%%#%f";
            string string4 = "24241124";
            string testString = string2 + Environment.NewLine + string4 + Environment.NewLine + string1 + Environment.NewLine + string3
                                + Environment.NewLine + string3 + string4;

            string[] result = translator.Translate(testString);

            Assert.AreEqual(string1, result[2]);
            Assert.AreEqual(string2.Substring(0, string2.Length - 2), result[0]);
            Assert.AreEqual(string3, result[3]);
            Assert.AreEqual(string4, result[1]);
            Assert.AreEqual(string3 + string4, result[4]);
        }
    }
}
