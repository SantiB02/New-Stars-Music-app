namespace Merchanmusic.Services.Interfaces
{
    public interface IPaymentService
    {
        void ProcessPayment(string paymentMethod, decimal amount);
       
    }
}
