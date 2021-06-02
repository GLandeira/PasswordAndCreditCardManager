using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace DomainTests
{
    /// <summary>
    /// Summary description for EffortlessEncryptorWrapperTests
    /// </summary>
    [TestClass]
    public class EffortlessEncryptorWrapperTests
    {
        
        private string _string1;
        private string _string2;
        private string _string3;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _string1 = "papas";
            _string2 = "mayonesa123";
            _string3 = "%Sa2@4loPlaAws124324_";
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestEncrypt1()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
