//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HerczegKristofFejlabuak.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class classification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public classification()
        {
            this.species = new HashSet<species>();
        }
    
        public string subclass_name { get; set; }
        public string order_ { get; set; }
        public string family { get; set; }
        public string genus_name { get; set; }
        public Nullable<byte> deep_able { get; set; }
        public Nullable<byte> cthulh_aproved { get; set; }
        public string special_apparance { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<species> species { get; set; }
        public virtual subclass subclass { get; set; }
    }
}
