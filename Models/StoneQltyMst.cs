//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jewelly.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StoneQltyMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StoneQltyMst()
        {
            this.StoneMsts = new HashSet<StoneMst>();
        }
    
        public string StoneQlty_ID { get; set; }
        public string StoneQlty { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoneMst> StoneMsts { get; set; }
    }
}
