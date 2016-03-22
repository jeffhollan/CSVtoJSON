using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSVtoJSON.Models
{
    public class JsonResult
    {
        public JsonResult()
        {
            rows = new List<Sale>();
        }
        public List<Sale> rows { get; set; }

        public class Sale
        {
            public DateTime Transaction_date { get; set; }
            public string Product { get; set; }
            public int Price { get; set; }
            public string Payment_Type { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public DateTime Account_Created { get; set; }
            public DateTime Last_Login { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }

        }
    }
}