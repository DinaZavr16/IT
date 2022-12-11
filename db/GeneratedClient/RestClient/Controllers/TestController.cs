using Microsoft.AspNetCore.Mvc;
using MyNamespace;

namespace GeneratedClient.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private Client _apiClient;
    public TestController()
    {
        _apiClient = new Client("http://displayit-app-test.centralus.azurecontainer.io:7070/", new HttpClient());
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDatabases()
    {
        return Ok(await _apiClient.DatabaseGETAsync());
    }
}