using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CJ.API.Models.Core.Domain
{
    [Table("t_SalesInvoiceEcomPayments")]
    public class SalesInvoiceEcomPayments
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EcomOrderID { get; set; }
        public string PaymentOptionId { get; set; }
        public string GatewayId { get; set; }
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TransactionId { get; set; }
        public int PayableType { get; set; }
        public string PayableNumber { get; set; }
        public double Amount { get; set; }
        public int PaymentHistoryStatus { get; set; }
        public string FailedReason { get; set; }
        public DateTime? PaidAtUtc { get; set; }
        public string Remarks { get; set; }
    }
}