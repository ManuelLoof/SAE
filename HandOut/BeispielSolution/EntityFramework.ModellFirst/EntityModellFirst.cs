using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.ModellFirst
{
    public class EntityModellFirst
    {

        public void ReadData()
        {
            using (var db = new SAE_RolePlayingGameEntities())
            {

                var players = from p in db.Players
                              where p.ID == 1
                              select p;

                players.ToList().ForEach(p => Console.WriteLine(p.name)); 

            }
        }


        public void ReadDataJoin()
        {
            using (var db = new SAE_RolePlayingGameEntities())
            {

                var players = from p in db.Players
                              where p.ID == 1
                              select p.Rassen;

                players.ToList().ForEach(r => Console.WriteLine(r.name));

            }
        }



        public void ManipulateData()
        {
            using (var db = new SAE_RolePlayingGameEntities())
            {

                var players = from p in db.Players
                              where p.ID == 1
                              select p;

                var player = players.FirstOrDefault();

                player.name = "MANU";
                

                Console.WriteLine(db.SaveChanges());
                
            }
        }


        public void DeleteData()
        {
            using (var db = new SAE_RolePlayingGameEntities())
            {

                var players = from p in db.Players
                              where p.ID == 1009
                              select p;

                var player = players.FirstOrDefault();

                db.Players.Remove(player);


                Console.WriteLine(db.SaveChanges());

            }
        }


        public void AddData()
        {


            using (var db = new SAE_RolePlayingGameEntities())
            {

                var player = new Players();

                player.energie = 100;
                player.ID = 1009;
                player.klasseID = 1;
                player.level = 80;
                player.muenzen = 0;
                player.name = "Manuel";
                player.password = "cbb786c";
                player.rasseID = 1;

                db.Players.Add(player);


                Console.WriteLine(db.SaveChanges());

            }
        }
    }
}
