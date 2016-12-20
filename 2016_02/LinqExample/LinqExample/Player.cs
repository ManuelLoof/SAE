using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    /// <summary>
    /// Unsere Spieler Klasse.
    /// </summary>
    public class Player
    {

        #region properties

        /// <summary>
        /// Der Name des Spielers.
        /// </summary>
        public string Name { get; set; }


        public enum EKlasse
        {
            Krieger,
            Magier,
            Heiler
        }

        public EKlasse Klasse { get; set; }

        public int Score { get; set; }


        #endregion


    }
}
