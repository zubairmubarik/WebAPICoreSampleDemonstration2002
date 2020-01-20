using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICoreSampleDemonstration2002.BusinessService.Interfaces
{
    public interface IService <T>
    {
        T Get(int id);
        IList<T> GetAsync();
        int Post(T item);
        T Put(T item, int id);
        bool Remove(int id);

    }
}
