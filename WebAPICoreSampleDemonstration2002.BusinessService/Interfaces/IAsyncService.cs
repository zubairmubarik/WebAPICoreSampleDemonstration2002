using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPICoreSampleDemonstration2002.Data;

namespace WebAPICoreSampleDemonstration2002.BusinessService.Interfaces
{
    public interface IAsyncService<T>
    {
        Task<IEnumerable<User>> GetAsync();
        Task<string> GetAsync(int id);
        Task<string> PostAsync(T value);

        Task<HttpResponseMessage> PutAsync();

        Task<HttpResponseMessage> PatchAsync();

        Task<HttpResponseMessage> DeleteAsync();


    }
}
