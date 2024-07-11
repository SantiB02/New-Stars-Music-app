using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payment
{
    public class BankTransferPaymentFactory : PaymentFactory
    {
        public override IPaymentService CreatePayment()
        {
            return new BankTransferPayment();
        }
    }
}
