using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADO.NET.Example;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ADO.NET.Example.Test
{
    [TestClass]
    public class DBProviderTest
    {
        [TestMethod]
        public void SqlReaderTest()
        {
            var db = new DBProvider();


            db.DoCommand("Select * from players;", reader =>
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write("{0}|", (reader.GetValue(i).ToString().PadRight(15)));
                    }

                    Console.WriteLine();
                }
            });


        }

        [TestMethod]
        public void DataSetTest()
        {
            var db = new DBProvider();

            db.DataSet();


        }

        [TestMethod]
        public void PasswrodTest()
        {
            var db = new DBProvider();

            var password = "96siA5k1LPdI";

            db.DoCommand($"Select * from players where password='{password}';", reader =>
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write("{0}|", (reader.GetValue(i).ToString().PadRight(15)));
                    }

                    Console.WriteLine();
                }
            });

        }

        [TestMethod]
        public void SQLInjectionTest()
        {
            var db = new DBProvider();

            var password = "' OR ID='1'; --";

            db.DoCommand($"Select * from players where password='{password}';", reader =>
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write("{0}|", (reader.GetValue(i).ToString().PadRight(15)));
                    }

                    Console.WriteLine();
                }
            });

        }


        [TestMethod]
        public void SQLInjectionFailTest()
        {
            var db = new DBProvider();

            var password = "' OR ID='1'; --";

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@password";
            p1.Value = password;

            db.DoCommand($"Select * from players where password=@password;", reader =>
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write("{0}|", (reader.GetValue(i).ToString().PadRight(15)));
                    }

                    Console.WriteLine();
                }
            }, new List<SqlParameter>() { p1 });

        }


        [TestMethod]
        public void DoCommandNonQueryTest()
        {
            var db = new DBProvider();
            Assert.AreEqual(1,db.DoCommandNonQuery("insert into Players (name, rasseID, klasseID, muenzen, level, energie) values ('Earl', 6, 4, 370233, 3, 98);"));
        }


    }
}
