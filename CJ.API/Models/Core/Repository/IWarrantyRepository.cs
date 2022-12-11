using CJ.API.Models.Core.Domain;
using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.API.Models.Core.Repository
{
    public interface IWarrantyRepository: IRepository<Warranty>
    {
        List<Warranty> GetWarrantyList(int pageIndex, int pageSize);
        List<Warranty> GetProductWarranty(string sProductCode);
        WarrantyCardViewModel GetOrderWarranty(string sOrderERPId);
    }
}
