using System;
using CJ.API.Models.Core.Domain;

namespace CJ.API.Models.Core.Repository
{
    public interface IProductStockRepository : IRepository<ProductStock>
    {
        Int64 WarehouseWiseStock(string sWarehouseCode, string sProductCode);
    }
}
