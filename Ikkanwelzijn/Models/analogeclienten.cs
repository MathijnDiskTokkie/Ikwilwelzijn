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
    
    public partial class analogeclienten
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public analogeclienten()
        {
            this.activiteiten = new HashSet<activiteiten>();
        }
    
        public int briefnummer { get; set; }
        public string voorkeur1 { get; set; }
        public string voorkeur2 { get; set; }
        public string voorkeur3 { get; set; }
        public string voornaamanaloog { get; set; }
        public string achternaamanaloog { get; set; }
        public string tussenvoegselanaloog { get; set; }
        public string adresanaloog { get; set; }
        public string woonplaatsanaloog { get; set; }
        public int organisatie_organisatieid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<activiteiten> activiteiten { get; set; }
        public virtual organisatie organisatie { get; set; }
    }
}