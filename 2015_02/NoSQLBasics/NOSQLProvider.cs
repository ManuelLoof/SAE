using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQLBasics
{

   

    class NOSQLProvider : IDisposable
    {

        string _documentStoreLocation = @"http://localhost:8080";
        string _databaseName = @"ravenTest";
        DocumentStore _documentStore;

        public NOSQLProvider()
        {
            _documentStore = new DocumentStore() { Url =  _documentStoreLocation, DefaultDatabase = _databaseName };
            _documentStore.Initialize();


        }

        public void AddPatienten()
        {
            var patient1 = new Patient()
            {
                Krankheit = new List<Patient.Krankheiten>() { Patient.Krankheiten.Blinddarmentzuendung },
                VorName = "Manuel",
                NachName = "Meier"
                //Titel = "Dr."
            };

            var patient2 = new Patient()
            {
                Krankheit = new List<Patient.Krankheiten>() { Patient.Krankheiten.Schnupfen,
                    Patient.Krankheiten.Schlaganfall},
                VorName = "Daniel",
                NachName = "Schmidt"
                //Titel = "Prof."
            };

            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(patient1);
                session.Store(patient2);

                session.SaveChanges();

            }
        }

        public void GetPatienten(string name)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                var patienten = session.Query<Patient>().Where(p => p.ID == 0);

                foreach(var patient in patienten)
                {
                    Console.WriteLine(patient);
                }

            }

        }

        public void Dispose()
        {
            _documentStore.Dispose();
        }


    }
}
