using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doanNet.Controllers.DTO
{
    public class PostDTO
    {
        public string PostTittle { get; set; }
        public string PostDetail { get; set; }
        
        public HttpPostedFileBase PostImage { get; set; }
        public int IDAccount { get; set; }
        public List<CategoryDTO> CategoryList { get; set; }

    }
}