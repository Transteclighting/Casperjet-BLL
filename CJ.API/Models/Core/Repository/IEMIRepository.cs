using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.API.Models.Core.Repository
{
    public interface IEMIRepository
    {
        List<Emi> GetEmiList(int pageIndex, int pageSize);
        List<Emi> GetProductEmi(string sProductCode);
    }
}
