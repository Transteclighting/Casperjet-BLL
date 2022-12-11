using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CJ.API.Models.Core.Domain
{
    [Table("t_SalesInvoiceEcom")]
    public class SalesInvoiceEcom
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string EComOrderId { get; set; }
        [Required]
        public int LeadType { get; set; }
        public string OrderNo { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Outlet { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public double DeliveryCharge { get; set; }
        [Required]
        public double Discount { get; set; }
        public string CopunNo { get; set; }
        [Required]
        public int ConsumerId { get; set; }
        [Required]
        public string ConsumerName { get; set; }
        [Required]
        public string Addrress { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        public string Remarks { get; set; }
        [Required]
        public int Status { get; set; }
        public string SalesPersonId { get; set; }
        public string RefInvoiceNo { get; set; }
        public int? IsEmi { get; set; }

    }

}