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
    
    public partial class Orderdetail
    {
        public int Orderdetails_ID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string ID { get; set; }
        public string Style_Code { get; set; }
    
        public virtual CartList CartList { get; set; }
        public virtual ItemMst ItemMst { get; set; }
    }
}
