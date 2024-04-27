namespace Merchanmusic.Data.Entities
{
    public class Client : User
    {
        //public string Address { get; set; } en client o en user
        public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();
    }
}
