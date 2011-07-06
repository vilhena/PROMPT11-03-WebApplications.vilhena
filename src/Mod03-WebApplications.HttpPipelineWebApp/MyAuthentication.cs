using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp
{
    public static class MyAuthentication
    {
        public static void Logoff()
        {
            if (HttpContext.Current.Response.Cookies["myauthentication"] != null)
                HttpContext.Current.Response.Cookies["myauthentication"].Expires = DateTime.Now.AddYears(-1);

            HttpContext.Current.Response.Redirect("~/Login.html");
        }

        public static void AuthenticateUser(string username, string[] roles, bool rememberMe = false)
        {
            var authCookie = new HttpCookie("myauthentication");

            authCookie["user"] = username;
            if (rememberMe)
            {
                authCookie.Expires = DateTime.Now.AddMonths(1);
            }

            HttpContext.Current.Response.AppendCookie(authCookie);

        }

        public static IPrincipal GetCurrentUser()
        {
            if (HttpContext.Current.Request.Cookies["myauthentication"] != null)
            {
                var cookie = HttpContext.Current.Request.Cookies["myauthentication"];

                if (cookie != null && cookie["user"] != null)
                {
                    return new GenericPrincipal(new GenericIdentity(cookie["user"]), null);
                }
            }
            return null;
        }

        public static string LoginURL{
            get
            {
                return "~/Login.html?to=" +
                       HttpContext.Current.Request.Url.AbsolutePath;
            }
        }

        public static string LoginURLRedirect
        {
            get
            {
                if(HttpContext.Current.Request.QueryString["to"]!= null)
                    return HttpContext.Current.Request.QueryString["to"];
                else
                {
                    return HttpContext.Current.Request.ApplicationPath;
                }
            }
        }

    }
}