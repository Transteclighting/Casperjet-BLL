using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJ.API.Models.ViewModel
{
    public class TicketViewModel
    {
        public string InvoiceId { get; set; }
        public string ProductId { get; set; }
        public string WebTicketId { get; set; }
        public string ERPTicketId { get; set; }
        public string ERPTicketDescription { get; set; }
        public string ERPTicketStatus { get; set; }
        public string ComplainType { get; set; }
    }
}