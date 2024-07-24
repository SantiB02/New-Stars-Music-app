using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payments
{
    public abstract class PaymentFactory
    {
        public abstract IPayment CreatePayment();
    }
}
