using CJ.API.Models.Core.Domain;
using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.API.Models.Core.Repository
{
    public interface ICampaignRepository : IRepository<Campaign>
    {
        List<RootCampaign> GetCampaignList(int pageIndex, int pageSize);
        //List<Campaign> GetProductCampaign(string sProductCode);
        List<CampaignProduct> GetCampaignProducts(string campId);
    }
}