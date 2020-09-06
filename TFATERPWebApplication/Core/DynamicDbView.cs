using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.Core
{
    /// <summary>
    /// Use to generate Data Driven View. IView interface inhereted for to develop our View from Database 
    /// </summary>
    public class DynamicDbView : IView
    {
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();

        /// <summary>
        /// Get,Set ID from DynamicDbView Constructer & use in DynamicDbView class
        /// </summary>
        private string ID { get; set; }

        /// <summary>
        /// Get,Set Layout Name for View so using that inherate _Layout View to our Data Driven View.
        /// </summary>
        private string Layout { get; set; }


        public DynamicDbView(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", new ArgumentException("id cannot be match/null"));
            }
            this.ID = id;
        }

        public DynamicDbView(string id, string layout)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", new ArgumentException("id cannot be match/null"));
            }
            if (string.IsNullOrEmpty(layout))
            {
                throw new ArgumentNullException("layout", new ArgumentException("layput cannot be match/null"));
            }
            this.ID = id;
            this.Layout = layout;
        }


        /// <summary>
        /// Using Render method Data Driven View Engine generate our View from Database.
        /// In Controller last optional parameter is use here to generate view. 
        /// e.g. If your URL like "/Dynamic/Master/City/City/Add" then using "Add" View generate.
        /// </summary>
        /// <param name="vc"></param>
        /// <param name="tw"></param>
        public void Render(ViewContext vc, TextWriter tw)
        {
            string[] url = vc.HttpContext.Request.Path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.OptionCode == this.ID);
            string content = string.Empty;
            string[] Tables = DHead.TableName.Split(new char[] { '^' });
            switch (url.Last().ToUpper())
            {
                case "LIST":
                    content = BuildView.DetailView(DHead);
                    break;
                case "ADD":
                    content = BuildView.GenerateView(DHead, viewType: "ADD");
                    break;
                case "EDIT":
                    content = BuildView.GenerateView(DHead, Tables.FirstOrDefault(), Convert.ToInt32(vc.HttpContext.Request.QueryString.GetValues("id").LastOrDefault()), "EDIT");
                    break;
                case "DELETE":
                    content = BuildView.GenerateView(DHead, Tables.FirstOrDefault(), Convert.ToInt32(vc.HttpContext.Request.QueryString.GetValues("id").LastOrDefault()), "DELETE");
                    break;
                case "GRID":
                    content = BuildView.GridView(DHead);
                    break;
                default:
                    content = "Page under construction";
                    break;
            }

            tw.Write(content);
        }
    }
}