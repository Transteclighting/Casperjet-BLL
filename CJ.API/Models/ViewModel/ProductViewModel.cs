using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJ.API.Models.ViewModel
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public double PreviousPrice { get; set; }
        public double Discount { get; set; }
        public List<InventoryViewModel> Inventory { get; set; }
        public List<WarrantyViewModel> Warranties { get; set; }
        public List<EmiNewViewModel> Emi { get; set; }
        public List<CampaignViewModel> Campaigns { get; set; }
    }
    public class ProductBasicViewModel
    {
        public string Id { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public double PreviousPrice { get; set; }
        public int ProductID { get; set; }
        public double Discount { get; set; }
    }

    public class InventoryViewModel
    {
        public int ProductID { get; set; }
        public int StoreID { get; set; }
        public Int64 ProductCount { get; set; }

    }
    public class WarrantyViewModel
    {
        public int WarrantyTypeID { get; set; }
        public string WarrantyName { get; set; }
        public int Price { get; set; }
        public int IsDetfault { get; set; }
        public int DurationInMonths { get; set; }
        public int ProductID { get; set; }

    }
    public class EmiNewViewModel
    {
        public int ProductID { get; set; }
        public int BankID { get; set; }
        public string BankName { get; set; }
        public int Duration { get; set; }
        public string OptionName { get; set; }
        public int IsExtended { get; set; }
        public double InterestRate { get; set; }
    }
    public class CampaignViewModel
    {
        public int ProductID { get; set; }
        public int CampaignId { get; set; }
        public double Price { get; set; }
        public int ProductCount { get; set; }
    }
    public class CampaignProductViewModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Discount { get; set; }
        public int ProductID { get; set; }
    }
    public class ProductDic
    {
        public string ProductCode { get; set; }
        public int ProductID { get; set; }
    }
}