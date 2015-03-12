using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace AdopteUneDev.Helper
{
    public static class CustHelper
    {
        
        public static MvcHtmlString BoldTitle(this HtmlHelper Origin, string texte, string laclasse)
        {
            TagBuilder ta = new TagBuilder("h1");
            ta.InnerHtml = "<b>"+texte.ToUpper()+"</b>";
            ta.AddCssClass(laclasse);

            return new MvcHtmlString(ta.ToString());
        }
    }
}
