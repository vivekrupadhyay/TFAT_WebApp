using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFATERPWebApplication.Core;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.DynamicBusinessLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TFATERPWebApplication.Models;
using System.Text;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;

namespace TFATERPWebApplication.DynamicBusinessLayer
{
    public class ReportCenterOperation : IReportCenterOperation
    {
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();

        public ActionResult XGetReportCntMenuStructure()
        {
            var RptCenterMenu = ctx.ReportGroups.Where(c => c.Level == 0).OrderBy(c => c.Code).Select(c => new { c.Code, c.Descr, c.Grp, c.Level }).ToList();
            List<Menu> mMnuRptCntr = new List<Menu>(); //
            foreach (var mnuPrnt in RptCenterMenu)
            {
                Menu mCntMnu = new Menu();
                mCntMnu.id = mnuPrnt.Grp;
                mCntMnu.label = mnuPrnt.Code;
                mMnuRptCntr.Add(mCntMnu);
                AddChild(mnuPrnt.Code, mCntMnu, mnuPrnt.Level + 1);
            }

            JsonResult JRs = new JsonResult() { Data = Newtonsoft.Json.JsonConvert.SerializeObject(mMnuRptCntr) };
            return JRs;
        }

        private void AddChild(string procode, Menu MainMenu, int mLevel)
        {
            var mChildData = ctx.ReportGroups.Where(r => r.Grp == procode && r.Level == mLevel).OrderBy(c => c.Code).Select(c => new { c.Code, c.Descr, c.Grp, c.Level });
            var ChildData = mChildData.ToList();
            List<Menu> ChildMenu = new List<Menu>();
            if (ChildData.Count() > 0)
            {
                foreach (var mChild in ChildData)
                {
                    Menu SubMenu = new Menu();
                    SubMenu.id = mChild.Grp;
                    SubMenu.label = mChild.Code;
                    AddChild(mChild.Code, SubMenu, mChild.Level + 1);
                    ChildMenu.Add(SubMenu);
                }
            }
            MainMenu.children = ChildMenu;
        }
    }
}