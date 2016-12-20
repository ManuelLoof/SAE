using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADO.Net;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

namespace ADO.Net.Test
{
    /// <summary>
    /// Testklasse für meinen ADO.net Provider.
    /// </summary>
    [TestClass]
    public class AdoNetTest
    {

        private const string _connectionString = "Server=INSPIRON;" +
                                                    "Database=SAE_RolePlayingGame;" +
                                                    "Integrated Security=True";

        /// <summary>
        /// Testet die Verbinung zur Datenbank.
        /// </summary>
        [TestMethod]
        public void ConnectTest()
        {
            using (var dbProvider = new DBProvider())
            {
                Assert.AreEqual(true, dbProvider.Connect(_connectionString));
            }

        }

        /// <summary>
        /// Testet eine SQL Abfrage.
        /// </summary>
        [TestMethod]
        public void DoCommandTest()
        {
            using (var dbProvider = new DBProvider())
            {
                dbProvider.Connect(_connectionString);

                Assert.AreEqual(-1, dbProvider.DoCommand("Select * from player;"));
            }
        }

        /// <summary>
        /// Testet eine SQL Abfrage.
        /// </summary>
        [TestMethod]
        public void DoCommand2Test()
        {
            using (var dbProvider = new DBProvider())
            {
                dbProvider.Connect(_connectionString);

                Assert.AreEqual(1, dbProvider.DoCommand("INSERT INTO items (name) values ('TestItem');"));
            }
        }


        [TestMethod]
        public void DoCommandSqlDataReaderTest()
        {
            using (var dbProvider = new DBProvider())
            {
                dbProvider.Connect(_connectionString);


                SqlDataReader data = dbProvider.DoCommandSqlDataReader("Select * from players;");


                var outPut = new StringBuilder();

                while (data.Read())
                {
                    for (int i = 0; i < data.FieldCount; i++)
                    {
                        outPut.Append($"{data.GetValue(i).ToString().PadRight(15)}|");
                    }

                    outPut.AppendLine(); 
                }

                //Console.ReadKey();
            }

        }


        [TestMethod]
        public void CheckPasswortSqlInjection()
        {
            using (var dbProvider = new DBProvider())
            {
                dbProvider.Connect(_connectionString);

                var password = "96siA5k1LPdI";
                password = "' OR ID='1'; --";

                SqlDataReader data = dbProvider.DoCommandSqlDataReader($"Select * from players where password='{password}';");

                int anzahl = 0;

                while (data.Read())
                {
                    anzahl++;
                }

                Assert.AreEqual(1, anzahl); 
            }

        }

        [TestMethod]
        public void CheckPasswortSqlInjectionFail()
        {
            using (var dbProvider = new DBProvider())
            {
                dbProvider.Connect(_connectionString);

                var password = "' OR ID='1'; --";
                //password = "96siA5k1LPdI";

                var sqlPara = new SqlParameter("@passwort",password);

                SqlDataReader data = dbProvider.DoCommandSqlDataReader($"Select * from players where password=@passwort;", new List<SqlParameter>() { sqlPara });

                int anzahl = 0;

                while (data.Read())
                {
                    anzahl++;
                }

                Assert.AreEqual(1, anzahl);
            }

        }

    }
}
