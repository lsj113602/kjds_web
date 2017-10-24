using System.Web.Mvc;

namespace PLKJDS.Admin.Areas.EnterpriseManage
{
    public class EnterpriseManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EnterpriseManage";
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