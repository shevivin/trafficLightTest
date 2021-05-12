using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace lights.Controllers
{
    public class TrafficLightsController : Controller
    {     
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult lights(LightsRequest request)
        {
            if (string.IsNullOrEmpty(request.color) || request.color=="yellow")
            {
                var isGetValue = TrafficLine.TryGetValue("red", out trafficModel value);
                return Json(value, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var s  = TrafficLine.SkipWhile(x => x.Key !=
            request.color).Skip(1).FirstOrDefault().Value;

                return Json(s, JsonRequestBehavior.AllowGet);
            }


        }

        public Dictionary<string, trafficModel> TrafficLine = new Dictionary<string, trafficModel>()
        {
             {"red",new trafficModel(new List<string>{"red" },3 ) } ,
             {"red,yellow",new trafficModel(new List<string>{"red","yellow" },1.5 ) } ,
             {"green",new trafficModel(new List<string>{"green" },3 ) } ,
             {"yellow",new trafficModel(new List<string>{"yellow" },1.5) }
           
            };

        public class LightsRequest
        {
            public string color { get; set; }
        }
       
    }
}