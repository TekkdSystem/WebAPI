//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Volunteer
    {
        public int VolunteerID { get; set; }
        public int VolunteerTypeID { get; set; }
        public string VolunteerCellphone { get; set; }
        public string VolunteerEmergencyContact { get; set; }
    
        public virtual VolunteerType VolunteerType { get; set; }
    }
}
