using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/orders/{orderNumber}/details")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/orders/{orderNumber}/details/{productCode}
        [HttpGet("{productCode}")]
        public async Task<IActionResult> GetOrderDetail(int orderNumber, string productCode)
        {
            var detail = await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderNumber == orderNumber && od.ProductCode == productCode);

            if (detail == null) return NotFound(new { message = "Order detail not found" });
            return Ok(detail);
        }

        // PUT: api/orders/{orderNumber}/details/edit/{productCode}
        [HttpPut("edit/{productCode}")]
        public async Task<IActionResult> EditOrderDetail(int orderNumber, string productCode, [FromBody] OrderDetail updatedDetail)
        {
            var detail = await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderNumber == orderNumber && od.ProductCode == productCode);

            if (detail == null) return NotFound(new { message = "Order detail not found" });

            detail.QuantityOrdered = updatedDetail.QuantityOrdered;
            detail.PriceEach = updatedDetail.PriceEach;
            detail.OrderLineNumber = updatedDetail.OrderLineNumber;

            await _context.SaveChangesAsync();
            return Ok(new { message = $"Order detail for product {productCode} in order {orderNumber} updated successfully" });
        }

        // DELETE: api/orders/{orderNumber}/details/{productCode}
        [HttpDelete("{productCode}")]
        public async Task<IActionResult> DeleteProductFromOrder(int orderNumber, string productCode)
        {
            var detail = await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderNumber == orderNumber && od.ProductCode == productCode);

            if (detail == null) return NotFound(new { message = "Order detail not found" });

            _context.OrderDetails.Remove(detail);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Product {productCode} removed from order {orderNumber}" });
        }
    }
}
