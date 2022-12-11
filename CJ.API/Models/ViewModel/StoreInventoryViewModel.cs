using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJ.API.Models.ViewModel
{

    //public class StoreInventoryView
    //{
    //    public List<AllStoreView> StoreViews { get; set; }
    //}


    public class AllStoreView
    {
        public int StoreId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string Longitude { get; set; }
        public string Lattitude { get; set; }
        public List<AllInventory> inventory { get; set; }
    }

    public class AllInventory
    {
        public int StoreId { get; set; }
        public string ProductCode { get; set; }
        public string Sku { get; set; }
        public Int64 ProductCount { get; set; }

    }

    public class StoreView
    {
        public int StoreId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string Longitude { get; set; }
        public string Lattitude { get; set; }
    }

    public class SingleStoreView
    {
        public int StoreId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string Longitude { get; set; }
        public string Lattitude { get; set; }
        public List<Inventorys> inventory { get; set; }
    }


    public class Inventorys
    {
        public string ProductCode { get; set; }
        public string Sku { get; set; }
        public Int64 ProductCount { get; set; }

    }
    
}