using Microsoft.Extensions.Logging;
using System;
using WebAPICoreSampleDemonstration2002.BusinessService;
using WebAPICoreSampleDemonstration2002.BusinessService.Interfaces;
using WebAPICoreSampleDemonstration2002.Data;
using WebAPICoreSampleDemonstration2002.Common;
using Xunit;

namespace WebAPICoreSampleDemonstration2002.Tests
{
    public class AsyncServiceTests
    {
        [Fact]
        public async void Should_return_DELETE_requests()
        {
            ILogger<ClientService> fakeLogger = new FakeLogger<ClientService>();

            IAsyncService<User> clientService = new ClientService(fakeLogger);
            int id = 5;
            var response = await clientService.DeleteAsync(id);

            Assert.Equal(200, (int)response.StatusCode);
        }

        [Fact]
        public async void Should_return_PATCH_requests()
        {
            ILogger<ClientService> fakeLogger = new FakeLogger<ClientService>();

            IAsyncService<User> clientService = new ClientService(fakeLogger);

            int id = 5;
            string payload = "{  \"name\": \"zubair\" }";
            string expectedOutput = "zubair";
            var response = await clientService.PatchAsync(id, payload);

            Assert.Equal(expectedOutput,response.name);
        }
    }
}
