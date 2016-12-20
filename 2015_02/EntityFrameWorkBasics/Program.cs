using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkBasics
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new DbProvider())
            {
                var personen = db.GetFirstNameWithCharM().ToList();

                personen.ForEach(p => Console.WriteLine(p.FirstName));

                Console.ReadLine();

                db.AddCharSToFirstNameWithCharM();
                

                Console.WriteLine($"Saved: {db.Save()}");
                Console.ReadLine();

                personen = db.GetFirstNameWithCharM().ToList();
                personen.ForEach(p => Console.WriteLine(p.FirstName));

            }

            Console.ReadLine(); 

        }
    }
}
