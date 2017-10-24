using System.Web.Mvc;

namespace PLKJDS.Admin.Areas.QuestionsManage
{
    public class QuestionsManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QuestionsManage";
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