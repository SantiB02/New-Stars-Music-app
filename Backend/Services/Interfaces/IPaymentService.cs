namespace Merchanmusic.Services.Interfaces
{
    public interface IPaymentService
    {
        void ProcessPayment(string paymentMethod, decimal amount, string payerId, string receiverId, int? installments = null, string? bank = null);
    }
}
