using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJ.API.Models.ViewModel
{
    public class Brand
    {
            public int BrandID { get; set; }
            public string BrandName { get; set; }
    }
    public class BrandProduct
    {
        public string ProductCode { get; set; }
    }
}