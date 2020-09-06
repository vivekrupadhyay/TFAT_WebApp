using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Core
{
    public class SuchanHttpModule : IHttpModule
    {
        public void Init(HttpApplication Appl)
        {
            Appl.BeginRequest += new System.EventHandler(Context_BeginRequest);
        }

        public void Dispose()
        {
        }

        public void Context_BeginRequest(object sender, System.EventArgs args)
        {
            HttpApplication App = (HttpApplication)sender;
            string path = App.Request.Path;
            string strExt = System.IO.Path.GetExtension(path);
            if (strExt == ".css")
            {
                //Do Something
                HttpContext.Current.Response.Redirect("error.aspx");
            }
            else if (strExt == ".js")
            {
                //Do Something
                HttpContext.Current.Response.Redirect("error.aspx");
            }
            else
            { }
        }
    }
}