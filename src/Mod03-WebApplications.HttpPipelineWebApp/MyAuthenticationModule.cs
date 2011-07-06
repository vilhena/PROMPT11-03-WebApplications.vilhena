using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp
{
    public class MyAuthenticationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(Context_Authenticate);
            context.EndRequest += new EventHandler(Context_Redirect);
        }


        void Context_Redirect(object sender, EventArgs e)
        {
            if (HttpContext.Current.Response.StatusCode == 401)
            {
                HttpContext.Current
                    .Response.Redirect(MyAuthentication.LoginURL);

            }
        }

        void Context_Authenticate(object sender, EventArgs e)
        {
            HttpContext.Current.User = MyAuthentication.GetCurrentUser();
        }


        public void Dispose()
        {
        }

    }
}