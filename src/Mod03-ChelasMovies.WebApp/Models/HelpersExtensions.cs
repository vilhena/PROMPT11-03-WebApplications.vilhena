using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mod03_ChelasMovies.WebApp.Models
{
    public static class HelpersExtensions
    {
        public static MvcHtmlString ImageLink(this HtmlHelper htmlHelper, string imgSrc, string alt)
        {
            var imageBuild = new TagBuilder("img");
            imageBuild.MergeAttribute("src", imgSrc);
            imageBuild.MergeAttribute("alt", alt);
            return MvcHtmlString.Create(imageBuild.ToString());
        }
    }
}