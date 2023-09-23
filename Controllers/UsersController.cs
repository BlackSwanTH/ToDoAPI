using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ToDoAPI.Models;
using System.Data.Common;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Reflection.Emit;

namespace ToDoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    // [Route("{User_Id}")]
    // [HttpGet]
    // public IActionResult Get(string User_Id)
    // {
    //     var db = new ToDoDbContext();
    //     // var s = User.Identity.Name;
    //     var something = from x in db.Activity where x.User_Id.Equals(User_Id) select x;
    //     return Ok(something);
    // }
    [Route("")]
    [HttpGet]
    public IActionResult Get([FromBody] DTOs.Login data)
    {
        var db = new ToDoDbContext();
        // var s = User.Identity.Name;
        var something = from x in db.Activity where x.User_Id.Equals(data.Id) select x;
        return Ok(something);
    }
    // Put is replacing an existing data
    [Route("{id}")]
    [HttpPut]
    public IActionResult Put(uint id, [FromBody] DTOs.Activity data)
    {
        var db = new ToDoDbContext();
        var a = db.Activity.Find(id);
        if (a == null) return NotFound();
        a.Name = data.Name;
        a.When = data.When;
        db.SaveChanges();

        return Ok(a.Id);
    }
    [Route("{Userid}")]
    [HttpPost]
    public IActionResult Post([FromRoute] string Userid, [FromBody] DTOs.Activity data)
    {
        var db = new ToDoDbContext();
        var something = new Models.Activity();
        if (db.User.Find(Userid) == null) return Unauthorized();
        something.User_Id = Userid;
        something.Name = data.Name;
        //to thai date
        // something.When = thaidate(data.When);
        System.Globalization.CultureInfo _cultureaEnInfo = new System.Globalization.CultureInfo("th-TH");
        //date = DateTime.Parse(thaiBudistDate, provider);
        var s = data.When.ToString("dd MMM yyyy");
        string so = data.When.ToString("dd MMM yyyy", _cultureaEnInfo);
        Console.WriteLine(so);
        //something.When = DateTime.ParseExact(so, "dd MMM yyyy", CultureInfo.InvariantCulture);
        something.When = data.When;
        db.Activity.Add(something);
        db.SaveChanges();
        return Ok(new { id = something.Id });
    }
}