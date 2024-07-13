using Merchanmusic.Data.Entities;

namespace Merchanmusic.Services.Interfaces
{
    public interface ISaleOrderService
    {
        List<SaleOrder> GetAllByClient(string id);
        List<SaleOrder> GetAllByDate(DateTime date);
        SaleOrder? GetOne(int Id);
        SaleOrder CreateSaleOrder(SaleOrder saleOrder);
        SaleOrder UpdateSaleOrder(SaleOrder saleOrder);
        void DeleteSaleOrder(int id);
        List<SaleOrder> GetAllSaleOrders();
    }
}
