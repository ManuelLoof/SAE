//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework.ModellFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Players
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Players()
        {
            this.Items = new HashSet<Items>();
            this.Waffen = new HashSet<Waffen>();
        }
    
        public int ID { get; set; }
        public string name { get; set; }
        public Nullable<int> rasseID { get; set; }
        public Nullable<int> klasseID { get; set; }
        public Nullable<int> muenzen { get; set; }
        public Nullable<int> level { get; set; }
        public Nullable<int> energie { get; set; }
        public string password { get; set; }
    
        public virtual Klassen Klassen { get; set; }
        public virtual Rassen Rassen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Items> Items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Waffen> Waffen { get; set; }
    }
}