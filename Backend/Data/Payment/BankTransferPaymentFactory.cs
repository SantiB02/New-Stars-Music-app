using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Data.Payment
{
    public class BankTransferPaymentFactory : PaymentFactory
    {
        public override IPayment CreatePayment()
        {
            return new BankTransferPayment();
        }
    }
}
