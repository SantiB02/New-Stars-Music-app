using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payment
{
    public abstract class PaymentFactory
    {
        public abstract IPayment CreatePayment();
    }
}
