using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoSQL.RavenDB.Example.Test
{
    [TestClass]
    public class RavenDBProviderTest
    {
        [TestMethod]
        public void RavenTest()
        {
            RavenDBProvider.Run(); 
        }

        [TestMethod]
        public void GetDataTest()
        {
            var users =  RavenDBProvider.GetData();


            Assert.AreEqual(1024,users.Count);

        }

        [TestMethod]
        public void DeleteData()
        {
            RavenDBProvider.DeleteData();

        }

        [TestMethod]
        public void ManipulateData()
        {
            RavenDBProvider.ManipulateData();

        }


        [TestMethod]
        public void CountAllTest()
        {
            var usersCount  = RavenDBProvider.CountAll();

            Assert.AreEqual(2062004, usersCount);

        }


        [TestMethod]
        public void CreateIndexTest()
        {
            RavenDBProvider.CreateDynamicIndex();
        }


        [TestMethod]
        public void CreateStaticIndexTest()
        {
            RavenDBProvider.CreateStaticIndex();
        }

        [TestMethod]
        public void DeleteStaticIndexTest()
        {
            RavenDBProvider.DeleteStaticIndex();
        }


        [TestMethod]
        public void GetStreamedDocsTest()
        {
            RavenDBProvider.GetStreamedDocs();
        }


    }
}
