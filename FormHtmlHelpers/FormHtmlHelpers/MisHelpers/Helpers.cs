using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormHtmlHelpers.MisHelpers
{
    public static class Helpers
    {

        public static MvcHtmlString HacerTitulo(this HtmlHelper phelper, String titulo)
        {
            String html = "<h1>" + titulo + "</h1>";
            return new MvcHtmlString(html);
        }

    }
}