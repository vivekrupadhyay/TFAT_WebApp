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

namespace TFATERPWebApplication.DynamicBusinessLayer
{
    public class DynamicMenu
    {
        private static TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();

        public static ActionResult XGetMenu(string mProjectID)
        {
            
            var mMainParentDt = ctx.TfatMenus.Where(m => m.ProjectCode == mProjectID && m.MenuParent == " ").OrderBy(m => m.Display).Select(m => new { m.Descr, m.MenuID, m.MenuParent, m.IsLast }).ToList();

            List<Menu> Menu = new List<Menu>();
            foreach (var mnu in mMainParentDt)
            {
                Menu MainMenu = new Menu();
                MainMenu.label = mnu.Descr;
                MainMenu.id = mnu.MenuID;
                AddChild(mProjectID, MainMenu);
                Menu.Add(MainMenu);
            }
            JsonResult JR = new JsonResult() { Data = Newtonsoft.Json.JsonConvert.SerializeObject(Menu) };
            return JR;
        }

        //Add Child of Main Menu

        private static void AddChild(string procode, Menu MainMenu)
        {
            var mChildData = ctx.TfatMenus.Where(c => c.ProjectCode == procode && c.MenuParent == MainMenu.id && c.MenuParent != " ").OrderBy(c => c.Display).Select(c => new { c.ProjectCode, c.Descr, c.Display, c.MenuID, c.MenuParent, c.FormName, c.Depth, c.IsReport, c.IsLast, c.OptionType, c.OptionMode, c.HotKey });
            var ChildData = mChildData.ToList();
            List<Menu> ChildMenu = new List<Menu>();
            if (ChildData.Count() > 0)
            {
                foreach (var mChild in ChildData)
                {
                    Menu SubMenu = new Menu();
                    SubMenu.id = mChild.MenuID;
                    if (mChild.IsLast == true)
                    {
                        SubMenu.label = "<a href='/ViewList/Index/" + mChild.MenuID + "'>" + mChild.Descr + "</a>";
                    }
                    else
                    {
                        SubMenu.label = mChild.Descr;
                        AddChild(procode, SubMenu);
                    }
                    ChildMenu.Add(SubMenu);
                }
            }
            MainMenu.children = ChildMenu;
        }
    }
}