using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase
{

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(ILogger<HelloWorldController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("testdb")]
    public IActionResult Get()
    {
        var db = new ToDoDbContext();
        // users ให้ทุก column
        //var users = from x in db.User select x;
        //var users = db.User.Where(x => x.Id == "1234567890123").Select(x => new { nationalId = x.Id });
        // users ให้เฉพาะบาง column
        var users = from x in db.User where x.Id == "1234567890123" select new { nationalId = x.Id };
        if (!users.Any()) return NoContent();
        return Ok(users);
    }
}