using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Example
{
    public class EntityFrameworkExample
    {

        public void EinfacheAbfrage()
        {
            using (var dbContext = new AdventureWorks2014Entities())
            {
                var persons = from p in dbContext.Person
                              where p.EmailPromotion == 2 
                              select p;


                int zahl = 1;
                zahl++;
                zahl++;
                zahl++;
                zahl++;
                zahl++;
                zahl++;
                
                

                persons.ToList().ForEach(p => Console.WriteLine(p.EmailAddress.FirstOrDefault()?.EmailAddress1));


            }
        }


        public void EditData()
        {
            using (var dbContext = new AdventureWorks2014Entities())
            {

                var personsToEdit = from p in dbContext.Person
                                    where p.BusinessEntityID == 1
                                    select p;

                var person = personsToEdit.FirstOrDefault();

                if (person != null)
                {
                    person.MiddleName = "James";

                }

                Console.WriteLine($"{dbContext.SaveChanges()} Datensätze manipuliert.");

            }
        }

        public void AddNewData()
        {
            using (var dbContext = new AdventureWorks2014Entities())
            {

                var email = new EmailAddress()
                {
                    BusinessEntityID = 1,
                    EmailAddress1 = "james@google.com",
                    rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                };

                dbContext.EmailAddress.Add(email);
                Console.WriteLine(dbContext.SaveChanges());

            }

        }
    }
}
