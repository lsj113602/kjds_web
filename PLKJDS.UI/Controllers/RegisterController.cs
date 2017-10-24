using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.UIBLL;
using PLKJDS.Common;
using PLKJDS.UIEntity.UI;


namespace  PLKJDS.UI
{
    public class RegisterController : ControllerBase
    {
        AccountApp accountApp = new AccountApp();
        // GET: Account/Register
        public override ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSchoolList()
        {
            var orgList = accountApp.GetSchoolList();
            var orgSelectList = new List<TreeSelectModel>();
            foreach (var org in orgList)
            {
                TreeSelectModel tree = new TreeSelectModel();
                tree.id = org.ID;
                tree.text = org.OrgName;
                orgSelectList.Add(tree);
            }
            return Content(orgSelectList.ToJson());
        }


        public ActionResult RegsiterUser(RegisterModel register)
        {
            var ret = accountApp.AddUser(register);
            if (ret == 1)
            {
                return Success("注册成功");
            }
            return Error("注册失败");
        }

        #region 检测用户名是否已被注册
        public ActionResult IsExsitUser(string username)
        {
            var result = accountApp.CheckUserName(username);
            if (result)
            {
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = "该用户名已被注册" }.ToJson());
            }
            else
            {
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "success" }.ToJson());
            }
        }
        #endregion
    }
}