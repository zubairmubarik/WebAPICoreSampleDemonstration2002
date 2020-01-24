using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPICoreSampleDemonstration2002.BusinessService.Interfaces;
using WebAPICoreSampleDemonstration2002.Data;
using WebAPICoreSampleDemonstration2002.Common.Constants;
using Microsoft.Extensions.Logging;


namespace WebAPICoreSampleDemonstration2002.BusinessService
{
    public class ClientService : IAsyncService<User>
    {
        #region Data Members

        private readonly HttpClient _httpClient; /* As Singleton */
        private readonly ILogger<ClientService> _logger;

        #endregion

        #region Constructor with Dependency Injection
        public ClientService(ILogger<ClientService> logger)
        {
            _httpClient = new HttpClient();
            _logger = logger;
            _logger.LogInformation($"Executing Service:{this.GetType().Name}");
        }
        #endregion

        #region Public Service Actions

        public async Task<IEnumerable<User>> GetAsync()
        {           
            var responseString = await GetUsers();
            return JsonConvert.DeserializeObject<IEnumerable<User>>(responseString);
        }

        public async Task<string> GetAsync(int id)
        {
            return await GetUser(id);
        }
        
        public async Task<string> PostAsync(User value)
        {
            string payload = JsonConvert.SerializeObject(value);
            // TODO: Write Exception Handling in below code
            return await PostUser(payload);
        }

        public async Task<string> PutAsync(int id, User value)
        {
            string payload = JsonConvert.SerializeObject(value);
            // TODO: Write Exception Handling in below code
            return await PutUser(id, payload);
        }

        public async Task<User> PatchAsync(int id, string payload)
        {
            // TODO: Write Exception Handling in below code
            var responseString = await PatchUser(id, payload);
            return JsonConvert.DeserializeObject<User>(responseString);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            return await DeleteUser(id);
        }

        #endregion

        #region Private Methods

        private async Task<string> GetUsers()
        {
            var uri = $"{ConstantValues.BaseAddress}/users";

            return await _httpClient.GetStringAsync(uri);
        }

        /// <summary>
        /// Get reult in Response Object
        /// HTTPClient will be disposed in this call
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>httpResponseMessage</returns>
        private async Task<string> GetUser(int id)
        {
            var uri = new Uri($"{ConstantValues.BaseAddress}/users/{id}");

            var response = string.Empty;
            //using (var client = new HttpClient())
            //{
                HttpResponseMessage result = await _httpClient.GetAsync(uri);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
           // }
            return response;
        }

        private async Task<string> PostUser(string payload)
        {
            var uri = new Uri($"{ConstantValues.BaseAddress}/users");
            HttpContent c = new StringContent(payload, Encoding.UTF8, HTTPContentTypes.ApplicationJson);

            using (var client = new HttpClient())
            {
                var httpResponse = await client.PostAsync(uri, c);

                httpResponse.EnsureSuccessStatusCode(); /* Throws Exception if IsSuccessStausCode is False */
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }

        private async Task<string> PutUser(int id, string payload)
        {
            var uri = new Uri($"{ConstantValues.BaseAddress}/users/{id}");
            HttpContent c = new StringContent(payload, Encoding.UTF8, HTTPContentTypes.ApplicationJson);

            using (var client = new HttpClient())
            {
                var httpResponse = await client.PutAsync(uri, c);

                httpResponse.EnsureSuccessStatusCode(); /* Throws Exception if IsSuccessStausCode is False */
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        private async Task<string> PatchUser(int id, string payload)
        {
            var uri = new Uri($"{ConstantValues.BaseAddress}/users/{id}");
            HttpContent c = new StringContent(payload, Encoding.UTF8, HTTPContentTypes.ApplicationJson);

            using (var client = new HttpClient())
            {
                var httpResponse = await client.PatchAsync(uri, c);

                httpResponse.EnsureSuccessStatusCode(); /* Throws Exception if IsSuccessStausCode is False */
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        private async Task<HttpResponseMessage> DeleteUser(int id)
        {
            var uri = new Uri($"{ConstantValues.BaseAddress}/users/{id}");
         
            using (var client = new HttpClient())
            {
                try
                {
                    var httpResponse = await client.DeleteAsync(uri);

                    httpResponse.EnsureSuccessStatusCode(); /* Throws Exception if IsSuccessStausCode is False */

                    return httpResponse;

                }catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion
    }
}
