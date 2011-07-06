using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp
{
    public partial class TestTime : System.Web.UI.Page
    {
        private class TimesGrid
        {
            public String URL { get; set; }
            public TimeSpan Time { get; set; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RequestTimes"] != null)
            {
                ListTimes.DataSource = ((Dictionary<Uri, List<TimeSpan>>) Session["RequestTimes"])
                    .SelectMany(c => c.Value
                                         .Select(i => new TimesGrid() {URL = c.Key.ToString(), Time = i})).ToList();

                ListTimes.DataBind();
            }
        }
    }
}