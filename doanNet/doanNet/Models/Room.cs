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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            this.Fees = new HashSet<Fee>();
            this.Mistakes = new HashSet<Mistake>();
            this.SinhViens = new HashSet<SinhVien>();
        }
    
        public int IDRoom { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string Building { get; set; }
        public int RoomType { get; set; }
        public Nullable<int> Order { get; set; }
        public string Meta { get; set; }
        public System.DateTime DateBegin { get; set; }
        public int Hide { get; set; }
        public Nullable<int> PriceRoom { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Fee> Fees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Mistake> Mistakes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
