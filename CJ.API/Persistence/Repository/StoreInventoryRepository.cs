using CJ.API.Models.Core.Repository;
using CJ.API.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJ.API.Persistence.Repository
{

    public interface IAllStoreInventoryRepository : IRepository<AllStoreView>
    {
        List<AllStoreView> GetAllStoreDetail();

    }
    public class AllStoreInventoryRepository : Repository<AllStoreView>, IAllStoreInventoryRepository
    {
        public List<AllStoreView> GetAllStoreDetail()
        {
            AllStoreView oAllStoreView = new AllStoreView();
            //StoreInventoryView oStoreInventoryView = new StoreInventoryView();

            #region All Store
            var query = @"Select a.WarehouseID as storeId,ShowroomAddress as address,ShowroomName as name,
            ShowroomCode as shortCode,
            b.GeolocationName as city,c.GeolocationName as  region,
            c.Division as  area,'' longitude,'' lattitude 
            From t_Showroom a,t_Geolocation  b, t_Geolocation c 
            where
             a.ThanaID=b.GeoLocationID 
            and b.ParentID=c.GeoLocationID 
            and IsPOsactive=1 
            and IsTDOutlet=1
            Union all
            Select a.WarehouseID as storeId,ShowroomAddress as address,ShowroomName as name,
            ShowroomCode as shortCode,
            b.GeolocationName as city,c.GeolocationName as  region,
            c.Division as  area,'' longitude,'' lattitude 
            From t_Showroom a,t_Geolocation  b, t_Geolocation c 
            where ShowroomCode='ETD' and
             a.ThanaID=b.GeoLocationID 
            and b.ParentID=c.GeoLocationID 
            and IsPOsactive=1 ";

            query = string.Format(query);
            var store = CasperJetContext.Database.SqlQuery<AllStoreView>(query).ToList();

            #endregion

            #region Inventory
            //var queryinventory = @"Select a.WarehouseID as storeId,ProductCode,Productname as Sku,CurrentStock as productCount 
            //                    From t_ProductStock a,t_Showroom b,t_Product c
            //                    where a.WarehouseID=b.WarehouseID and a.ProductID=c.ProductID and CurrentStock>0";
            //queryinventory = string.Format(queryinventory);
            //var inventory = CasperJetContext.Database.SqlQuery<AllInventory>(queryinventory).ToList();
            //oStoreView.inventory = inventory;
            #endregion



            foreach (var itemstore in store)
            {

                //var aStoreInventory = inventory.Where(a => a.StoreId == itemstore.StoreId).ToList();

                itemstore.inventory = null;
            }


            return store;

        }

        public AllStoreInventoryRepository(CasperJetContext context) : base(context)
        {

        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }

    public interface IStoreInventoryRepository : IRepository<SingleStoreView>
    {
        SingleStoreView GetStoreDetail(string sShortCode);
        int GetStoreId(string code);
    }
    public class StoreInventoryRepository : Repository<SingleStoreView>, IStoreInventoryRepository
    {

        public SingleStoreView GetStoreDetail(string sShortCode)
        {
            try
            {
                SingleStoreView oStoreView = new SingleStoreView();

                #region Store
                var query = @"Select ShowroomID as storeId,ShowroomAddress as address,ShowroomName as name,
                        ShowroomCode as shortCode,
                        b.GeolocationName as city,c.GeolocationName as  region,
                        c.Division as  area,'' longitude,'' lattitude 
                        From t_Showroom a,t_Geolocation  b, t_Geolocation c 
                        where a.ThanaID=b.GeoLocationID and b.ParentID=c.GeoLocationID and ShowroomCode='{0}'";

                query = string.Format(query, sShortCode);
                var store = CasperJetContext.Database.SqlQuery<StoreView>(query).FirstOrDefault();

                oStoreView.StoreId = store.StoreId;
                oStoreView.Address = store.Address;
                oStoreView.Name = store.Name;
                oStoreView.ShortCode = store.ShortCode;
                oStoreView.City = store.City;
                oStoreView.Region = store.Region;
                oStoreView.Area = store.Area;
                oStoreView.Longitude = store.Longitude;
                oStoreView.Lattitude = store.Lattitude;

                #endregion

                #region Inventory
                var queryinventory = @"Select ProductCode,Productname as Sku,CurrentStock as productCount 
                                From t_ProductStock a,t_Showroom b,t_Product c
                                where a.WarehouseID=b.WarehouseID and a.ProductID=c.ProductID and ShowroomCode='{0}'";
                queryinventory = string.Format(queryinventory, sShortCode);
                var inventory = CasperJetContext.Database.SqlQuery<Inventorys>(queryinventory).ToList();
                oStoreView.inventory = inventory;
                #endregion


                return oStoreView;
            }
            catch
            {
                return null;
            }
            

        }

        public int GetStoreId(string code)
        {
            var query = @"select top 1 WarehouseID from t_Showroom where ShowroomCode = '{0}'";
            query = string.Format(query, code);
            var storeId = CasperJetContext.Database.SqlQuery<int>(query).FirstOrDefault();
            return storeId;
        }

        public StoreInventoryRepository(CasperJetContext context) : base(context)
        {

        }
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
    }
}