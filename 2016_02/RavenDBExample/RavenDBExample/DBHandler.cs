using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RavenDBExample
{
    public class DBHandler : IDisposable
    {

        #region class member

        private string dbLocation = "http://localhost:8080";
        private string dbStore = "sae_game";
        private DocumentStore _documentStore;

        #endregion

        #region constructor

        public DBHandler()
        {
            try
            {
                _documentStore = new DocumentStore { Url = dbLocation, DefaultDatabase = dbStore };
                _documentStore.Initialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Falls wir keine Verbindung zur Datenbank aufbauen können, geben wir einfach false zurück und werfen
                // keine Exception.
            }
        }

    #endregion

    #region public methods

    /// <summary>
    /// Fügt ein neues Objekt zu unserer Datenbank hinzu.
    /// </summary>
    /// <param name="player">Ein Spieler Objekt.</param>
    /// <returns>True, falls erfolgreich.</returns>
    public bool Add<T>(T o)
    {    

        using (IDocumentSession session = _documentStore.OpenSession())
        {

            session.Store(o);
            session.SaveChanges();
            return true;
        }   

    }

        public void Dispose()
        {
            _documentStore.Dispose();
        }


        /// <summary>
        /// Liefert ein Player Objekt zurück.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Player> GetPlayerByName(string name)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Player>().Where(p => p.Name == name).ToList();
                
            }
        }

        /// <summary>
        /// Liefert ein Player Objekt zurück.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Player> GetPlayerByID(Guid guid)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Player>().Where(p => p.ID == guid).ToList();

            }
        }


        /// <summary>
        /// Liefert ein Player Objekt zurück.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Player> GetPlayer(Expression<Func<Player,bool>> ausdruck )
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<Player>().Where(ausdruck).ToList();

            }
        }


        public List<T> GetObject<T>(Expression<Func<T, bool>> ausdruck)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<T>().Where(ausdruck).ToList();

            }
        }


        #endregion



    }
}
