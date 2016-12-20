using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDBExample
{
    public class Player
    {

        #region properties
        
        /// <summary>
        /// Eine eindeutige ID.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Der Name unseres Spielers.
        /// </summary>
        public string Name { get; set; }

        private int _level;
        /// <summary>
        /// Das Level in dem unser Spieler sich befindet.
        /// </summary>
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                if (value <= 100 && value >= 0)
                    _level = value;
                else
                    throw new Exception("Der Wert darf nicht größer als 100 sein und nicht kleiner als 0.");
            }
        }


        /// <summary>
        /// Der Spielertyp;
        /// </summary>
        public enum ETyp
        {
            Krieger,
            Magier,
            Heiler
        }

        /// <summary>
        /// Der Spielertyp.
        /// </summary>
        public ETyp Typ { get; set; }

        #endregion


        #region overrides

        public override string ToString()
        {
            return $"ID: {ID}Name: {Name};Level: {Level};Typ: {Enum.GetName(typeof(ETyp), Typ)}";
        }

        #endregion

        #region public methods

        public void Move()
        {
            // Logik,  für die Bewegung unser Spielers.
        }

        #endregion

        #region Static methods

        public static Player PlayerFactory()
        {

            var player = new Player();
            player.ID = Guid.NewGuid();
            return player; 
        }


        #endregion

    }
}
