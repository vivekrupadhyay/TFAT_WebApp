using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TFATERPWebApplication.Core
{

    public sealed class TabPanel : IDisposable
    {
        Boolean _isdisposed;
        ViewContext _viewContext;
        List<Func<Object, Object>> _tabs;
        internal TabPanel(ViewContext viewContext)
        {
            _viewContext = viewContext;
            _viewContext.Writer.Write("<div class=\"tabs\"><ul class=\"tabs-head\">");
            _tabs = new List<Func<Object, Object>>();
        }
        public MvcHtmlString NewTab(String name, Func<Object, Object> markup)
        {
            var tab = new TagBuilder("li");
            tab.SetInnerText(name);
            _tabs.Add(markup);
            return MvcHtmlString.Create(tab.ToString(TagRenderMode.Normal));
        }
        public void Dispose()
        {
            if (!_isdisposed)
            {
                _isdisposed = true;
                _viewContext.Writer.Write("</ul><div class=\"tabs-body\">");

                for (int i = 0; i < _tabs.Count; i++)
                {
                    _viewContext.Writer.Write("<div class=\"tab\">");
                    _viewContext.Writer.Write(_tabs[i].DynamicInvoke(_viewContext));
                    _viewContext.Writer.Write("</div>");
                }
                _viewContext.Writer.Write("</div></div>");
            }
        }
    }
}