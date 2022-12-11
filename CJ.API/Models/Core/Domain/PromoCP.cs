using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CJ.API.Models.Core.Domain
{
    [Table("t_PromoCP")]
    public class PromoCp
    {
        [Key]
        public int ConsumerPromoId { get; set; }
        public string ConsumerPromoNo { get; set; }
        public string ConsumerPromoName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        

    }
}