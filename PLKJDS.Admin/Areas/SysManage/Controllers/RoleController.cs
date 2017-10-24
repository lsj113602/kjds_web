using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.BLL;
using PLKJDS.Entity;
using PLKJDS.Common;
namespace PLKJDS.Admin.Areas.SysManage.Controllers
{
    public class RoleController : ControllerBase
    {
        RoleApp roleApp = new RoleApp();
        AccountTypeApp accountTypeApp = new AccountTypeApp();
        public override ActionResult Index()
        {
            return View();
        }

        public override ActionResult Form()
        {
            return View();
        }
        public override ActionResult Details()
        {
            return View();
        }
        public ActionResult GetGridJson(string keyword,Pagination pagination)
        {
            var data = roleApp.GetList(keyword, pagination);
            var accountTypeList = accountTypeApp.GetAccountTypeList();
            foreach (var item in data)
            {
                var temp = accountTypeList.Find(x => x.ID == item.AccountTypeID);
                if (temp != null)
                {
                    item.AccountTypeID = temp.TypeName;
                }
            }
            return Content(data.ToJson());
        }
        public ActionResult GetFormJson(string keyValue)
        {
            var entity = roleApp.GetForm(keyValue);
            return Content(entity.ToJson());
        }
        public ActionResult AddRole(Role role,string permissionIds)
        {
            var ret = roleApp.AddRole(role, permissionIds.Split(','));
            if (ret > 0)
            {
                return Success("添加成功");
            }
            return Error("添加失败");
        }

        public ActionResult ModifyRole(Role role, string permissionIds, string keyValue)
        {
            var ret = roleApp.ModifyRole(role, permissionIds.Split(','),keyValue);
            if (ret > 0)
            {
                return Success("修改成功");
            }
            return Error("修改失败");
        }
        public ActionResult DeleteRole(string keyValue)
        {
            var ret = roleApp.DeleteRole(keyValue);
            if (ret > 0)
            {
                return Success("删除成功");
            }
            return Error("删除失败");
        }
        public ActionResult GetTreeSelectJson()
        {
            var data = roleApp.GetList();
            return Content(data.ToJson());
        }
    }
}