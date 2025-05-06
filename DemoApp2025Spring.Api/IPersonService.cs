using DemoApp2025Spring.Shared;

namespace DemoApp2025Spring.Api;

public interface IPersonService
{
    void Add(Person person);

    void Delete(string id);

    List<Person> Get();

    Person Get(string id);

    void Update(Person person);
}