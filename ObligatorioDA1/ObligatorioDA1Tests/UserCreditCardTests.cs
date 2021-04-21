using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainTests
{
    [TestClass]
    public class UserCreditCardTests
    {
        [TestMethod]
        public void addOneCreditCardToList()
        {
            UserCreditCard test1 = new UserCreditCard();
            Category trabajo = new Category("Trabajo");
            CardTypes visa = CardTypes.VISA;
            test1.AddCreditCard("Visa Gold", visa, "1111 1111 1111 1111", "024", DateTime.Today, trabajo, "super secreta, no compartir");
            Assert.AreEqual(1, test1.creditCards.Count);
        }
    }
}
