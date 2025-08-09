using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OfficesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOffices()
        {
            return Ok(await _context.offices.ToListAsync());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateOffice([FromBody] Office office)
        {
            try
            {
                _context.offices.Add(office);
                await _context.SaveChangesAsync();
                return Created("", new { message = $"Office '{office.OfficeCode}' created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpDelete("{officeCode}/Delete")]
        public async Task<IActionResult> DeleteOffice(string officeCode)
        {
            var office = await _context.offices.FindAsync(officeCode);
            if (office == null) return NotFound(new { message = "Office not found" });

            _context.offices.Remove(office);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Office '{officeCode}' deleted successfully" });
        }
    }
}
