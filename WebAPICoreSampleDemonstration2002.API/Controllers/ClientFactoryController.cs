using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPICoreSampleDemonstration2002.BusinessService.Interfaces;
using WebAPICoreSampleDemonstration2002.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPICoreSampleDemonstration2002.API.Controllers
{
    [Route("[controller]")]
    public class ClientFactoryController : Controller
    {
        IAsyncService<CommentData> _clientFactoryService;
        ILogger<ClientController> _logger;
        public ClientFactoryController(IAsyncService<CommentData> clientFactoryService, ILogger<ClientController> logger)
        {
            _clientFactoryService = clientFactoryService;
            _logger = logger;
        }
        // GET: <controller>
        [HttpGet]
        public async Task<IEnumerable<CommentData>> Get()
        {
            return await _clientFactoryService.GetAsync();
        }

        // GET <controller>/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return await _clientFactoryService.GetAsync(id);
        }

        // POST <controller>
        [HttpPost]
        public async Task<string> Post([FromBody]CommentData value)
        {
            return await _clientFactoryService.PostAsync(value);
        }

        // PUT <controller>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody]CommentData value)
        {
            return await _clientFactoryService.PutAsync(id, value);
        }

        // DELETE <controller>/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            return await _clientFactoryService.DeleteAsync(id);
        }
    }
}
