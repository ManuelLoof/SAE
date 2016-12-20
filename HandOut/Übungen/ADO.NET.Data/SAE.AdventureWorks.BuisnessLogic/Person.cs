using ADO.NET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE.AdventureWorks.BuisnessLogic
{
    public class Person
    {

        #region properties

        /// <summary>
        /// Der Nachname.
        /// </summary>
        public string LastName { get; set; }


        /// <summary>
        /// Der Vorname.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Der Titel der Person.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Die ID der Person.
        /// </summary>
        public int ID { get; private set; }

        #endregion


        #region class variables

        DBProvider _db;

        #endregion


        #region constructor

        public Person(int id)
        {
            ID = id; 
            Init();
            InitData(); 
        }

        #endregion

        #region private methods

        /// <summary>
        /// Initialisiert meine Klassenvaraiblen.
        /// </summary>
        private void Init()
        {
            _db = new DBProvider();
        }

        /// <summary>
        /// Holt sich die Daten aus der Datenbank und füllt die entsprechenden Eigenschaften.
        /// </summary>
        private void InitData()
        {
            _db.DoCommand($"Select LastName, FirstName, BusinessEntityID, Title FROM Person.Person WHERE BusinessEntityID={ID}",reader =>
            {
                if(reader.Read())
                {
                    LastName = reader["LastName"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    Title = reader["Title"].ToString();
                }
            }
            );
        }

        #endregion

    }
}
