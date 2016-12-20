using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDBExample
{
    public class Enemie
    {

        public Guid ID { get; set; }


        public Player.ETyp Typ { get; set; }

        public bool Alive { get; set; }

        public DateTime TimeStamp { get; set; }


        public override string ToString()
        {
            return $"ID: {ID}; Typ: {Typ}; Alive: {Alive}; TimeStamp: {TimeStamp}";
        }


    }
}
