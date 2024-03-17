//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace doanNet.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fee()
        {
            this.Logs = new HashSet<Log>();
        }
    
        public int IDFee { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime DateEnd { get; set; }
        public byte[] Status { get; set; }
        public int Quantity { get; set; }
        public int IDRoom { get; set; }
        public Nullable<int> Order { get; set; }
        public string Meta { get; set; }
        public System.DateTime DateBegin { get; set; }
        public int Hide { get; set; }
    
        public virtual Room Room { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Log> Logs { get; set; }
    }
}
