using CJ.API.Models.Core.Domain;
using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.API.Models.Core.Repository
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        List<TicketViewModel> GetTecketList(List<int> webTicketId);
        CustomerTecketViewModel GetCustomerTecket(string phoneNo, int pageIndex, int pageSize);
    }
}
