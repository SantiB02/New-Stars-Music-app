namespace Merchanmusic.Data.Models
{
    public class ClientUpdateDto
    {
        public string Address { get; set; }
        public string Apartment { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public bool? WaitingValidation { get; set; }
    }
}
