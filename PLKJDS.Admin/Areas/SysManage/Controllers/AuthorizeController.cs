using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.Common;
using PLKJDS.BLL;
using PLKJDS.Entity;
using PLKJDS.Common.Enums;

namespace PLKJDS.Admin.Areas.SysManage.Controllers
{
    public class AuthorizeController : ControllerBase
    {
        private AuthorizeApp authorizeApp = new AuthorizeApp();
        private AccountTypeApp accountTypeApp = new AccountTypeApp();
        // GET: SysManage/Authorize
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
        /// <summary>
        /// Index 列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ActionResult GetTreeGridJson(Pagination pagination,string keyword)
        {
            var list = authorizeApp.GetAuthorizeList();
            var acountTypeList = accountTypeApp.GetAccountTypeList();
            foreach (var item in list)
            {
                var temp = acountTypeList.Find(x => x.ID == item.AccountTypeID);
                if (temp != null)
                {
                    item.AccountTypeID = temp.TypeName;
                }
            }
            var treeList = new List<TreeGridModel>();
            foreach (var item in list)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = list.Count(t => t.PID == item.ID) == 0 ? false : true;
                treeModel.id = item.ID;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.PID;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }
        /// <summary>
        /// Form 父节点
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTreeSelectJson(string accountTypeID)
        {
            var list = authorizeApp.GetAuthorizeByPid("0", accountTypeID);
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            foreach (var auth in list)
            {
                TreeSelectModel tree = new TreeSelectModel();
                tree.id = auth.ID;
                tree.text = auth.AuthorizeName;
                treeList.Add(tree);
            }
            return Content(treeList.ToJson());
        }
        public ActionResult AddAuthorize(Authorize authorize)
        {
            authorize.AuthorizeType = AuthorizeType.Menu.GetEnumCode();
            var ret = authorizeApp.AddAuthorize(authorize);
            if (ret == 1)
            {
                return Success("添加权限成功");
            }
            return Error("添加权限失败");
        }
        public ActionResult ModifyAuthorize(Authorize authorize,string keyvalue)
        {
            var ret = authorizeApp.ModifyAuthorize(authorize,keyvalue);
            if (ret == 1)
            {
                return Success("修改权限成功");
            }
            return Error("修改权限失败");
        }
        public ActionResult DeleteAuthorize(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                return Error("删除权限失败");
            }
            Authorize authorize = new Authorize() { ID = keyValue};
            var ret = authorizeApp.DeleteAuthorize(authorize);
            if (ret == 1)
            {
                return Success("删除权限成功");
            }
            return Error("删除权限失败");
        }

        public ActionResult GetFormJson(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                return Error("获取失败");
            }
            Authorize authorize = new Authorize() { ID = keyValue };
            var entity = authorizeApp.GetForm(authorize);
            return Content(entity.ToJson());
        }
    }
}