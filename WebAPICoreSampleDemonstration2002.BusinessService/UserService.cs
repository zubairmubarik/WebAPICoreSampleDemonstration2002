using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPICoreSampleDemonstration2002.BusinessService
{
    public class UserService
    {
       // private static readonly HttpClient client = new HttpClient();

       // private readonly IHttpClientFactory _clientFactory;

       // public IEnumerable<GitHubBranch> Branches { get; private set; }

      //  public bool GetBranchesError { get; private set; }
      /*
        public UserService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        */
        /*
        private async Task GetUser()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
          "https://api.github.com/repos/aspnet/AspNetCore.Docs/branches");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                Branches = await JsonSerializer.DeserializeAsync
                    <IEnumerable<GitHubBranch>>(responseStream);
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<GitHubBranch>();
            }
            //var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            //var repositories = await JsonSerializer.DeserializeAsync<List<User>>(await streamTask);
            //return repositories;
        }
        */
    }
}
