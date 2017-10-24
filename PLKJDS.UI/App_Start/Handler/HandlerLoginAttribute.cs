using PLKJDS.Common;
using System.Web.Mvc;

namespace PLKJDS.UI
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;
        public HandlerLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }
            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                //WebHelper.WriteCookie("PLKJDS_login_error", "overdue");
                //filterContext.HttpContext.Response.Write("<script>window.location.href = '/Login/Index';</script>");
                var path = "/Home/Index?isLogin=true";
                filterContext.HttpContext.Response.Redirect(path);
                filterContext.Result = new EmptyResult();
            }
        }
    }
}