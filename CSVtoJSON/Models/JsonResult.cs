using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSVtoJSON.Models
{
    public class JsonResult
    {
        public List<object> rows { get; set; }
    }
}