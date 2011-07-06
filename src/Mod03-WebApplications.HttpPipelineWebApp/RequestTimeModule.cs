using System;
using System.Collections.Generic;
using System.Web;

namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp
{
    class RequestTimeModule: IHttpModule
    {

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Context_BeginRequest);
            context.PostRequestHandlerExecute +=new EventHandler(Context_PostRequestHandlerExecute);
        }

        void Context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items.Add("start", DateTime.Now);
        }

        void Context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null)
            {
                var start = (DateTime)HttpContext.Current.Items["start"];

                if (HttpContext.Current.Session["RequestTimes"] == null)
                    HttpContext.Current.Session.Add("RequestTimes", new Dictionary<Uri, List<TimeSpan>>());

                var spans = 
                    (Dictionary<Uri, List<TimeSpan>>)HttpContext.Current.Session["RequestTimes"];

                if (!spans.ContainsKey(HttpContext.Current.Request.Url))
                    spans.Add(HttpContext.Current.Request.Url, new List<TimeSpan>());

                spans[HttpContext.Current.Request.Url].Add(DateTime.Now.Subtract(start));
            }
        }

        public void Dispose()
        {
        }

    }
}
