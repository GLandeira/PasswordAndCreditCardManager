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
            string testString = "abc asgasg" + Environment.NewLine + "123asasf" + Environment.NewLine + "asfdasf asgf"
                                + Environment.NewLine + Environment.NewLine + "asfasflll";

            Assert.AreEqual(4, translator.Translate(testString).Length);
        }
    }
}
