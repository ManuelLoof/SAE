using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringToolbox;

namespace LinqExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var players = new List<Player>();
            CreatePlayer(players);

            var bestPlayer = from p in players
                             where p.Score > 2000
                             orderby p.Name descending
                             select p.Name;


            bestPlayer.ToList().ForEach(p => Console.WriteLine(p));


            Console.ReadKey();
        }

        /// <summary>
        /// Beispiel für eine Linq Query in der Linq Syntax.
        /// </summary>
        /// <param name="players"></param>
        private static void LinqSyntax(List<Player> players)
        {
            players.Where(p => p.Score > 2000)
                    .Select(p => p.Name)
                    .OrderByDescending(n => n)
                    .ToList()
                    .ForEach(n => Console.WriteLine(n));
        }


        /// <summary>
        /// Beispiel einer Extension Method Implementierung.
        /// </summary>
        private static void ExtensionMethod()
        {
            Console.WriteLine("Hallo".Right(4));
        }

        /// <summary>
        /// Klassisches Filtern und sortieren.
        /// </summary>
        /// <param name="players"></param>
        private static void FilterAndSortClassic(List<Player> players)
        {
            // Klassischer Weg filtern von Listen.
            var bestPlayers = new List<Player>();
            foreach (var player in players)
            {
                if (player.Score > 2000)
                {
                    bestPlayers.Add(player);
                }
            }

            // Das Ergebniss sortieren.
            bestPlayers.Sort(delegate (Player x, Player y)
            {
                return x.Name.CompareTo(y.Name);

            });

            // Ausgabe
            foreach (var player in bestPlayers)
            {
                Console.WriteLine(player.Name);
            }
        }

        /// <summary>
        /// Ereugt unsere Liste an Spilern.
        /// </summary>
        /// <param name="players"></param>
        private static void CreatePlayer(List<Player> players)
        {
            players.Add(new Player()
            {
                Name = "Ulf",
                Klasse = Player.EKlasse.Krieger,
                Score = 1200
            });


            players.Add(new Player()
            {
                Name = "Bernd",
                Klasse = Player.EKlasse.Magier,
                Score = 2600
            });

            players.Add(new Player()
            {
                Name = "Ute",
                Klasse = Player.EKlasse.Heiler,
                Score = 3000
            });

            players.Add(new Player()
            {
                Name = "Erwin",
                Klasse = Player.EKlasse.Krieger,
                Score = 250
            });
        }
    }
}
