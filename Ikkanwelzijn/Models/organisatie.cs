//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ikkanwelzijn.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class organisatie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public organisatie()
        {
            this.activiteiten = new HashSet<activiteiten>();
            this.clienten = new HashSet<clienten>();
        }
    
        public int organisatieid { get; set; }
        public string organisatienaam { get; set; }
        public string organisatieplaats { get; set; }
        public Nullable<int> clientid { get; set; }
        public Nullable<int> activiteitid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<activiteiten> activiteiten { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clienten> clienten { get; set; }
    }
}
