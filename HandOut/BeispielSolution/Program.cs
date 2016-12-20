using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Example;

namespace ConsoleDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new DBProvider();

            Console.WriteLine("Bitte geben Sie Ihren Usernamen ein.");
            var userName = Console.ReadLine();

            // "' OR ID='1'; --"
            // "' OR 1='1'; --"
            Console.WriteLine("Bitte geben Sie ihr Password ein.");
            var userPassword = Console.ReadLine();

            db.DoCommand($"Select * from players where name='{userName}' and password='{userPassword}';", reader =>
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Welcome {reader["name"]}");
                }
            });

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}
