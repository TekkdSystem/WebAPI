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
    
    public partial class Statistic
    {
        public int StatisticID { get; set; }
        public Nullable<System.DateTime> Year { get; set; }
        public int AreaID { get; set; }
        public Nullable<int> CrudeDeathRate { get; set; }
        public string PerninatalMortalityRate { get; set; }
        public Nullable<int> MaternalMortalityRatio { get; set; }
        public Nullable<int> MaternalMortalityRate { get; set; }
        public Nullable<int> InfantMortalityRate { get; set; }
        public Nullable<int> ChildMortalityRate { get; set; }
        public Nullable<int> StandardizedMortalityRate { get; set; }
        public Nullable<int> AgeSpecificMortalityRate { get; set; }
        public Nullable<int> SexSpecificMortalityRate { get; set; }
    
        public virtual AreaAffected AreaAffected { get; set; }
    }
}
