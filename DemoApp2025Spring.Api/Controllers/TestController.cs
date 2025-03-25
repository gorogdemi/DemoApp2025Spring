using Microsoft.AspNetCore.Mvc;

namespace DemoApp2025Spring.Api.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    private readonly ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpGet("data")]
    public ActionResult<string> GetData()
    {
        return _testService.GetGuid();
    }
}