using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doanNet.Controllers.DTO
{
    public class ContractDTO
    {
        public string MSSV { get; set; }
        public string IDCitizen { get; set; }
        public byte[] ProfilePlace { get; set; }
        public string IDPlace { get; set; }
        public int Ending { get; set; }
        
        public int IDPriority { get;set; }
    }
}