using PLKJDS.Common;
using PLKJDS.UIBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.UI.Controllers
{
    [HandlerLogin]
    public class UserInfoController : ControllerBase
    {
        //
        // GET: /UserCenter/
        public override ActionResult Index()
        {
            //name，stuNo， school， pastern，sex，birthday，phone，email，（province，city，area）,logo
            //ViewBag.UserInfo = new { };
            var userId = OperatorProvider.Provider.GetCurrent().UserId;
            ViewBag.UserInfo = Newtonsoft.Json.JsonConvert.SerializeObject( new UserInfoApp().Get(userId));
            return View();
        }

        public ActionResult ModifyUserInfo(ModifyUserInfoParam param)
        {
            //pastern,sex,birthday,phone,email,province,city,area
            param.id = OperatorProvider.Provider.GetCurrent().UserId;
            var isOk = new UserInfoApp().ModifyUserInfo(param);
            if (isOk)
            {
                return Success(null);
            }
            else
            {
                return Error(null);
            }
        }
        public ActionResult ModifyUserLogo(ModifyUserLogoParam param)
        {
            param.id = OperatorProvider.Provider.GetCurrent().UserId;
            var isOk = new UserInfoApp().ModifyUserLogo(param);
            if (isOk)
            {
                return Success(null);
            }
            else
            {
                return Error(null);
            }
        }
        public ActionResult ModifyUserPwd(ModifyUserPwdParam param) 
        {
            param.id = OperatorProvider.Provider.GetCurrent().UserId;
            string msg = null;
            var isOk = new UserInfoApp().ModifyUserPwd(param, out msg);
            if (isOk)
            {
                return Success(msg);
            }
            else
            {
                return Error(msg);
            }
        }
	}
}