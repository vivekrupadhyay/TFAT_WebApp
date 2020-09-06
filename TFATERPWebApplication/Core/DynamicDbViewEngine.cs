using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TFATERPWebApplication.Core
{
    /// <summary>
    /// Use to generate Data Driven View. IViewEngine interface inhereted for to develop our View from Database 
    /// </summary>
    public class DynamicDbViewEngine : IViewEngine
    {
        /// <summary>
        /// Using FindPartialView method Data Driven View Engine generate Partial View from Database.
        /// </summary>
        /// <param name="cc"></param>
        /// <param name="partialview"></param>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public ViewEngineResult FindPartialView(ControllerContext cc, string partialview, bool useCache)
        {
            if (cc.RouteData.Values.ContainsValue("Dynamic") && cc.RouteData.Values.ContainsValue("Master"))
            {
                return new ViewEngineResult(new DynamicDbView(partialview), this);
            }
            else
            {
                return new ViewEngineResult(new string[] { "No Suitable view found for 'DynamicDbViewEngine', please ensure View Name contains 'Dynamic'" });
            }
        }

        /// <summary>
        /// Using FindView method Data Driven View Engine generate View from Database.
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="viewName"></param>
        /// <param name="masterName"></param>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (controllerContext.RouteData.Values.ContainsValue("Dynamic") && controllerContext.RouteData.Values.ContainsValue("Master"))
            {
                return new ViewEngineResult(new DynamicDbView(viewName), this);
            }
            else
            {
                return new ViewEngineResult(new string[] 
                { @"No Suitable view found for 'DynamicDbViewEngine', 
                please ensure View Name contains 'Dynamic'" });
            }
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {

        }
    }
}