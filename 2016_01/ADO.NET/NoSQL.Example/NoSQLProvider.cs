using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL.Example
{
    public class NoSQLProvider
    {

        private const string CConnectionString = "http://localhost:8080";
        private const string CDBName = "NoSQLExample";


        /// <summary>
        /// Öffnet die Verbindung zu unserer Datebank.
        /// </summary>
        public void OpenConnection()
        {
            var documentStore = new DocumentStore() { Url = CConnectionString, DefaultDatabase = CDBName };
            documentStore.Initialize();
        }

        /// <summary>
        /// Speichert Objekte in unsere Datebank.
        /// </summary>
        public void SaveObjects()
        {
            using (var documentStore = new DocumentStore() { Url = CConnectionString, DefaultDatabase = CDBName })
            {
                documentStore.Initialize();

                using (var session = documentStore.OpenSession())
                {
                    //var cars =  GenerateCars();

                    //cars.ForEach(c => session.Store(c));

                    var car = new Car()
                    {
                        Color = Car.CarColor.Silver,
                        Name = "A4",
                        HP = 100,
                        //RimSize = 50.1f,
                        VMax = 210

                    };

                    session.Store(car);

                    session.SaveChanges();

                }



            }
        }

        public void ManipulateData()
        {
            using (var documentStore = new DocumentStore() { Url = CConnectionString, DefaultDatabase = CDBName })
            {
                documentStore.Initialize();

                using (var session = documentStore.OpenSession())
                {

                    var cars = session.Query<Car>().Where(c => c.HP > 50).ToList();

                    foreach (var car in cars)
                    {
                        if (car.RimSize == null)
                            car.RimSize = 17.0f; 

                    }


                    session.SaveChanges();                     



                }



            }

        }


        /// <summary>
        /// Speichert Objekte in unsere Datebank.
        /// </summary>
        public void GetObjects()
        {
            using (var documentStore = new DocumentStore() { Url = CConnectionString, DefaultDatabase = CDBName })
            {
                documentStore.Initialize();

                using (var session = documentStore.OpenSession())
                {
                    var cars = session.Query<Car>().Where(c => c.HP > 50).ToList();


                    var output = new StringBuilder();

                    cars.ForEach(c => output.AppendLine(c.ToString()));



                }



            }
        }


        private static List<Car> GenerateCars()
        {
            var car1 = new Car()
            {
                Color = Car.CarColor.Blue,
                HP = 171,
                Name = "Octavia",
                VMax = 235

            };

            var car2 = new Car()
            {
                Color = Car.CarColor.Black,
                HP = 420,
                Name = "911",
                VMax = 301

            };

            var car3 = new Car()
            {
                Color = Car.CarColor.Red,
                HP = 350,
                Name = "Spider",
                VMax = 290

            };

            return new List<Car>() { car1, car2, car3 };
 
        }
    }
}
