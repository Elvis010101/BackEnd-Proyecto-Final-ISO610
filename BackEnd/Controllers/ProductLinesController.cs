using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductLinesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductLinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/productlines
        [HttpGet]
        public async Task<IActionResult> GetAllProductLines()
        {
            var lines = await _context.productlines.ToListAsync();
            return Ok(lines);
        }

        // POST: api/productline/Create
        [HttpPost("Create")]
        public async Task<IActionResult> CreateProductLine([FromBody] ProductLine productLine)
        {
            if (productLine == null) return BadRequest("Invalid product line data");

            try
            {
                _context.productlines.Add(productLine);
                await _context.SaveChangesAsync();

                return Created("", new { message = $"Product line '{productLine.ProductLineName}' created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.InnerException?.Message ?? ex.Message });
            }
        }

        // DELETE: api/productlines/{productLine}/Delete
        [HttpDelete("{productLine}/Delete")]
        public async Task<IActionResult> DeleteProductLine(string productLine)
        {
            var line = await _context.productlines.FindAsync(productLine);
            if (line == null) return NotFound(new { message = "Product line not found" });

            _context.productlines.Remove(line);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Product line '{productLine}' deleted successfully" });
        }
    }
}
