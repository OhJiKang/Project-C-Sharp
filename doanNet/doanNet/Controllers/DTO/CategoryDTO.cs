using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doanNet.Controllers.DTO
{
    public class CategoryDTO
    {
        public int IDCategory { get; set; }
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public string ChipColor { get; set; }
    }
}