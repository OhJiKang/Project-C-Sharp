using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doanNet.Controllers.DTO
{
    public class FeeDTO
    {
        public int IDFee { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime DateEnd { get; set; }
        public byte[] Status { get; set; }
        public int IDRoom { get; set; }
        public int IDLog { get; set; }
    }
}