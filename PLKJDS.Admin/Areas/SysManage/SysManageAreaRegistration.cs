using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Areas.SysManage
{
    public class SysManageAreaRegistration: AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SysManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              AreaName + "_Default",
              AreaName + "/{controller}/{action}/{id}",
              new { area = AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "PLKJDS.Admin.Areas." + AreaName + ".Controllers" }
            );
        }
    }
}