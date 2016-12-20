using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JExample
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "sae")))
            using (var session = driver.Session())
            {

                var result = session.Run("MATCH (a:Person) WHERE a.name = 'Tom Hanks' RETURN a.name");

                foreach (var record in result)
                {
                    Console.WriteLine($"{record["a.name"].As<string>()}");
                }
            }


            Console.ReadKey();

        }
    }
}
