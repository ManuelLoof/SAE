using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // SimpleQuery();
            // CreateWeapon();

            // JoinExample();

            
            using (var db = new SAE_RolePlayingGameEntities())
            {

                //// Hole mir das Player Objekt welches ich bearbeiten möchte.
                //var earl = (from p in db.Players
                //                   where p.ID == 1
                //                   select p).FirstOrDefault();


                //// Dann die Waffe welche ich ihm zuweisen will.
                //var minigun = (from w in db.Waffens
                //              where w.name == "Minigun"
                //              select w).FirstOrDefault();


                //// Weise die Waffe zu.
                //earl.Waffens.Add(minigun);


                //Console.WriteLine(db.SaveChanges());


                // Und kontrolliere das Ergebnis.
                var earlsWeapons = from p in db.Players
                                   where p.ID == 1
                                   select p.Waffens;


                foreach (var weapon in earlsWeapons.FirstOrDefault())
                {
                    Console.WriteLine(weapon.name);
                }

                Console.ReadKey();

            }

    }




        private static void JoinExample()
        {
            using (var db = new SAE_RolePlayingGameEntities())
            {

                var earlsWeapons = from p in db.Players
                                   where p.ID == 1
                                   select p.Waffens;



                foreach (var weapon in earlsWeapons.FirstOrDefault())
                {
                    Console.WriteLine(weapon.name);
                }

                Console.ReadKey();

            }
        }

        private static void CreateWeapon()
        {
            using (var db = new SAE_RolePlayingGameEntities())
            {

                var newWeapon = new Waffen();
                newWeapon.name = "Minigun";
                newWeapon.schaden = 9;

                db.Waffens.Add(newWeapon);

                Console.WriteLine(db.SaveChanges());
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Eine einfache Abfrage auf unsere Datenbank.
        /// </summary>
        private static void SimpleQuery()
        {
            using (var db = new SAE_RolePlayingGameEntities())
            {

                var erg = from p in db.Players
                          where p.level > 20
                          select p;


                foreach (var player in erg)
                {
                    Console.WriteLine(player.name);
                }

                Console.ReadKey();

            }
        }
    }
}
