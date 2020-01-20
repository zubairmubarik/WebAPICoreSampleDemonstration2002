using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICoreSampleDemonstration2002.Data
{
    public class Address
    {
        public string city { get; set; }
        public GeoCoordinates geo { get; set; }
        public string  street { get; set; }
        public string suite { get; set; }
        public string zipcode { get; set; }     
    }
}
