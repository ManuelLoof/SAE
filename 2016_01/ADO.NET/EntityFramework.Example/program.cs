using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Example
{
    public static class program
    {
        public static void Main(string[] args)
        {

            var db = new EntityFrameworkExample();
            db.EinfacheAbfrage();
            //db.EditData();
            //db.AddNewData();

            Console.ReadKey(); 

        }
    }
}
