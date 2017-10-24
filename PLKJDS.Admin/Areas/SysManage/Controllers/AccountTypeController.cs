using PLKJDS.BLL;
using PLKJDS.Common;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Areas.SysManage.Controllers
{
    public class AccountTypeController : ControllerBase
    {
        private AccountTypeApp accountTypeApp = new AccountTypeApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var list = accountTypeApp.GetAccountTypeList(pagination, keyword);
            return Content(list.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
                return Error("获取失败");
            AccountType accountType = new AccountType() { ID = keyValue };
            var ret = accountTypeApp.GetForm(accountType);
            return Content(ret.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult ModifyAccountType(AccountType accountType,string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                return Error("修改失败");
            }
            var ret = accountTypeApp.ModifyAccountType(accountType,keyValue);
            if (ret == 1)
            {
                return Success("修改成功。");
            }
            return Error("修改失败。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult AddAccountType(AccountType accountType)
        {
            if (string.IsNullOrEmpty(accountType.TypeName))
            {
                return Error("添加失败。");
            }
            var ret = accountTypeApp.AddAccountType(accountType);
            if (ret == 1)
            {
                return Success("添加成功。");
            }
            return Error("添加失败。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        //[HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                return Error("删除失败");
            }
            AccountType accountType = new AccountType() { ID = keyValue };
            var ret = accountTypeApp.DeleteAccountType(accountType);
            if (ret == 1)
            {
                return Success("删除成功。");
            }
            return Error("删除失败。");
        }

        public ActionResult GetAccountTypeTreeJson()
        {
            var list = accountTypeApp.GetAccountTypeList();
            List<TreeSelectModel> treelist = new List<TreeSelectModel>();
            foreach (var accountType in list)
            {
                TreeSelectModel tree = new TreeSelectModel();
                tree.id = accountType.ID;
                tree.text = accountType.TypeName;
                treelist.Add(tree);
            }
            return Content(treelist.ToJson());
        }
    }
}