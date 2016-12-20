using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADO.NET.Data;

namespace ADO.NET.Data.Test
{
    [TestClass]
    public class DBProviderTest
    {
        [TestMethod]
        public void Connect()
        {

            var db = new DBProvider();

            int anzahl = 0; 

            db.DoCommand("Select Top 10 * from Person.Person", reader =>
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i].ToString().PadRight(10) + "|");
                        }
                        Console.WriteLine();
                        anzahl++;
                    }
                    reader.Close();
                }
            );



            Assert.AreEqual(10, anzahl,"Die Anzahl der erwarteten Datensaetze passt nicht über ein.");

            

        }

        [TestMethod]
        public void UserAnmeldungTest()
        {
            string connectionString = "Server=INSPIRON;" +
                                        "Database=Benutzerverwaltung;" +
                                        "Integrated Security=True";

            var db = new DBProvider(connectionString);

            //string userName = "jgreene01";
            string userName = "' OR 1=1 --";
            string password = "1096d4926855515ac0f45686aa7af87f18ecfb8b";
            int i = 0;

            db.DoCommand($"SELECT * FROM Benutzer WHERE nickname='{userName}' and password='{password}';", r =>
            {

                while (r.Read())
                {
                    i++;
                }
            }
            );


            Assert.AreEqual(1, i);


        }

        [TestMethod]
        public void UserAnmeldungIITest()
        {
            string connectionString = "Server=INSPIRON;" +
                                        "Database=Benutzerverwaltung;" +
                                        "Integrated Security=True";

            var db = new DBProvider(connectionString);

            string userName = "' OR 1=1 --";
            string password = "1096d4926855515ac0f45686aa7af87f18ecfb8b";
            int i = 0;

            db.DoCommand($"SELECT * FROM Benutzer WHERE nickname='{userName}' and password='{password}';", r =>
            {

                while (r.Read())
                {
                    i++;
                }
            }
            );


            Assert.AreEqual(1, i);


        }

    }
}
