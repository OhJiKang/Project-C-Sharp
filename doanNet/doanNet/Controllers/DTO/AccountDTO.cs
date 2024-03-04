using doanNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doanNet.Controllers.DTO
{
    public class AccountDTO
    {
        public int IDAccount { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Available { get; set; }
        public string Name { get; set; }
        public int IDSinhVien { get; set; }

        public int AccountID { get; set; }

        public int ContractID { get; set; }

        public int FacultyID { get; set; }

        public List<int> LogsID { get; set; }

        public List<int> MistakesID { get; set; }
    }
}