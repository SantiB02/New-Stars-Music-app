using Merchanmusic.Data.Models;
using Merchanmusic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchanmusic.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult ProcessPayment([FromBody] PaymentRequest request)
        {
            if (request.PaymentMethod == "Credit Card")
            {
                _paymentService.ProcessPayment(request.PaymentMethod, request.Amount, request.PayerId, request.Installments);
                return Ok();
            } else if (request.PaymentMethod == "Bank Transfer")
            {
                _paymentService.ProcessPayment(request.PaymentMethod, request.Amount, request.PayerId, null, request.Bank, request.Details);
                return Ok();
            } else
            {
                return BadRequest("Invalid payment method. Only Credit Card and Bank Transfer are supported");
            }
            
        }
    }
}
