using System;
using System.Collections.Generic;
using System.Text;

namespace CJ.Class
{
   public class CacStockChallan
    {     
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Model{ get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public object DeliveryDate{ get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerName { get; set; }
        public string LCNo { get; set; }
        public string RefNo { get; set; }
        public int Transide { get; set; }
        public int Qty { get; set; }
    }
}
