using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.API.Models.Core.Repository
{
    public interface IBankRepository : IRepository<Bank>
    {
        List<Bank> GetBankList(int pageIndex, int pageSize);
    }
}
