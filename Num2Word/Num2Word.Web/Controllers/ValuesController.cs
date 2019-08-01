using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Num2Word.Services;

namespace Num2Word.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private CoreService cs;

        public ValuesController()
        {
            cs = new CoreService();
        }

        public string Get([FromUri] double number)
        {
            return cs.Convert(number);
        }
    }
}