using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL.RavenDB
{
    public class Users_ByFirstAndLastName : AbstractIndexCreationTask<User>
    {
        public Users_ByFirstAndLastName()
        {
            Map = users => from user in users
                               select new
                               {
                                   FirstName = user.FirstName,
                                   LastName = user.LastName
                               };
        }
    }
}
