using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CJ.API.Models.Core.Domain
{
    [Table("t_SalesInvoiceEcomProducts")]
    public class SalesInvoiceEcomProducts
    {
        [Key, Column(Order = 0)]
        public string EcomOrderID { get; set; }
        [Key, Column(Order = 1)]
        [Required]
        [MaxLength(50, ErrorMessage = "{0} can have a max of {1} characters")]
        public string ProductCode { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "{0} can have a max of {1} characters")]
        public string ProductName { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int IsFreeQty { get; set; }
    }
}