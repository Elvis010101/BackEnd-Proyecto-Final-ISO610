using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await _context.customers.ToListAsync());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            _context.customers.Add(customer);
            await _context.SaveChangesAsync();
            return Created("", new { message = "Customer created successfully", customerNumber = customer.CustomerNumber });
        }

        [HttpDelete("{customerNumber}/Delete")]
        public async Task<IActionResult> DeleteCustomer(int customerNumber)
        {
            var cust = await _context.customers.FindAsync(customerNumber);
            if (cust == null) return NotFound(new { message = "Customer not found" });

            _context.customers.Remove(cust);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Customer {customerNumber} deleted successfully" });
        }
    }
}
