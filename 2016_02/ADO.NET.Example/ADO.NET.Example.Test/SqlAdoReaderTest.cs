using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ADO.NET.Example.Test
{
    [TestClass]
    public class SqlAdoReaderTest
    {

        #region class members

        string _connectionString = "Server=INSPIRON;" +
                                        "Database=SAE_RolePlayingGame;" +
                                        "Integrated Security=True";


        #endregion

        /// <summary>
        /// Testet ob wir eine Connection zu unserer Datenbank aufbauen können.
        /// </summary>
        [TestMethod]
        public void TestConnection()
        {
            SqlAdoReader sqlAdoReader = CreateDatabase();

            Assert.AreEqual(true, sqlAdoReader.Connect(), "Konnte keine Connection zur Datenbank aufbauen.");



        }

        

        /// <summary>
        /// Testet das holen von Daten aus dem SQL Server.
        /// </summary>
        [TestMethod]
        public void GetDataTest()
        {

            var sqlAdoReader = CreateDatabase();

            Assert.AreEqual(true, sqlAdoReader.Connect());
            Assert.AreEqual("1;Earl;6;4;370233;3;98;nsb61l;\r\n", sqlAdoReader.GetData("Select top 1 * from players;"));

        }


        /// <summary>
        /// Testet sich ein Benutzer anmelden kann.
        /// </summary>
        [TestMethod]
        public void AnmeldungTest()
        {
            var sqlAdoReader = CreateDatabase();
            sqlAdoReader.Connect();

            var name = "Earl";
            var password = "nsb61l";

            var erg = sqlAdoReader.GetData($"Select id from players where name = '{name}' and password='{password}';");



            Assert.AreEqual("1;\r\n", erg);




        }


        /// <summary>
        /// Simuliert einen SQL Injection Angriff.
        /// </summary>
        [TestMethod]
        public void BoeseAnmeldungTest()
        {
            var sqlAdoReader = CreateDatabase();
            sqlAdoReader.Connect();

            var name = "' OR ID='1'; --";
            var password = "";

            var erg = sqlAdoReader.GetData($"Select id from players where name = '{name}' and password='{password}';");



            Assert.AreEqual("1;\r\n", erg);




        }



        #region private methods

        /// <summary>
        /// Erstellt eine Datenconnection.
        /// </summary>
        /// <returns></returns>
        private SqlAdoReader CreateDatabase() => new SqlAdoReader(_connectionString);


        #endregion


    }
}
