using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkUebung
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var dbContext = new AdventureWorks2014Entities())
            {

                var test = from person in dbContext.Person
                           where person.LastName.StartsWith("M")
                           select person;



                foreach(var p in test.ToList())
                {
                    Console.WriteLine(p.FirstName);
                }


            }

            Console.ReadKey();

        }
    }
}
