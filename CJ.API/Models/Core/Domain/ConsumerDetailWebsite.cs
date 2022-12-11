using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CJ.API.Models.Core.Domain
{
 
    [Table("t_ConsumerDetailWebsite")]
    public class ConsumerDetailWebsite
    {
        [Key]
        public Int64 Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string Zip { get; set; }
        
    }
}