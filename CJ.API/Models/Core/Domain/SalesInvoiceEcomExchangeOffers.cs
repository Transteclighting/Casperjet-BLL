using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CJ.API.Models.Core.Domain
{

    [Table("t_SalesInvoiceEcomExchangeOffer")]
    public class SalesInvoiceEcomExchangeOffers
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EcomOrderID { get; set; }
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ProductName { get; set; }
        public double ExchangeAmount { get; set; }
    }
}