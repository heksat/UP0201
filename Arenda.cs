//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP0201
{
    using System;
    using System.Collections.Generic;
    
    public partial class Arenda
    {
        public int Id { get; set; }
        public Nullable<int> ID_arendatory { get; set; }
        public string Name { get; set; }
        public Nullable<int> ID_EMP { get; set; }
        public string NumberOfPavil { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Start_rent { get; set; }
        public Nullable<System.DateTime> Finisth_rent { get; set; }
    
        public virtual Arendatory Arendatory { get; set; }
        public virtual Employers Employers { get; set; }
        public virtual TC TC { get; set; }
    }
}
