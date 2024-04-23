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
    
    public partial class Mistake
    {
        public int IDMistake { get; set; }
        public string MistakeDes { get; set; }
        public System.DateTime TimeCaught { get; set; }
        public string BedID { get; set; }
        public int IDSinhVien { get; set; }
        public int IDAccount { get; set; }
        public int IDRoom { get; set; }
        public Nullable<int> Order { get; set; }
        public string Meta { get; set; }
        public System.DateTime DateBegin { get; set; }
        public int Hide { get; set; }
        public string ImageDescription { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Room Room { get; set; }
        public virtual SinhVien SinhVien { get; set; }
    }
}
