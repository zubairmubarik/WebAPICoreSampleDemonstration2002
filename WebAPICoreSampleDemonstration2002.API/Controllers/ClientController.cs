using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAPICoreSampleDemonstration2002.BusinessService;
using WebAPICoreSampleDemonstration2002.BusinessService.Interfaces;
using WebAPICoreSampleDemonstration2002.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPICoreSampleDemonstration2002.API.Controllers
{
    [Route("[controller]")]
    public class ClientController : Controller
    {
        #region Data Members

        private readonly IAsyncService<User> _clientService;
        private readonly ILogger<ClientController> _logger;
        
        #endregion

        #region Constructor with Dependency Injection
        public ClientController(IAsyncService<User> clientService, ILogger<ClientController> logger)
        {
            _clientService = clientService;
            _logger = logger;
            _logger.LogInformation($"Executing Controller:{this.GetType().Name}");
        }
        #endregion

        #region HTTP Verbs
        // GET: <controller>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {           
            return await _clientService.GetAsync();
        }

        // GET <controller>/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {           
            return await _clientService.GetAsync(id);
        }

        // POST <controller>
        [HttpPost]
        public async Task<string> Post([FromBody]User user)
        {
            return await _clientService.PostAsync(user);
        }

        // PUT <controller>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody]User user)
        {
            return await _clientService.PutAsync(id, user);
        }

        // Input:  "{  \"name\": \"zubair\" }"
        // PATCH <controller>/5
        [HttpPatch("{id}")]
        public async Task<User> Patch(int id, [FromBody]string value)
        {
            return await _clientService.PatchAsync(id, value);           
        }

        // DELETE <controller>/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            return await _clientService.DeleteAsync(id);
        }

        #endregion

    }
}
