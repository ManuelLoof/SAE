using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoSQL.Example;

namespace NoSQL.Example.Test
{
    [TestClass]
    public class DBProviderTest
    {
        [TestMethod]
        public void OpenConnection()
        {
            var db = new NoSQLProvider();
            db.OpenConnection(); 

        }

        [TestMethod]
        public void SaveData()
        {
            var db = new NoSQLProvider();
            db.SaveObjects();

        }

        [TestMethod]
        public void GetConnection()
        {
            var db = new NoSQLProvider();
            db.GetObjects();

        }


        [TestMethod]
        public void ManipulateData()
        {
            var db = new NoSQLProvider();
            db.ManipulateData();

        }
    }
}
