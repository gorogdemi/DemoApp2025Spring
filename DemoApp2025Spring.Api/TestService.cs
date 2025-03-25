namespace DemoApp2025Spring.Api;

public class TestService : ITestService
{
    private readonly Guid _data;

    public TestService()
    {
        _data = Guid.NewGuid();
    }

    public string GetGuid()
    {
        return _data.ToString();
    }
}