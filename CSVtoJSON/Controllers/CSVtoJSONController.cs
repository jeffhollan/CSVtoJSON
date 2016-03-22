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
using CSVtoJSON.Models;

namespace CSVtoJSON.Controllers
{
    public class CSVtoJSONController : ApiController
    {
        /// <summary>
        /// Convert CSV to JSON where the first row is headers
        /// </summary>
        /// <param name="body">CSV file to convert to JSON</param>
        /// <returns>JSON Result - the JArray of Objects generated from each row</returns>
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.OK, Type = typeof(JsonResult))]
        [Metadata("CSV to JSON with header row", "Convert CSV to JSON")]
        public HttpResponseMessage Post([FromBody] string body)
        {
            JsonResult resultSet = new JsonResult();
            string[] csvLines = body.Split('\r');
            var headers = csvLines[0].Split(',').ToList<string>();
            foreach(var line in csvLines.Skip(1))
            {
                var lineObject = new JObject();
                var lineAttr = line.Split(',');
                for(int x = 0; x < headers.Count; x++)
                {
                    lineObject[headers[x]] = lineAttr[x];
                }
                resultSet.rows.Add(lineObject);
            }

            return Request.CreateResponse<JsonResult>(resultSet);
        }

    }
}
