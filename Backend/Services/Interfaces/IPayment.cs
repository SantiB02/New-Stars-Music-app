namespace Merchanmusic.Services.Interfaces
{
    public interface IPayment
    {
        bool ProcessPayment(decimal amount);
        bool ProcessPayment(decimal amount, int installments);
    }
}
