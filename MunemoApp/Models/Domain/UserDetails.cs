using MunemoApp.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunemoApp.Models.Domain
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        //public Users? Users { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string? Password
        {
            get
            {
                return string.IsNullOrEmpty(Password) ? null : Password.Trim();
                // return Users == null ? "" : Users.Password;
            }
        }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Province { get; set; }
        public string Gender { get; set; }
        public bool Facilitator { get; set; }

        [ForeignKey("UserId")]
        public Users? users { get; set; }
    }
}
