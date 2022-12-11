using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.API.Models.Core.Repository
{
    public interface IDataTransferRepository
    {
       void CreateDataTransfer(string TableName,int DataID,int WarehouseID,int TransferType,int IsDownload,int BatchNo);
    }
}
