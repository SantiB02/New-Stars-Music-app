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
            _paymentService.ProcessPayment(request.PaymentMethod, request.Amount);
            return Ok();
        }
    }
}
