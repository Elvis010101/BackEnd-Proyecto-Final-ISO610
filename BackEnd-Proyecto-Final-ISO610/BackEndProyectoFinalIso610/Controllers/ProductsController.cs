using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndProyectoFinalIso610.Models;
using Backend.Data;

namespace BackEndProyectoFinalIso610.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        // POST: api/products/Create
        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Invalid product data");

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllProducts),
                new { productCode = product.ProductCode },
                new { message = "Product created successfully", product.ProductCode });
        }

        // DELETE: api/products/Delete/{productCode}
        [HttpDelete("Delete/{productCode}")]
        public async Task<IActionResult> DeleteProduct(string productCode)
        {
            var product = await _context.Products.FindAsync(productCode);

            if (product == null)
                return NotFound(new { message = "Product not found" });

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product eliminated successfully", product.ProductCode });
        }
    }
}
