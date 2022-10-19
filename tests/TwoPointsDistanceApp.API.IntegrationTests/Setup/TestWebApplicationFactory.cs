using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TwoPointsDistanceApp.API.IntegrationTests.Setup;

public class TestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    public HttpClient HttpClient { get; }

    public TestWebApplicationFactory()
    {
        HttpClient = CreateClient();
    }
}