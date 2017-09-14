using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2
{
    public class VirtualDomAttribute : FilterAttribute, IResultFilter
    {
        StringWriter textWriter;
        TextWriter originalWriter; 
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            originalWriter = filterContext.HttpContext.Response.Output;
            textWriter = new StringWriter(CultureInfo.InvariantCulture);
            filterContext.HttpContext.Response.Output = textWriter;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var capturedText = textWriter.ToString();

            var doc = new HtmlDocument();
            doc.LoadHtml(capturedText);

            filterContext.HttpContext.Response.Output = originalWriter;
            filterContext.HttpContext.Response.Write(capturedText);
        }

    }
}