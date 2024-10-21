using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using KoiOrderingSystemInJapan.Service;
using Microsoft.AspNetCore.Mvc;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService) => _paymentService = paymentService;

        // GET: api/Payments
        [HttpGet]
        public async Task<IServiceResult> GetPayments()
        {
            return await _paymentService.GetAll();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<IServiceResult> GetPayment(int id)
        {
            var payment = await _paymentService.GetById(id);
            return payment;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return new ServiceResult(Const.FAIL_UPDATE_CODE, "Payment ID mismatch");
            }

            return await _paymentService.Save(payment);
        }

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IServiceResult> PostPayment(Payment payment)
        {
            return await _paymentService.Save(payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeletePayment(int id)
        {
            return await _paymentService.DeleteById(id);
        }
    }
}
