using PLKJDS.BLL;
using PLKJDS.Common;
using PLKJDS.Common.Enums;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Areas.SchoolManage.Controllers
{
    public class UserController : ControllerBase
    {
        //private string OrgID = OperatorProvider.Provider.GetCurrent().CompanyId;
        private string OrgID = "5409875a-43bf-4767-9f14-cec777fcdce4";
        // GET: SchoolManage/User
        UserApp userApp = new UserApp();
        UserDataApp userDataApp = new UserDataApp();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = userApp.GetList(pagination, keyword, this.OrgID),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        public ActionResult GetFormJson(string keyValue)
        {
            var data = userApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        public ActionResult AddUser(User user)
        {
            user.AgreeCode = UserAgreeCode.Agree.GetEnumCode();
            user.AgreeTime = DateTime.Now;
            user.AgreeUserID = user.CreatorUserId;
            user.SecretKey = Md5.md5(CommonUtility.CreateNo(), 16).ToLower();
            user.Passsword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(user.Passsword, 32).ToLower(), user.SecretKey).ToLower(), 32).ToLower();
            user.OrgID = this.OrgID;
            var ret = userApp.AddUser(user);
            if (ret == 1)
            {
                return Success("添加成功。");
            }
            else
            {
                return Error("添加失败");
            }
        }

        public ActionResult ModifyUser(User user, string keyValue)
        {
            user.OrgID = this.OrgID;
            var ret = userApp.ModifyUser(user, keyValue);
            if (ret == 1)
            {
                return Success("修改成功。");
            }
            else
            {
                return Error("修改失败");
            }
        }

        public ActionResult DeleteForm(string keyValue)
        {

            var ret = userApp.DeleteUser(keyValue);
            if (ret == 1)
            {
                return Success("删除成功。");
            }
            else
            {
                return Error("删除失败");
            }
        }

        public ActionResult RevisePassword()
        {
            return View();
        }

        public ActionResult SubmitRevisePassword(string userPassword, string keyValue)
        {
            var ret = userApp.RevisePassword(userPassword, keyValue);
            if (ret == 1)
            {
                return Success("重置密码成功。");
            }
            else
            {
                return Error("重置密码失败");
            }
        }

        public ActionResult DisabledAccount(string keyValue)
        {
            User user = new User();
            user.IsLogin = false;
            var ret = userApp.ModifyUser(user, keyValue);
            if (ret == 1)
            {
                return Success("账户禁用成功。");
            }
            return Error("账户禁用失败。");
        }

        public ActionResult EnabledAccount(string keyValue)
        {
            User user = new User();
            user.IsLogin = true;
            var ret = userApp.ModifyUser(user, keyValue);
            if (ret == 1)
            {
                return Success("账户启用成功。");
            }
            return Error("账户启用失败。");
            
        }
        public ActionResult GetUserApprove(string keyValue)
        {
            var user = userApp.GetForm(keyValue);
            var userData = userDataApp.GetUserDataList(keyValue);
            //string fileService = Configs.GetValue("FileService");
            //foreach (var item in userData)
            //{
            //    item.FileID = fileService + item.FileID;
            //}
            var data = new {
                user = user,
                userData = userData
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }

        public ActionResult Approve()
        {
            return View();
        }


        public ActionResult UserApprove(string keyValue, string typeID)
        {
            var ret = userApp.Approve(keyValue, typeID);
            if (ret == 1)
            {
                return Success("操作成功。");
            }
            return Error("操作失败。");
        }

        #region 检测用户名是否已被注册
        public ActionResult IsExsitUser(string username)
        {
            var result = userApp.CheckUserName(username);
            if (result)
            {
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = "该用户名已存在" }.ToJson());
            }
            else
            {
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "success" }.ToJson());
            }
        }
        #endregion
    }
}

