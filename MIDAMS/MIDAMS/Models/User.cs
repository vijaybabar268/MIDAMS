using System.ComponentModel.DataAnnotations.Schema;

namespace MIDAMS.Models
{
    [Table("tbl_users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }
    }
}