using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Merchanmusic.Enums;

namespace Merchanmusic.Data.Entities
{
    public abstract class User
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("UserRoleId")]
        public int UserRoleId { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Address { get; set; }

        public bool State { get; set; } = true;
        public UserRole UserRole { get; set; }

    }
}
