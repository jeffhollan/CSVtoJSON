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
            rows = new List<object>();
        }
        public List<object> rows { get; set; }
    }
}