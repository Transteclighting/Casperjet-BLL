using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CJ.API.Models.Core.Domain
{
    [Table("t_SmsMessageInividualHistory")]
    public class SmsMessageInividualHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        [Required]
        [StringLength(20)]
        [MinLength(11,ErrorMessage = "Mobile number should be minimum 11 digit")]
        public string MobileNo { get; set; }

        public int SendBy { get; set; }

        public DateTime SendDate { get; set; } = DateTime.Now;

        public bool? IsThroughApi { get; set; } = true;

    }
}