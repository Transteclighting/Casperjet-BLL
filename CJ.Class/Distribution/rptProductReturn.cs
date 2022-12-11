using System;
using System.Collections.Generic;
using System.Text;

namespace CJ.Class.Distribution
{
   public class rptProductReturn
    {
        public long InvoiceID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string UOM { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public int PackQty { get; set; }
        public double Discount { get; set; }

        public double InvoiceAmount { get; set; }

        public double QtyAmount { get; set; }

        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string Remarks { get; set; }

        public string RefInvoiceNo { get; set; }

        public object RefDate { get; set; }

        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }
        public string ThanaName { get; set; }
        public string DistrictName { get; set; }
        public string CustomerTelephone { get; set; }
        public string CustomerTypeName { get; set; }
        public string AreaName { get; set; }
        public string TerritoryName { get; set; }

        public string ProRecUser { get; set; }


    }
}
