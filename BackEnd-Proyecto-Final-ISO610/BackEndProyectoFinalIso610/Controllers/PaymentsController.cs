using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/customers/{customerNumber}/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments(int customerNumber)
        {
            var payments = await _context.Payments.Where(p => p.CustomerNumber == customerNumber).ToListAsync();
            return Ok(payments);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePayment(int customerNumber, [FromBody] Payment payment)
        {
            payment.CustomerNumber = customerNumber;
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return Created("", new { message = $"Payment registered for customer {customerNumber}" });
        }

        [HttpDelete("{checkNumber}/Delete")]
        public async Task<IActionResult> DeletePayment(int customerNumber, string checkNumber)
        {
            var payment = await _context.Payments.FindAsync(customerNumber, checkNumber);
            if (payment == null) return NotFound(new { message = "Payment not found" });

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return Ok(new { message = $"Payment {checkNumber} deleted for customer {customerNumber}" });
        }
    }
}
