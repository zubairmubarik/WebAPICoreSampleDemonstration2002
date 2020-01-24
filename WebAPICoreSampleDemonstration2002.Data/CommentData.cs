using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICoreSampleDemonstration2002.Data
{
    public class CommentData
    {
        //public int id { get; set; }
        //public string post { get; set; }
        //public User user { get; set; }
        //public Comment comment { get; set; }

        public int id { get; set; }
        public int postId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }


    }
}
