﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPICoreSampleDemonstration2002.Data;

namespace WebAPICoreSampleDemonstration2002.BusinessService.Interfaces
{
    public interface IAsyncService<T>
    {        
        Task<IEnumerable<T>> GetAsync();
        Task<string> GetAsync(int id);
        Task<string> PostAsync(T value);
        Task<string> PutAsync(int id, T value);
        Task<T> PatchAsync(int id, string payload);
        Task<HttpResponseMessage> DeleteAsync(int id);
    }
}
