using PLKJDS.BLL;
using PLKJDS.Common;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PLKJDS.Admin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            var test = string.Format("{0:E2}", 1);
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [HttpGet]
        public ActionResult OutLogin()
        {
            //new LogApp().WriteDbLog(new LogEntity
            //{
            //    F_ModuleName = "系统登录",
            //    F_Type = DbLogType.Exit.ToString(),
            //    F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
            //    F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
            //    F_Result = true,
            //    F_Description = "安全退出系统",
            //});
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            try
            {
                User userEntity = new UserApp().CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.ID;
                    operatorModel.UserCode = userEntity.UserName;
                    operatorModel.UserName = userEntity.TrueName;
                    operatorModel.CompanyId = userEntity.OrgID;
                    operatorModel.AccountType = userEntity.AccountTypeID;
                    operatorModel.RoleId = userEntity.RoleID;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());

            }
            catch (Exception ex)
            {
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
