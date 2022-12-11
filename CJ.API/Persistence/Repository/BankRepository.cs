using CJ.API.Models.Core.Repository;
using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CJ.API.Persistence.Repository
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(DbContext context) : base(context)
        {
        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
        public List<Bank> GetBankList(int pageIndex, int pageSize)
        {
            List<Bank> queryBanks = new List<Bank>();
            #region Banks
            var query = @"SELECT [BankID] as Id,[Name] FROM [t_Bank] ORDER BY 1 ASC";
            //query = string.Format(query);
            var pagination = Class.Utility.ConvertToPaginationQuery(query, pageIndex, pageSize);
            queryBanks = CasperJetContext.Database.SqlQuery<Bank>(pagination).ToList();
            #endregion
            return queryBanks;
        }
    }
}