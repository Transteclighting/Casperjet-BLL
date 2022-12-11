using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJ.API.Models.Core.Domain;

namespace CJ.API.Models.Core.Repository
{
    public interface IPromoCpRepository : IRepository<PromoCp>
    {
        double GetPromoDiscount(string sProductCode);
    }

    
}
