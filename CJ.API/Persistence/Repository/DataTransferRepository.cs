using CJ.API.Models.Core.Repository;
using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CJ.API.Persistence.Repository
{
    public class DataTransferRepository :  Repository<Bank>,IDataTransferRepository
    {
        public DataTransferRepository(DbContext context) : base(context)
        {
        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
        public void CreateDataTransfer(string TableName, int DataID, int WarehouseID, int TransferType, int IsDownload, int BatchNo)
        {
            try
            {
                var query = @"INSERT INTO t_DataTransfer (TableName,DataID,WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES('{0}',{1},{2},{3},{4},{5},GETDATE())";
                query = string.Format(query, TableName, DataID, WarehouseID, TransferType, IsDownload, BatchNo);
                var queryBanks = CasperJetContext.Database.SqlQuery<List<string>>(query).ToList();
            }
            catch (Exception ex)
            {

            }
        }
    }
}