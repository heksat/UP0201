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
    
    public partial class TC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TC()
        {
            this.Arenda = new HashSet<Arenda>();
            this.Pavils = new HashSet<Pavils>();
        }
    
        public string Name { get; set; }
        public string Status { get; set; }
        public Nullable<int> CountPavil { get; set; }
        public string City { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Koef { get; set; }
        public Nullable<int> Stages { get; set; }
        public byte[] Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arenda> Arenda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pavils> Pavils { get; set; }
    }
}
