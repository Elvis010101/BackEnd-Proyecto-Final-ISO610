using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndProyectoFinalIso610.DATA;
using BackEndProyectoFinalIso610.Models;

namespace BackEndProyectoFinalIso610.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        // PUT: api/orders/Create
        [HttpPut("Create")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Invalid order data");

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllOrders),
                new { orderNumber = order.OrderNumber },
                new { message = "Order created successfully", order.OrderNumber });
        }

        // DELETE: api/orders/{orderNumber}/Delete
        [HttpDelete("{orderNumber}/Delete")]
        public async Task<IActionResult> DeleteOrder(int orderNumber)
        {
            var order = await _context.Orders.FindAsync(orderNumber);

            if (order == null)
                return NotFound(new { message = "Order not found" });

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Order {orderNumber} deleted successfully" });
        }
    }
}
