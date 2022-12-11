using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CJ.API.Models.Core.Domain
{
    [Table("t_FinishedGoodsPrice")]
    public class ProductPrice
    {
        [Key]
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public double CostPrice { get; set; }
        public double TradePrice { get; set; }
        public double Nsp { get; set; }
        public double Rsp { get; set; }
        public double SpecialPrice { get; set; }
        public double DistributorPrice { get; set; }
        public double Vat { get; set; }
        public int IsCurrent { get; set; }
        public int UploadStatus { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime DownloadDate { get; set; }
        public int RowStatus { get; set; }
        public int Terminal { get; set; }
        public int EntryUserId { get; set; }
        public string Remarks { get; set; }
        public double Mc { get; set; }


    }

}