using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Num2Word.Service;

namespace Num2Word.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private CoreService cs;

        public ValuesController()
        {
            cs = new CoreService();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [Route("api/Values/{number}")]
        public string Get(double number)
        {
            return cs.Convert(number);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            var v = value;
        }

        [Route("api/Values/GetNumWord")]
        public string Post([FromBody]double number)
        {
            return cs.Convert(number);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}