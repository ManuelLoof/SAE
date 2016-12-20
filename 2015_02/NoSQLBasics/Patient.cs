using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQLBasics
{
    public class Patient
    {

        public enum Krankheiten
        {
            Blinddarmentzuendung,
            Schlaganfall,
            Schnupfen
        }

        public List<Krankheiten> Krankheit { get; set; }

        public string VorName { get; set; }

        public string NachName { get; set; }

        public string Titel { get; set; }

        public int ID { get; set; }

        public Patient()
        {
            Krankheit = new List<Krankheiten>();
        }

        public override string ToString()
        {
            var message = $"ID: {ID}; Vorname: {VorName}; Nachname: {NachName};  Titel: {Titel} Krankheiten:";

            Krankheit.ForEach(k => message = $"{message}, {Enum.GetName(typeof(Krankheiten), k)}");

            return message;
        }

    }
}
