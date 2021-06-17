using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain.Helpers;

namespace DomainTests
{
    [TestClass]
    public class ByteArrayStringTranslationTests
    {
        [TestMethod]
        public void StringToByteLengthTest()
        {
            string testString = "hola";
            byte[] resultGenerated = ByteArrayStringTranslator.ToByteArray(testString);

            Assert.AreEqual(4, resultGenerated.Length);
        }

        [TestMethod]
        public void StringToByteTest()
        {
            string testString = "123hola";

            byte[] expectedResult = new byte[] { 49, 50, 51, 104, 111, 108, 97 };
            byte[] resultGenerated = ByteArrayStringTranslator.ToByteArray(testString);
            bool rightResult = true;

            for(int i = 0; i < resultGenerated.Length; i++)
            {
                rightResult = rightResult && (expectedResult[i] == resultGenerated[i]);
            }

            Assert.IsTrue(rightResult);
        }

        [TestMethod]
        public void ByteToStringLengthTest()
        {
            byte[] testByteArray = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 20 };
            string resultGenerated = ByteArrayStringTranslator.ToString(testByteArray);

            Assert.AreEqual(9, resultGenerated.Length);
        }

        [TestMethod]
        public void ByteToStringTest()
        {
            byte[] testByteArray = new byte[] { 97, 108, 111, 104 };

            string expectedResult = "aloh";
            string resultGenerated = ByteArrayStringTranslator.ToString(testByteArray);

            Assert.AreEqual(expectedResult, resultGenerated);
        }
    }
}
