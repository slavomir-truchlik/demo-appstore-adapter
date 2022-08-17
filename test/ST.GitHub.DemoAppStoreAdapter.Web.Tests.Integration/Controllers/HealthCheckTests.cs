using Microsoft.AspNetCore.Mvc.Testing;

namespace ST.GitHub.DemoAppStoreAdapter.Web.Tests.Integration.Controllers
{
    public class HealthCheckTests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task HealthCheck_ApplicationRuns_ReturnsOk() 
        {
            var response = await _client.GetAsync("/healthcheck");

            response.EnsureSuccessStatusCode();
        }

        [OneTimeTearDown]
        public void TearDown() 
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}