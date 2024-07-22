using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Merchanmusic.Enums;

namespace Merchanmusic.Data.Entities
{
    public abstract class User
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Apartment { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

        public bool State { get; set; } = true;
        public string Role { get; set; }
        public bool? DarkModeOn { get; set; }
        public bool WaitingValidation { get; set; } = false;

    }
}
