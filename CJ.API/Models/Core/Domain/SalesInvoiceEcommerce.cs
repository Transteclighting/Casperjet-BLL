using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CJ.API.Models.Core.Domain
{
    [Table("t_SalesInvoiceEcommerce")]
    public class SalesInvoiceEcommerce
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EComOrderId { get; set; }
        [Required]
        public int LeadType { get; set; }
        [Required]
        public string OrderNo { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Outlet { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public double DeliveryCharge { get; set; }
        [Required]
        public double Discount { get; set; }
        public string CopunNo { get; set; }
        [Required]
        public int ConsumerId { get; set; }
        [Required]
        public string ConsumerName { get; set; }
        [Required]
        public string Addrress { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        public string Remarks { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int PaymentType { get; set; }
        public int? SalesPersonId { get; set; }
        public int? BankId { get; set; }
        public string BankName { get; set; }
        public int? CardTypeId { get; set; }
        public string CardType { get; set; }
        public int? IsEmi { get; set; }
        public int? NoOfInstallment { get; set; }
        public string InstrumentNo { get; set; }
        public DateTime? InstrumentDate { get; set; }
        public int? CardCategoryId { get; set; }
        public string CardCategory { get; set; }
        public string ApprovalNo { get; set; }
        public string RefInvoiceNo { get; set; }

    }
}