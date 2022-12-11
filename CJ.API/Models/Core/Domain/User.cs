
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CJ.API.Models.Core.Domain
{
    [Table("t_User")]
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        public string UserFullName { get; set; }

        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string UserSbUs { get; set; }
        public int? EmployeeId { get; set; }
    }
}