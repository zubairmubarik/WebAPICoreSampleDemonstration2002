using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using WebAPICoreSampleDemonstration2002.BusinessService.Interfaces;
using WebAPICoreSampleDemonstration2002.Data;
using WebAPICoreSampleDemonstration2002.BusinessService.Extensions;

namespace WebAPICoreSampleDemonstration2002.BusinessService
{
    public class CommentService : IService<CommentData>
    {
        public CommentService()
        {

        }
        public CommentData Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CommentData> Get()
        {
            throw new NotImplementedException();
        }

        public CommentData Patch(int id, CommentData item)
        {
            throw new NotImplementedException();
        }

        public int Post(CommentData item)
        {
            throw new NotImplementedException();
        }

        public CommentData Put(int id, CommentData item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
