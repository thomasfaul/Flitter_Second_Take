//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Flitter.DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int ID { get; set; }
        public Nullable<int> ID_Message { get; set; }
        public System.DateTime ReportedTime { get; set; }
        public Nullable<int> ID_ReportType { get; set; }
        public Nullable<int> ID_ReportAutor { get; set; }
    
        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
        public virtual ReportType ReportType { get; set; }
    }
}
