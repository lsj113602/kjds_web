using PLKJDS.BLL;
using PLKJDS.Common;
using PLKJDS.Common.Enums;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Areas.SysManage.Controllers
{
    public class UserController : ControllerBase
    {
        UserApp userApp = new UserApp();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = userApp.GetList(pagination, keyword),
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

            return Success("账户禁用成功。");
        }

        public ActionResult EnabledAccount(string keyValue)
        {

            return Success("账户启用成功。");
        }

        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }

        public ActionResult FindUserListModel()
        {
            var data = userApp.FindUserListModel();
            return Content(data.ToJson());
        }

    }
}