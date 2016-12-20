using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class LinqTutorial
    {
        /// <summary>
        /// Erste Stufe mit Zugriff via Methoden.
        /// </summary>
        public void StandardQueryStufe1()
        {
            var meineListe = new List<string>() { "Rot", "Grün", "Blau" };

            var erg = meineListe.Where(Bedingung).Select(Ausgabe);


            Console.WriteLine(erg.Count());
            Console.ReadKey(); 

        }


        /// <summary>
        /// Zweite Stufe via anonyme Methode.
        /// </summary>
        public void StandardQueryStufeII()
        {
            var meineListe = new List<string>() { "Rot", "Grün", "Blau" };

            var erg = meineListe.Where(
                                    delegate(string eintrag)
                                    {
                                        return eintrag.Contains("r");
                                    }).Select(
                                        delegate(string eintrag)
                                        {
                                            return eintrag;
                                        }
                                    );


            Console.WriteLine(erg.Count());
            Console.ReadKey();

        }

        /// <summary>
        /// Zweite Stufe via Lamdba.
        /// </summary>
        public void StandardQueryStufeIII()
        {
            var meineListe = new List<string>() { "Rot", "Grün", "Blau" };

            var erg = meineListe.Where(eintrag => eintrag.Contains("r"))
                                    .Select(eintrag => eintrag);


            Console.WriteLine(erg.Count());
            Console.ReadKey();

        }


        /// <summary>
        /// Vierte Stufe via Lamdba.
        /// </summary>
        public void StandardQueryStufeIV()
        {
            var meineListe = new List<string>() { "Rot", "Grün", "Blau", "Grau" };

            var erg = from eintrag in meineListe
                          where eintrag.Contains("r")
                          select eintrag;


            Console.WriteLine(erg.Count());
            erg.ToList().ForEach(eintrag => Console.WriteLine(eintrag));
            Console.ReadKey();

        }

        /// <summary>
        /// Meine klassische Implementierung des Funktionszeigers.
        /// </summary>
        /// <param name="eintrag"></param>
        /// <returns></returns>
        private bool Bedingung(string eintrag)
        {
            return eintrag.Contains("r"); 
        }


        private string Ausgabe(string eintrag)
        {
            return eintrag; 
        }

    }
}
