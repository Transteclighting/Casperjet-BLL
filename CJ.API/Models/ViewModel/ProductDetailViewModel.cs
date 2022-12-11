using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CJ.API.Models.ViewModel
{
    public class ProductView
    {
        public string Id { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public double PreviousPrice { get; set; }

        //public ProductBasic ProductBasics { get; set; }
        public List<Inventory> Inventory { get; set; }
        public List<Warranty> Warranties { get; set; }
        public List<Emi> Emi { get; set; }
        public List<Campaign> Campaigns { get; set; }

    }

    public class ProductBasic
    {
        
        public string Id { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public double PreviousPrice { get; set; }

        //public List<Inventory> Inventories { get; set; }
        //public List<Warranty> Warranties { get; set; }
        //public List<Emi> Emi { get; set; }
        //public List<Campaign> Campaigns { get; set; }


    }
    public class Inventory
    {

        public int StoreID { get; set; }
        public Int64 ProductCount { get; set; }

    }
    public class Warranty
    {
        public int WarrantyTypeID { get; set; }
        public string WarrantyName { get; set; }
        public int Price { get; set; }
        public int IsDetfault { get; set; }
        public int DurationInMonths { get; set; }
    }
    public class Emi
    {
        public int BankID { get; set; }
        public string BankName { get; set; }
        public int Duration { get; set; }
        public string OptionName { get; set; }
        public int IsExtended { get; set; }
        public double InterestRate { get; set; }

        //public int DurationInMonths { get; set; }
        //public double Price { get; set; }
        //public int IsDetfault { get; set; }



    }
    public class Campaign
    {
        public int CampaignId { get; set; }
        public double Price { get; set; }
        public int ProductCount { get; set; }
    }
    public class CampaignProduct
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Discount { get; set; }
    }
    public class RootCampaign
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTimeOffset StartDateUTC { get; set; }
        public DateTimeOffset EndDateUTC { get; set; }
    }
}