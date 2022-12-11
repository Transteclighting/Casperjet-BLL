using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CJ.API.Models.Core.Domain
{
    [Table("t_ProductStock")]
    public class ProductStock
    {
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
        [Key, Column(Order = 1)]
        public int WarehouseId { get; set; }
        public int StockType { get; set; }
        public Int64 CurrentStock { get; set; }
        public decimal CurrentStockValue { get; set; }
        public int? BookingStock { get; set; }
        public int? TransitStock { get; set; }
        [Key, Column(Order = 2)]
        public int ChannelId { get; set; }
        public byte? Status { get; set; }
    }
}