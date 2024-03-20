using Microsoft.AspNetCore.Mvc;
using BookingAPP.Models;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userService.RegisterUser(model.Email, model.Password, model.FirstName, model.LastName);

        if (result)
        {
            return Ok(new { message = "Registracija uspješna" });
        }
        else
        {
            return BadRequest(new { message = "Email već postoji" });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userService.LoginUser(model.Email, model.Password);

        if (user != null)
        {
            // Implementirajte generiranje JWT tokena ili slične mehanizme autentifikacije ovdje
            return Ok(new { message = "Prijava uspješna" });
        }
        else
        {
            return Unauthorized(new { message = "Email ili lozinka su netočni" });
        }
    }
}

public class RegisterModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}
