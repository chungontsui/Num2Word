using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Num2Word.Service;

namespace Num2Word.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }

    public class ValueController: ApiController
    {
        private CoreService cs;

        public ValueController()
        {
            cs = new CoreService();
        }

        [System.Web.Mvc.HttpGet, System.Web.Mvc.Route("api/Value/{number}")]
        public string Get(double number)
        {
            return cs.Convert(number);
        }
    }
}