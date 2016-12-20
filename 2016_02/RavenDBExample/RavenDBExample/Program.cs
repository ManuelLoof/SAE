using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDBExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DBHandler())
            {

                string playerName = "Herbert";
                //db.AddPlayer(new Player() { Name = playerName, Level = 57, Typ = Player.ETyp.Krieger });


                var player = Player.PlayerFactory();
                player.Name = playerName;
                player.Level = 33;
                player.Typ = Player.ETyp.Heiler;

                //db.AddPlayer(player);


                //var herberts = db.GetPlayerByName(playerName);

                //herberts.ForEach(h => Console.WriteLine(h));


                // Ich definiere hier meinen Ausdruck ausserhalb.

                var players = db.GetPlayer(p => p.Level < 50);

                //db.Add<Enemie>(new Enemie() { ID = Guid.NewGuid(), Typ = Player.ETyp.Krieger, Alive = true , TimeStamp = DateTime.Now});
                //db.Add<Enemie>(new Enemie() { ID = Guid.NewGuid(), Typ = Player.ETyp.Krieger, Alive = true , TimeStamp = DateTime.Now});
                //db.Add<Enemie>(new Enemie() { ID = Guid.NewGuid(), Typ = Player.ETyp.Krieger, Alive = true , TimeStamp = DateTime.Now});
                //db.Add<Enemie>(new Enemie() { ID = Guid.NewGuid(), Typ = Player.ETyp.Krieger, Alive = false, TimeStamp = DateTime.Now});

                var enemies = db.GetObject<Enemie>(e => e.Alive == true);


                enemies.ForEach(e => Console.WriteLine(e));


                Console.WriteLine($"Anzahl: {enemies.Count}");

                Console.ReadKey();

            }

        }
    }
}
