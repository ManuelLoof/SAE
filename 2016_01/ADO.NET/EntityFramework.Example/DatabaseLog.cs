//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework.Example
{
    using System;
    using System.Collections.Generic;
    
    public partial class DatabaseLog
    {
        public int DatabaseLogID { get; set; }
        public System.DateTime PostTime { get; set; }
        public string DatabaseUser { get; set; }
        public string Event { get; set; }
        public string Schema { get; set; }
        public string Object { get; set; }
        public string TSQL { get; set; }
        public string XmlEvent { get; set; }
    }
}
