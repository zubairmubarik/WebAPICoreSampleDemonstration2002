using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        //0. Handler to catch REquest + Exception Handling
        //1. Perform all REST operations with HTTPClientFactory 
        // 2. Nested resources  One level of nested route is available both in Core and Angular
        //    2. Clean Code
        //    3. Auto Mapper
        //    4. Handle Exception
        //    5. Logger
        //    6. Improve code, indention , comments
        //    8. Call 1 more attribute from HTTPClientFactory                  

        //    9. Think about JWT
        //      Write README in details


        //    10. Back to Anjular 8
        // Local Storage
        // Workers
        // Ng -interceprtor
        //    11. Complete All remaining attirbutes from this project and Angular 8
        //  Write Reasme in details


        //    12 Think about Azure, JWT
        //                    13 Make a .NET REST API Core project with Azure
        //                    14 Make Microservices with Node
        //                    15Fix old projects
        //                    16, Clean Projects,and Slides,put on GitHub 
        //                    17 Prepare for interviews
        // Learn Async + Wait from Videos
        // OAuth and Auth0 

        // Microservciees with nodejs

        IAsyncService<User> _clientService;
        public ClientController(IAsyncService<User> clientService)
        {
            _clientService = clientService;
        }
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

    }
}
