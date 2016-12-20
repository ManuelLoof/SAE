using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFramework.ModellFirst;

namespace EntityFramework.ModellFirst.Test
{
    [TestClass]
    public class EntityModellFirstTest
    {
        [TestMethod]
        public void ReadDataTest()
        {

            var rolePlayer = new EntityModellFirst();

            rolePlayer.ReadData(); 

        }

        [TestMethod]
        public void ReadDataJoinTest()
        {

            var rolePlayer = new EntityModellFirst();

            rolePlayer.ReadDataJoin();

        }

        [TestMethod]
        public void ManipulateData()
        {

            var rolePlayer = new EntityModellFirst();

            rolePlayer.ManipulateData();

        }

        [TestMethod]
        public void AddDataTest()
        {

            var rolePlayer = new EntityModellFirst();

            rolePlayer.AddData();

        }

        [TestMethod]
        public void DeleteDataTest()
        {

            var rolePlayer = new EntityModellFirst();

            rolePlayer.DeleteData();

        }

    }
}
