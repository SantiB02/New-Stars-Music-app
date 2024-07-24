using Merchanmusic.Data;
using Merchanmusic.Data.Payments;
using Merchanmusic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Merchanmusic.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly MerchContext _context;
        public PaymentService(MerchContext context)
        {
            _context = context;
        }

        public void ProcessPayment(string paymentMethod, decimal amount, string payerId, int? installments = null, string? bank = null, string? details = null)
        {
            PaymentFactory factory = paymentMethod switch
            {
                "Credit Card" => new CreditCardPaymentFactory(),
        
                "Bank Transfer" => new BankTransferPaymentFactory(),
                _ => throw new ArgumentException("Invalid payment method")
            };

            IPayment payment = factory.CreatePayment();

            Payment paymentEntity;
            if (paymentMethod == "Credit Card" && installments.HasValue)
            {
                bool isPaymentProcessed = payment.ProcessPayment(amount, installments.Value);
                if (isPaymentProcessed == true)
                {
                    paymentEntity = new CreditCardPayment
                    {
                        Amount = amount,
                        Installments = installments.Value,
                        AmountPerInstallment = (decimal)(amount / installments),
                        Date = DateTime.Now,
                        PayerId = payerId,
                    };
                } else
                {
                    throw new Exception("Error processing credit card");
                }            
            }
            else if (paymentMethod == "Bank Transfer")
            {
                bool isPaymentProcessed = payment.ProcessPayment(amount);
                if (isPaymentProcessed == true)
                {
                    paymentEntity = new BankTransferPayment
                    {
                        Amount = amount,
                        PayerId = payerId,
                        Bank = bank,
                        Details = details,
                        Date = DateTime.Now
                    };
                } else
                {
                    throw new Exception("Error processing bank transfer");
                }
            }
            else
            {
                throw new ArgumentException("Invalid payment method or missing installments for Credit Card");
            }

            _context.Payments.Add(paymentEntity);
            _context.SaveChanges();
        }
    }
}
