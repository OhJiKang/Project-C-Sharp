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
    
    public partial class Log
    {
        public int IDLog { get; set; }
        public int IDFee { get; set; }
        public System.DateTime DateDone { get; set; }
        public int Quantity { get; set; }
        public int IDSinhVien { get; set; }
        public Nullable<int> Order { get; set; }
        public string Meta { get; set; }
        public System.DateTime DateBegin { get; set; }
        public int Hide { get; set; }

        [JsonIgnore]
        public virtual Fee Fee { get; set; }
        [JsonIgnore]
        public virtual SinhVien SinhVien { get; set; }
    }
}