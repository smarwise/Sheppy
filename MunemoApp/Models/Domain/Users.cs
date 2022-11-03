using System.ComponentModel.DataAnnotations;

namespace MunemoApp.Models.Domain
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
    }


}
