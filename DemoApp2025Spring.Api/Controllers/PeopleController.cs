using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<IActionResult> Add([FromBody] Person person)
    {
        var existingPerson = await _demoDataContext.People.FindAsync(person.Id);

        if (existingPerson is not null)
        {
            return Conflict();
        }

        _demoDataContext.People.Add(person);
        await _demoDataContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existingPerson = await _demoDataContext.People.FindAsync(id);

        if (existingPerson is null)
        {
            return NotFound();
        }

        _demoDataContext.People.Remove(existingPerson);
        await _demoDataContext.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetAll()
    {
        var people = await _demoDataContext.People.ToListAsync();
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Person>> Get(string id)
    {
        var person = await _demoDataContext.People.FindAsync(id);

        if (person is null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpGet("{id}/items")]
    public async Task<ActionResult<List<Item>>> GetItems(string id)
    {
        var person = await _demoDataContext.People.FindAsync(id);

        if (person is null)
        {
            return NotFound();
        }

        return Ok(person.Items);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Person person)
    {
        if (id != person.Id)
        {
            return BadRequest();
        }

        var oldPerson = await _demoDataContext.People.FindAsync(id);

        if (oldPerson is null)
        {
            return NotFound();
        }

        oldPerson.Email = person.Email;
        oldPerson.Name = person.Name;
        oldPerson.BirthDate = person.BirthDate;

        _demoDataContext.People.Update(oldPerson);
        await _demoDataContext.SaveChangesAsync();

        return Ok();
    }
}