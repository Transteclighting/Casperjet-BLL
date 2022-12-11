using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CJ.API.Models.Core.Domain
{
    [Table("t_Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
    }
}