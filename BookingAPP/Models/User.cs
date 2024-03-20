using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPP.Models
{

    [Table("Users")]
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PermissionLevel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
