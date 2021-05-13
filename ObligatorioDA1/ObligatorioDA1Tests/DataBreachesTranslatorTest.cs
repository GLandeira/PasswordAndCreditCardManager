using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.DataBreachesTranslator;

namespace DomainTests
{
    /// <summary>
    /// Summary description for DataBreachesTranslatorTest
    /// </summary>
    [TestClass]
    public class DataBreachesTranslatorTest
    {
        public DataBreachesTranslatorTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
    }
}
