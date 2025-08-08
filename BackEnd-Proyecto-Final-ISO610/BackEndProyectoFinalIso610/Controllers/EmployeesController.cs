using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Created("", new { message = "Employee REGISTERED successfully", id = employee.EmployeeNumber });
        }

        [HttpDelete("{employeeNumber}/Delete")]
        public async Task<IActionResult> DeleteEmployee(int employeeNumber)
        {
            var emp = await _context.Employees.FindAsync(employeeNumber);
            if (emp == null) return NotFound(new { message = "Employee not found" });

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Employee {employeeNumber} deleted successfully" });
        }
    }
}
