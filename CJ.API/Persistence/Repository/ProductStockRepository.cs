using System;
using System.Linq;
using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Persistence.Repository
{
    public class ProductStockRepository : Repository<ProductStock>, IProductStockRepository
    {

        public Int64 WarehouseWiseStock(string sWarehouseCode, string sProductCode)
        {
            //string query = "Select sum(CurrentStock)-sum(DDQty) as CurrentStock From " +
            //                    "( " +
            //                    "Select a.WarehouseID, ShortCode as WarehouseCode, ProductCode, CurrentStock, 0 as DDQty " +
            //                    "from t_ProductStock a, (Select WarehouseID,isnull(ShortCode,'') ShortCode From v_WarehouseDetails where WarehouseGroupName='Saleable' and WarehouseParentID=6) b, t_Product c " +
            //                    "Where a.WarehouseID = b.WarehouseID and a.ProductID = c.productID and CurrentStock > 0 " +
            //                     "Union All " +
            //                    "Select WHID, ShowroomCode, ProductCode, 0 as CurrentStock, DisplatQty as DDQty From " +
            //                    "( " +
            //                    "Select  WHID, ProductID, count(ProductSerialNo) DisplatQty From " +
            //                    "( " +
            //                    "Select distinct * From " +
            //                    "( " +
            //                    "Select WHID, AssignProductID as ProductID, ProductSerialNo " +
            //                    "From TELSYSDB.DBO.t_OutletDisplayPosition where ProductSerialNo is Not null " +
            //                    "and Status = 1 " +
            //                    "Union All " +
            //                    "Select WarehouseID, DataID, Field1 " +
            //                    "From TELSYSDB.DBO.t_DataMonitoring where TableName = 't_ProductStockSerial' " +
            //                    "and Field1 in (Select BarcodeSL From t_UnsoldDefectiveProduct) " +
            //                    ") x " +
            //                    ") Main group by WHID, ProductID " +
            //                    ") A,TELSYSDB.DBO.t_Product b, TELSYSDB.DBO.t_Showroom c " +
            //                    "where a.ProductID = b.ProductID and a.WHID = c.WarehouseID " +
            //                    ") Main Where WarehouseCode = '"+ sWarehouseCode +"' and ProductCode = '" + sProductCode + "' " +
            //                    "group by WarehouseCode, ProductCode having sum(CurrentStock) - sum(DDQty) > 0";


            var query = @"Select sum(CurrentStock)-sum(DDQty) as CurrentStock 
                        From (
                        Select a.WarehouseID, ShortCode as WarehouseCode,
                        ProductCode, CurrentStock, 0 as DDQty from t_ProductStock a,
                        (
                        Select WarehouseID,isnull(ShortCode,'') ShortCode From v_WarehouseDetails
                        where WarehouseGroupName='Saleable' 
                        ) b,
                        t_Product c 
                        Where a.WarehouseID = b.WarehouseID 
                        and a.ProductID = c.productID 
                        and CurrentStock > 0 
                        Union All 
                        Select WHID, ShowroomCode, ProductCode, 0 as CurrentStock, DisplatQty as DDQty 
                        From ( 
                        Select  WHID, ProductID, count(ProductSerialNo) DisplatQty 
                        From 
                        ( 
                        Select distinct * From 
                        ( 
                        Select WHID, AssignProductID as ProductID, ProductSerialNo 
                        From TELSYSDB.DBO.t_OutletDisplayPosition where ProductSerialNo is Not null and Status = 1
                        Union All 
                        Select WarehouseID, DataID, Field1 From TELSYSDB.DBO.t_DataMonitoring where 
                        TableName = 't_ProductStockSerial' and Field1 in (Select BarcodeSL From t_UnsoldDefectiveProduct) 
                        ) x 
                        ) 
                        Main
                        group by WHID, ProductID 
                        ) A,TELSYSDB.DBO.t_Product b, TELSYSDB.DBO.t_Showroom c 
                        where a.ProductID = b.ProductID and a.WHID = c.WarehouseID
                        ) Main 
                        Where WarehouseCode = '{0}' and 
                        ProductCode = '{1}' 
                        group by WarehouseCode, ProductCode having sum(CurrentStock) - sum(DDQty) > 0";

            query = string.Format(query, sWarehouseCode, sProductCode);
            var stock = CasperJetContext.Database.SqlQuery<Int64>(query).FirstOrDefault();
            return stock;

        }

        public ProductStockRepository(CasperJetContext context): base(context)
        {

        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }
}