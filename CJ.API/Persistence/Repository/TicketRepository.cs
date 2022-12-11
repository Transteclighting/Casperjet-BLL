using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CJ.API.Models.ViewModel;
using CJ.Class;

namespace CJ.API.Persistence.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(DbContext context) : base(context)
        {
        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;

        public List<TicketViewModel> GetTecketList(List<int> webTicketId)
        {
            List<TicketViewModel> oTickes = new List<TicketViewModel>();
            #region Tickes
            var idList = string.Join(",", webTicketId);
            var queryTickes = @"SELECT
                                InvoiceNo,
                                ProductCode as ProductId,
                                WebTicketId ,
                                JobNO as ERPTicketId,
                                Remarks as  ERPTicketDescription,
                                StatusName as ERPTicketStatus,
                                JobType as ComplainType 
                                FROM v_CSDJobDetails where WebTicketId in ({0})";
            queryTickes = string.Format(queryTickes, idList);
            oTickes = CasperJetContext.Database.SqlQuery<TicketViewModel>(queryTickes).ToList();
            #endregion
            return oTickes;
        }

        public CustomerTecketViewModel GetCustomerTecket(string phoneNo, int pageIndex, int pageSize)
        {
            CustomerTecketViewModel ctm = new CustomerTecketViewModel();
            List<TicketViewModel> oTickes = new List<TicketViewModel>();
            #region Tickes
            var queryTickes = @"SELECT
                                InvoiceNo,
                                ProductCode as ProductId,
                                WebTicketId ,
                                JobNO as ERPTicketId,
                                Remarks as  ERPTicketDescription,
                                StatusName as ERPTicketStatus,
                                JobType as ComplainType 
                                FROM v_CSDJobDetails where CustMobNo='{0}' order by ProductId";
            queryTickes = string.Format(queryTickes, phoneNo);
            var pagination = Utility.ConvertToPaginationQuery(queryTickes, pageIndex, pageSize);
            oTickes = CasperJetContext.Database.SqlQuery<TicketViewModel>(pagination).ToList();
            var totalquery = string.Format("SELECT COUNT(JobID) FROM v_CSDJobDetails  where CustMobNo='{0}'", phoneNo);
            var totalCount = CasperJetContext.Database.SqlQuery<int>(totalquery).FirstOrDefault();
            ctm.Items = oTickes;
            ctm.TotalCount = totalCount;
            #endregion
            return ctm;
        }
    }
}