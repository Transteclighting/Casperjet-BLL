using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CJ.API.Persistence.Repository
{
    public class ConsumerDetailWebsiteRepository : Repository<ConsumerDetailWebsite>, IConsumerDetailWebsiteRepository
    {
        public ConsumerDetailWebsite GetConsumerDetailWebsite(string phoneno)
        {
            ConsumerDetailWebsite oConsumerDetailWebsite = new ConsumerDetailWebsite();

            #region Consumer Detail Website
            var query = @"Select * From t_ConsumerDetailWebsite where phone='{0}'";

            query = string.Format(query, phoneno);
            var consumerdetail = CasperJetContext.Database.SqlQuery<ConsumerDetailWebsite>(query).FirstOrDefault();
            #endregion

            //#region Inventory
            //var queryinventory = @"Select WarehouseID as StoreID,CurrentStock as ProductCount From t_ProductStock where CurrentStock>0 and WarehouseID<>1
            //                and ProductID=(Select ProductID from t_Product where ProductCode={0})";
            //queryinventory = string.Format(queryinventory, sProductCode);
            //var inventory = CasperJetContext.Database.SqlQuery<Inventory>(queryinventory).ToList();
            //oProductView.Inventory = inventory;
            //#endregion


            return consumerdetail;

        }

        public List<ConsumerDetailWebsite> GetConsumerDetaillistWebsite(DateTime? dFromDate, DateTime? dToDate, int pageIndex, int pageSize)
        {
            #region Consumer Detail List Website
            var query = @"Select * From t_ConsumerDetailWebsite ORDER BY Id";
            if (dFromDate != null && dToDate != null)
            {
                query = @"Select * From t_ConsumerDetailWebsite where date between '{0}' and '{1}' and date<'{1}' ORDER BY Id";
                query = string.Format(query, dFromDate, dToDate);
            }
            var pagination = @"DECLARE @PageNumber AS INT DECLARE @RowsOfPage AS INT SET @PageNumber={0} SET @RowsOfPage={1} " + query + " OFFSET (@PageNumber-1)*@RowsOfPage ROWS FETCH NEXT @RowsOfPage ROWS ONLY";
            pagination = string.Format(pagination, pageIndex, pageSize);
            var consumerdetaillist = CasperJetContext.Database.SqlQuery<ConsumerDetailWebsite>(pagination).ToList();
            #endregion
            return consumerdetaillist;
        }

        public ConsumerDetailWebsiteRepository(CasperJetContext context) : base(context)
        {

        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }
}