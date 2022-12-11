using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CJ.API.Models.Core.Domain
{
    [Table("t_SMSAPICredential")]
    public class SmsApiCredential
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Uri { get; set; }
        public int IsActive { get; set; }
    }
}