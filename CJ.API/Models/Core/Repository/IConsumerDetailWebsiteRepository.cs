using CJ.API.Models.Core.Domain;
using System.Collections.Generic;
using System;

namespace CJ.API.Models.Core.Repository
{


    public interface IConsumerDetailWebsiteRepository : IRepository<ConsumerDetailWebsite>
    {
        ConsumerDetailWebsite GetConsumerDetailWebsite(string phoneno);

        List<ConsumerDetailWebsite> GetConsumerDetaillistWebsite(DateTime? dFromDate, DateTime? dToDate, int pageIndex, int pageSize);
    }
}
