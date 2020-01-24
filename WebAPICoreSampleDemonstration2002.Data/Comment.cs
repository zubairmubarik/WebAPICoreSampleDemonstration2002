using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICoreSampleDemonstration2002.Data
{
    public class Comment
    {     
        public int id { get; set; }
        public string name { get; set; }      
        public string email { get; set; }
        public string body { get; set; }
        public int postId { get; set; }
    }
}
