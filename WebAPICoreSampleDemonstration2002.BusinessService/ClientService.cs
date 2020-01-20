using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPICoreSampleDemonstration2002.BusinessService.Interfaces;
using WebAPICoreSampleDemonstration2002.Data;
using WebAPICoreSampleDemonstration2002.Common.Constants;


namespace WebAPICoreSampleDemonstration2002.BusinessService
{
    public class ClientService : IAsyncService<User>
    {
        private readonly HttpClient _httpClient; /* As Singleton */
       
        #region Public Methods
        public ClientService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await GetUsers();
        }

        public async Task<string> GetAsync(int id)
        {
            return await GetUser(id);
        }

        public Task<HttpResponseMessage> PutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PatchAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> DeleteAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<string> PostAsync(User value)
        {
            string payload = JsonConvert.SerializeObject(value);                    
            // TODO: Write Exception Handling in below code
            return await PostUser(payload);
        }
        #endregion

        #region Private Methods

        private async Task<IEnumerable<User>> GetUsers()
        {
            var uri = $"{ConstantValues.BaseAddress}/users";

            var responseString = await _httpClient.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<IEnumerable<User>>(responseString);
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
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(uri);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }
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

        #endregion
    }
}
