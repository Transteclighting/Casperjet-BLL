using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJ.API.Models.Core.Domain
{
    public class Ticket
    {
        public int InvoiceNo { get; set; }
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string WebTicketId { get; set; }
        public string JobID { get; set; }
        public string JobNo { get; set; }
        public string Remarks { get; set; }
        public string StatusName { get; set; }
        public string JobType { get; set; }
        public string VisitTimeFrom { get; set; }
    }
}