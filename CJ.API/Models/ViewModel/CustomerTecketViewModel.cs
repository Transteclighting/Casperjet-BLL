using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJ.API.Models.ViewModel
{
    public class CustomerTecketViewModel
    {
        public List<TicketViewModel> Items { get; set; }
        public int TotalCount { get; set; }
    }
}