using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp
{
    public class LoginHandler: IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                var user = context.Request.Form["UserName"];
                var pass = context.Request.Form["Password"];

                var remember = context.Request.Form["RememberMe"];

                MyAuthentication.AuthenticateUser(user, null, remember == null ? false : true);
                context.Response.Redirect(MyAuthentication.LoginURLRedirect);
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}