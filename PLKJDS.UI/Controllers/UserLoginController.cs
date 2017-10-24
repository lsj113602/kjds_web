using PLKJDS.UIEntity.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.UIBLL;
using PLKJDS.Common;


namespace PLKJDS.UI
{
    public class UserLoginController : ControllerBase
    {
        private AccountApp accountApp = new AccountApp();
        public ActionResult CheckUserLogin(LoginModel login)
        {
            //Sys_Log logEntity = new Sys_Log();
            //logEntity.F_ModuleName = "系统登录";
            //logEntity.F_Type = DbLogType.Login.ToString();
            try
            {
                //if (Session["XAF_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower(), 16) != Session["XAF_session_verifycode"].ToString())
                //{
                //    throw new Exception("验证码错误，请重新输入");
                //}

                var user = accountApp.CheckLogin(login);
                if (user != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = user.ID;
                    operatorModel.UserName = user.UserName;
                    operatorModel.CompanyId = user.OrgID;
                    operatorModel.RoleId = user.RoleID;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    //if (user.F_Account == "admin")
                    //{
                    //    operatorModel.IsSystem = true;
                    //}
                    //else
                    //{
                    //    operatorModel.IsSystem = false;
                    //}
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    //logEntity.F_Account = user.F_Account;
                    //logEntity.F_NickName = user.F_RealName;
                    //logEntity.F_Result = true;
                    //logEntity.F_Description = "登录成功";
                    //new Sys_LogBll().WriteDbLog(logEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                //logEntity.F_Account = username;
                //logEntity.F_NickName = username;
                //logEntity.F_Result = false;
                //logEntity.F_Description = "登录失败，" + ex.Message;
                //new Sys_LogBll().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
        public ActionResult Logout()
        {
            OperatorProvider.Provider.RemoveCurrent();
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = "注销成功。" }.ToJson());

        }

       
    }
}