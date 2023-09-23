using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.DTOs;

namespace ToDoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly ILogger<ActivitiesController> _logger;

    public ActivitiesController(ILogger<ActivitiesController> logger)
    {
        _logger = logger;
    }

    [Route("{id}")]
    [HttpGet]
    public IActionResult Get(uint Id)
    {
        var db = new ToDoDbContext();

        //var activity = (from x in db.Activity where x.Id == Id select x).FirstOrDefault(); //LINQ Usually use this
        //var activity = db.Activity.Where(x => x.Id == Id).Select(x => x).FirstOrDefault(); //Arrow Function
        var activity = db.Activity.Find(Id); //Only for Primary Key

        if (activity == null) return NotFound();

        return Ok(activity);
    }
    [Route("")]
    [HttpGet]
    public IActionResult Get2()
    {
        var db = new ToDoDbContext();
        var something = from x in db.Activity select x;

        return Ok(something);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DTOs.Activity data)
    {
        var db = new ToDoDbContext();
        var a = new Models.Activity();
        a.Name = data.Name;
        a.When = data.When;
        db.Activity.Add(a);
        db.SaveChanges();

        return Ok(a.Id);
        // return Ok(new { a.name = data.Name, a.when = data.When });
    }

    [Route("{id}")]
    [HttpPut] //Update every field if want to update any field (not all) you can use HttpPatch
    public IActionResult Put(uint Id, [FromBody] DTOs.Activity data)
    {
        var db = new ToDoDbContext();
        var a = db.Activity.Find(Id);
        if (a == null) return NotFound();
        a.Name = data.Name;
        a.When = data.When;
        db.SaveChanges();

        return Ok(a.Id);
        // return Ok(new { id = a.Id }); //sent to front-end or just OK() ^_^
    }

    [Route("{id}")]
    [HttpDelete] //Update every field if want to update any field (not all) you can use HttpPatch
    public IActionResult Delete(uint Id)
    {
        var db = new ToDoDbContext();
        var a = db.Activity.Find(Id);
        if (a == null) return NotFound();
        db.Activity.Remove(a);
        db.SaveChanges();

        return Ok(a.Id);
        // return Ok(new { id = a.Id }); //sent to front-end or just OK() ^_^
    }
}
