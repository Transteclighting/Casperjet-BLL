using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJ.API.Models.ViewModel
{
    public class WarrantyCardViewModel
    {
        public string WarrantyCardNo { get; set; }
        public string ConsumerName { get; set; }
        public string Address { get; set; }
        public string CellNo { get; set; }
        public string Email { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string EmployeeName { get; set; }
        public string ShortCode { get; set; }
        public string WarehouseName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string BrandDesc { get; set; }
        public string ProductSerialNo { get; set; }
        public string QRCodeParam {get;set;}

    }
}