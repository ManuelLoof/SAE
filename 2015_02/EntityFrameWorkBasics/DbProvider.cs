using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkBasics
{
    /// <summary>
    /// Unsere Testklasse zum Zugriff auf unsere Datenbank via EntitityFramework
    /// </summary>
    public class DbProvider : IDisposable
    {

        private AdventureWorks2014Entities dbContext;

        public DbProvider()
        {
            CreateDBContext();
        }

        /// <summary>
        /// Testbeispiel zum Zugriff auf unsere Daten und Filterung
        /// nach Personen dessen Vorname mit M beginnt.
        /// </summary>
        public IQueryable<Person> GetFirstNameWithCharM()
        {
            var person = from p in dbContext.Person
                            where p.FirstName.StartsWith("M")
                            select p;


            return person; 

        }


        public void AddCharSToFirstNameWithCharM()
        {
            var personen = GetFirstNameWithCharM();

            var personenListe = personen.ToList();


            foreach(var person in personenListe)
            {
                person.FirstName = person.FirstName + "s";
            }

        }

        public int Save()
        {
            return dbContext.SaveChanges(); 
        }

        private void CreateDBContext()
        {
            dbContext = new AdventureWorks2014Entities();
            
        }

        public void Dispose()
        {
            dbContext.Dispose(); 
        }
    }
}
