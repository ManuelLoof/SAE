using Raven.Client.Document;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Indexes;

namespace NoSQL.RavenDB
{
    public class RavenDBProvider
    {

        public static string documentStoreLocation = @"http://localhost:8080";
        public static string testDatabase = @"ravenTest";


        public static void Run()
        {
           
            using (var documentStore = new DocumentStore { Url = documentStoreLocation, DefaultDatabase = testDatabase })
            {

                documentStore.Initialize();

                for (int y = 0; y < 1000; y++)
                {

                    using (IDocumentSession session = documentStore.OpenSession())
                    {   
                        for (int i = 0; i < 1000; i++)
                        {
                            var userI = new User() { FirstName = "Daniel", LastName = "Springwald" };
                            var userII = new User() { FirstName = "Manuel", LastName = "Loof" };

                            session.Store(userI);
                            session.Store(userII);

                        }

                        session.SaveChanges();
                    }
                }
            }
        }

        public static void DeleteData()
        {
            using (var documentStore = new DocumentStore { Url = documentStoreLocation, DefaultDatabase = "ravenTest" })
            {

                documentStore.Initialize();


                IList<User> blogs = new List<User>();
                using (IDocumentSession session = documentStore.OpenSession())
                {
                    blogs = session.Query<User>().Where(u => u.FirstName == "Manuel").Take(int.MaxValue).ToList();

                    foreach(var blog in blogs)
                    {
                        session.Delete(blog); 
                    }

                    session.SaveChanges();

                }
            }
        }


        public static void ManipulateData()
        {
            using (var documentStore = new DocumentStore { Url = documentStoreLocation, DefaultDatabase = "ravenTest" })
            {

                documentStore.Initialize();


                IList<User> blogs = new List<User>();
                using (IDocumentSession session = documentStore.OpenSession())
                {
                    blogs = session.Query<User>().Where(u => u.FirstName == "Manuel").Take(int.MaxValue).ToList();


                    int i = 1;
                    foreach (var blog in blogs)
                    {
                        blog.FirstName += i++; 
                    }

                    session.SaveChanges();

                }
            }
        }



        public static IList<User> GetData()
        {
            using (var documentStore = new DocumentStore { Url = documentStoreLocation, DefaultDatabase = "ravenTest" })
            {

                documentStore.Initialize();


                IList<User> blogs = new List<User>();
                using (IDocumentSession session = documentStore.OpenSession())
                {
                    blogs = session.Query<User>().Where(u => u.FirstName == "Manuel").Take(int.MaxValue).ToList();

                    // Klappt leider noch nicht!
                    // blogs = from u in session.Query<User>()
                    //        where u.FirstName == "Manuel"
                    //        select u;

                }

                return blogs;

            }

        }

        public static int CountAll()
        {
            using (var documentStore = new DocumentStore { Url = documentStoreLocation, DefaultDatabase = "ravenTest" })
            {

                documentStore.Initialize();

                using (IDocumentSession session = documentStore.OpenSession())
                {
                    var stats = new RavenQueryStatistics();
                    var query = session.Query<User>().Statistics(out stats).ToList();

                    return stats.TotalResults; 

                    //var enumerator = session.Advanced.Stream<User>(query);

                    //documentStore.DatabaseCommands.StreamDocs(null, "user/");

                    //int count = 0;
                    //while (enumerator.MoveNext())
                    //{
                    //    count++;
                    //}
                    //return count;
                }
            }


        }
        
        public static void CreateDynamicIndex()
        {
            using (var documentStore = new DocumentStore { Url = documentStoreLocation, DefaultDatabase = "ravenTest" })
            {

                documentStore.Initialize();

                new Users_ByFirstAndLastName().Execute(documentStore);
            }
            
        }

        public static void CreateStaticIndex()
        {
            using (var documentStore = new DocumentStore { Url = documentStoreLocation, DefaultDatabase = "ravenTest" })
            {
                documentStore.Initialize();

                // Create an index where we search based on a post title
                documentStore.DatabaseCommands.PutIndex("Users/ByFirstName",
                                                    new IndexDefinitionBuilder<User>
                                                    {
                                                        Map = users => from user in users
                                                                       select new { user.FirstName}
                                                    });
            }
        }


        public static void DeleteStaticIndex()
        {
            using (var documentStore = new DocumentStore { Url = documentStoreLocation, DefaultDatabase = "ravenTest" })
            {
                documentStore.Initialize();

                // Create an index where we search based on a post title
                documentStore.DatabaseCommands.DeleteIndex("Users/ByFirstNameLastName");
                                                    
            }
        }




        public static void GetStreamedDocs()
        {
            using (var documentStore = new DocumentStore { Url = documentStoreLocation, DefaultDatabase = "ravenTest" })
            {

                documentStore.Initialize();

                using (IDocumentSession session = documentStore.OpenSession())
                {

                    var query = session.Query<User>("Auto/Users/ByFirstNameSortByFirstName").Where(u => u.FirstName == "Manuel");
                    var enumerator = session.Advanced.Stream<User>(query);

                    int i = 0;

                    while (enumerator.MoveNext())
                    {
                        Console.WriteLine(enumerator.Current.Document.FirstName);
                        i++;

                        if (i > 10000) // Reicht für Debugzwecke.
                            break; 
                    }

                }
            }
            
        }
        
    }
}
