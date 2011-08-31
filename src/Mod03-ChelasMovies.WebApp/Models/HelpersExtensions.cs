using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

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

        public static MvcHtmlString EnumDropdownList<T>(this HtmlHelper htmlHelper, string name, T enumerate, object selectedValue)
            where T : struct
        {
            var TType = typeof (T);

            if (!TType.IsEnum)
                throw new InvalidOperationException("Invalid Enumerator Type");

           
            var enumList = new List<SelectListItem>();
            
            for (int i = 0; i < TType.GetEnumNames().Count(); i++)
            {
                var option = new SelectListItem
                                 {
                                     Value = ((int) TType.GetEnumValues().GetValue(i)).ToString(),
                                     Text = TType.GetEnumNames()[i],
                                     Selected = (TType.GetEnumValues().GetValue(i).Equals(selectedValue))
                                 };

                enumList.Add(option);
            }

            return htmlHelper.DropDownList("Rating", enumList, selectedValue.ToString());
        }
    }

    
}