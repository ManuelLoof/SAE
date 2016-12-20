using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE.AdventureWorks.BuisnessLogic;

namespace SAE.AventureWorks.BuisnessLogic.Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void InitTest()
        {
            var person = new Person(1);

            Assert.AreEqual("Ken", person.FirstName);
            Assert.AreEqual("Sánchez", person.LastName);
            Assert.AreEqual("", person.Title);

        }
    }
}
