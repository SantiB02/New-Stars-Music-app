namespace Merchanmusic.Data.Entities
{
    public class Client : User
    {
        public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();
    }
}
