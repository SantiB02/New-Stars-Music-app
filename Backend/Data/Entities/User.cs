using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Merchanmusic.Enums;

namespace Merchanmusic.Data.Entities
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }
        public string? Address { get; set; }
       // public string UserType { get; set; }

        public string UserType { get; set; } = nameof(UserRoleEnum.Client); 
        public bool State { get; set; } = true;
    }
}
