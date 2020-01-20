﻿
namespace WebAPICoreSampleDemonstration2002.Data
{
    public class User
    {
        public int id { get; set; }     
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }

        public Address address { get; set; }
        public Company company { get; set; }

    }
}
