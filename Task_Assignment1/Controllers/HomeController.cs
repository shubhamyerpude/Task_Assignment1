using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Task_Assignment1.Models;
using Task_Assignment1.Workers;

namespace Task_Assignment1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormattedJsonConverter(string nonFormattedJson)
        {
            Formatter formatter = new Formatter();
            List<JsonDataObject> jsonDataObject = formatter.JsonFormatter(nonFormattedJson);
            return Json(JsonConvert.SerializeObject(jsonDataObject));
        }        
    }
}