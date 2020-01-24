using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPICoreSampleDemonstration2002.BusinessService.Interfaces;
using WebAPICoreSampleDemonstration2002.Common.Constants;
using WebAPICoreSampleDemonstration2002.Data;

namespace WebAPICoreSampleDemonstration2002.API.HttpClientFactory
{
    public class ClientFactoryService : IAsyncService<CommentData>
    {
        #region Data Members
        private readonly IHttpClientFactory _clientFactory;
        #endregion

        #region Constructor with Dependency Injection
        public ClientFactoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #endregion

        #region Public Service Actions
        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            return await DeleteCommentData(id);
        } 

        public async Task<IEnumerable<CommentData>> GetAsync()
        {
            var responseString = await GetCommentData();
            return JsonConvert.DeserializeObject<IEnumerable<CommentData>>(responseString);
        }

        public async Task<string> GetAsync(int id)
        {
            var responseString = await GetCommentData(id);
            return responseString;
        }

        public Task<CommentData> PatchAsync(int id, string payload)
        {
            throw new NotImplementedException();
        }

        public  async Task<string> PostAsync(CommentData value)
        {
            var responseString = await PostCommentData(value);
            return responseString;
        }

        public async Task<string> PutAsync(int id, CommentData value)
        {
            var payload = JsonConvert.SerializeObject(value);

            return await PutCommentData(id, payload);
        }
        #endregion

        #region Private Methods

        private async Task<string> GetCommentData()
        {           
            var uri = new Uri($"{ConstantValues.BaseAddress}/comments");
            var client = _clientFactory.CreateClient();

            return await client.GetStringAsync(uri);
        }

        private async Task<string> GetCommentDataWithHeaders()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{ConstantValues.BaseAddress}/comments");

            /*Update Headers
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");*/
            
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"StatusCode: {response.StatusCode}";
            }
        }

        private async Task<string> GetCommentData(int id)
        {
            var uri = new Uri($"{ConstantValues.BaseAddress}/comments/{id}");
            var client = _clientFactory.CreateClient();

            return await client.GetStringAsync(uri);
        }

        private async Task<string> PostCommentData(CommentData value)
        {
            var uri = new Uri($"{ConstantValues.BaseAddress}/comments");
            string payload = JsonConvert.SerializeObject(value);
            // TODO: Write Exception Handling in below code

            HttpContent c = new StringContent(payload, Encoding.UTF8, HTTPContentTypes.ApplicationJson);
           
            using (var client = _clientFactory.CreateClient())
            {
                var httpResponse = await client.PostAsync(uri, c);

                httpResponse.EnsureSuccessStatusCode(); /* Throws Exception if IsSuccessStausCode is False */
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }

        private async Task<HttpResponseMessage> DeleteCommentData(int id)
        {
            var uri = new Uri($"{ConstantValues.BaseAddress}/comments/{id}");
            var client = _clientFactory.CreateClient();

            return await client.DeleteAsync(uri);
        }

        private async Task<string> PutCommentData(int id, string payload)
        {
            var uri = new Uri($"{ConstantValues.BaseAddress}/comments/{id}");
            HttpContent c = new StringContent(payload, Encoding.UTF8, HTTPContentTypes.ApplicationJson);

            using (var client = _clientFactory.CreateClient())
            {
                var httpResponse = await client.PutAsync(uri, c);

                httpResponse.EnsureSuccessStatusCode(); /* Throws Exception if IsSuccessStausCode is False */
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        #endregion
    }
}
