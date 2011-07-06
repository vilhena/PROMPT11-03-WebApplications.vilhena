using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp
{
    public class LogoutHandler:IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            MyAuthentication.Logoff();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}