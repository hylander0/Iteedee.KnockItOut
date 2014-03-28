using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iteedee.KnockoutResuableViews.Controllers
{
    public class WidgetController : Controller
    {
        private Models.LatestUpdatesModel _Updates = new Models.LatestUpdatesModel()
                {
                    Updates = new List<string>() { "+10 points for your latest post " ,"Happy New Year", "Your account has been updated."}
                };
        public ActionResult UserStats()
        {
            return PartialView(new Models.UserStatsModel() { 
                ConsecutiveDaysVisited = "23",
                UserScore = "+323",
                VisitCount = "5282"
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateUserStats()
        {
            Random rdm = new Random();
            return Json(new Models.UserStatsModel()
            {
                ConsecutiveDaysVisited =  rdm.Next(0,200).ToString(),
                UserScore = string.Format("+{0}", rdm.Next(0,5000).ToString()),
                VisitCount = rdm.Next(0, 50000).ToString()
            });
        }

        public ActionResult LatestUpdates()
        {
            return PartialView(_Updates);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult PostUpdate(string update)
        {
            _Updates.Updates.Add(update);
            return Json(_Updates);
        }

        public ActionResult Weather()
        {
            return PartialView(new Models.WeatherModel()
                {
                    Conditions = "Cloudy",
                    CurrentLocation = "Cleveland, Ohio",
                    Temp = "23 Degrees"
                });
        }
	}
}