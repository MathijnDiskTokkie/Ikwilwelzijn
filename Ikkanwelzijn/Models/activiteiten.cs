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
    
    public partial class activiteiten
    {
        public string activiteitnaam { get; set; }
        public int activiteitid { get; set; }
        public Nullable<System.DateTime> activiteitdatum { get; set; }
        public string activiteitplaats { get; set; }
        public string activiteitbeschrijving { get; set; }
        public string activiteiturl { get; set; }
        public int organisatie_organisatieid { get; set; }
        public int clienten_clientid { get; set; }
        public int analogeclienten_briefnummer { get; set; }
    
        public virtual analogeclienten analogeclienten { get; set; }
        public virtual clienten clienten { get; set; }
        public virtual organisatie organisatie { get; set; }
    }
}
