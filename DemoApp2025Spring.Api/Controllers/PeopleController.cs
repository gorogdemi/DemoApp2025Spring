using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoApp2025Spring.Api.Controllers;

[ApiController]
[Route("people")]
public class PeopleController : ControllerBase
{
    private readonly DemoDataContext _demoDataContext;

    public PeopleController(DemoDataContext demoDataContext)
    {
        _demoDataContext = demoDataContext;
    }

    [HttpPost]
    public IActionResult Add([FromBody] Person person)
    {
        var existingPerson = _demoDataContext.People.Find(person.Id);

        if (existingPerson is not null)
        {
            return Conflict();
        }

        _demoDataContext.People.Add(person);
        _demoDataContext.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var existingPerson = _demoDataContext.People.Find(id);

        if (existingPerson is null)
        {
            return NotFound();
        }

        _demoDataContext.People.Remove(existingPerson);
        _demoDataContext.SaveChanges();

        return Ok();
    }

    [HttpGet]
    public ActionResult<List<Person>> GetAll()
    {
        var people = _demoDataContext.People.ToList();
        return Ok(people);
    }

    [HttpGet("{id}")]
    public ActionResult<Person> Get(string id)
    {
        var person = _demoDataContext.People.Find(id);

        if (person is null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] Person person)
    {
        if (id != person.Id)
        {
            return BadRequest();
        }

        var oldPerson = _demoDataContext.People.Find(id);

        if (oldPerson is null)
        {
            return NotFound();
        }

        oldPerson.Email = person.Email;
        oldPerson.Name = person.Name;
        oldPerson.BirthDate = person.BirthDate;

        _demoDataContext.People.Update(oldPerson);
        _demoDataContext.SaveChanges();

        return Ok();
    }
}