using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQLBasics
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var dbProvider = new NOSQLProvider())
            {
                //dbProvider.AddPatienten();
                dbProvider.GetPatienten("Schmidt");

                Console.ReadLine(); 
            }
        }
    }
}
