using doanNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace doanNet.ApiControllers
{
    public class ContractController : ApiController
    {
        KTXTDTUEntities1 db = new KTXTDTUEntities1();
        public List<Contract> Get()
        {
            return db.Contracts.ToList();
        }
    }
}
