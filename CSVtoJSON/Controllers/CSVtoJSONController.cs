using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TRex.Metadata;

namespace CSVtoJSON.Controllers
{
    public class CSVtoJSONController : ApiController
    {
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.OK, Type = typeof(JArray))]
        [Metadata("CSV to JSON", "Convert CSV to JSON")]
        public HttpResponseMessage Post([FromBody] string csv)
        {
            JArray jsonResult = new JArray();
            string[] csvLines = csv.Split('\r');
            var headers = csvLines[0].Split(',').ToList<string>();
            foreach(var line in csvLines.Skip(1))
            {
                var lineObject = new JObject();
                var lineAttr = line.Split(',');
                for(int x = 0; x < headers.Count; x++)
                {
                    lineObject[headers[x]] = lineAttr[x];
                }
                jsonResult.Add(lineObject);
            }

            return Request.CreateResponse<JArray>(jsonResult);
        }

    }
}
