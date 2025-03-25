namespace DemoApp2025Spring.Api;

public class PersonService : IPersonService
{
    private readonly List<Person> _people;
    private readonly ILogger<PersonService> _logger;

    public PersonService(ILogger<PersonService> logger)
    {
        _people = [];
        _logger = logger;
    }

    public void Add(Person person)
    {
        _people.Add(person);
        _logger.LogInformation("Person added: {@Person}", person);
    }

    public void Delete(string id)
    {
        _people.RemoveAll(x => x.Id == id);
        _logger.LogInformation("Person deleted");
    }

    public List<Person> Get()
    {
        return _people;
    }

    public Person Get(string id)
    {
        return _people.Find(x => x.Id == id);
    }

    public void Update(Person person)
    {
        var oldPerson = Get(person.Id);

        oldPerson.Name = person.Name;
        oldPerson.Email = person.Email;
        oldPerson.BirthDate = person.BirthDate;

        _logger.LogInformation("Person updated");
    }
}