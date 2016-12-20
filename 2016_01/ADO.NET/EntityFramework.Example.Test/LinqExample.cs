using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework.Example.Test
{
    [TestClass]
    public class LinqExample
    {
        [TestMethod]
        public void StandardAbfrage()
        {
            List<Human> menschen = GenerateHumans();
            List<Human> alteMenschen = new List<Human>();

            // Klassische Variante
            foreach (Human mensch in menschen)
            {
                if (mensch.Age > 40)
                    alteMenschen.Add(mensch);
            }


            // Mit Lambdas
            var alteMenschenLambda = menschen.Where(h => h.Age > 40).Select(h => new { h.Age, h.Name });


            // Mit Linq Syntax
            var alteMenschenLinq = from h in menschen
                                   where h.Age > 40
                                   select new
                                   {
                                       h.Age,
                                       h.Name
                                   };


            alteMenschenLinq.ToList();



        }

        [TestMethod]
        public void MethodExtensionTest()
        {
            Assert.AreEqual("Bestimmt nicht ist Manu ist der coolste! ;-)", "Bestimmt nicht ist ".AddManu());
        }

        #region private methods

        private List<Human> GenerateHumans()
        {
            var humans = new List<Human>();

            humans.Add(new Human() { Age = 45, Name = "Klaus", Size = 198, Weight = 91 });
            humans.Add(new Human() { Age = 18, Name = "Wolfgang", Size = 162, Weight = 132 });
            humans.Add(new Human() { Age = 55, Name = "Frauke", Size = 170, Weight = 132 });

            return humans;

        }

        #endregion

    }
}
