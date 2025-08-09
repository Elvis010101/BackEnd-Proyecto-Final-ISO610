using Microsoft.AspNetCore.Mvc;

namespace BackEndProyectoFinalIso610.Controllers
{
   

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JWTService _jwtService;

        public AuthController(JWTService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // 🔹 Aquí iría la validación real con la base de datos
            if (request.Username == "admin" && request.Password == "1234")
            {
                var token = _jwtService.GenerateToken(request.Username, "Admin");
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
