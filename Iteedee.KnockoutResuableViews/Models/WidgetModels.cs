using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iteedee.KnockoutResuableViews.Models
{
    public class UserStatsModel
    {
        public String VisitCount { get; set; }
        public String ConsecutiveDaysVisited { get; set; }
        public String UserScore { get; set; }

    }

    public class LatestUpdatesModel
    {
        public List<String> Updates { get; set; }

    }

    public class WeatherModel
    {
        public String Temp { get; set; }
        public String Conditions { get; set; }
        public String CurrentLocation { get; set; }

    }
}