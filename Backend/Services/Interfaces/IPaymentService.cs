namespace Merchanmusic.Services.Interfaces
{
    public interface IPaymentService
    {
        void ProcessPayment(string paymentMethod, decimal amount, string payerId, int? installments = null, string? bank = null, string? details = null);
    }
}
