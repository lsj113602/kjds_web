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
    public class AuthorizeButtonController : ControllerBase
    {
        AuthorizeButtonApp authorizeButtonApp = new AuthorizeButtonApp();
        // GET: SysManage/AuthorizeButton
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
        public ActionResult GetTreeGridJson(Pagination pagination,string authorizeID, string keyword)
        {
            var list = authorizeButtonApp.GetAuthorizeButtonList(pagination,authorizeID, keyword);
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
            return Content(treeList.TreeGridJson(authorizeID));
        }
        ///// <summary>
        ///// Form 父节点
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult GetTreeSelectJson(string accountTypeID)
        //{
        //    var list = authorizeButtonApp.GetAuthorizeByPid("0", accountTypeID);
        //    List<TreeSelectModel> treeList = new List<TreeSelectModel>();
        //    foreach (var auth in list)
        //    {
        //        TreeSelectModel tree = new TreeSelectModel();
        //        tree.id = auth.ID;
        //        tree.text = auth.AuthorizeName;
        //        treeList.Add(tree);
        //    }
        //    return Content(treeList.ToJson());
        //}
        public ActionResult AddAuthorizeButton(Authorize authorizeButton)
        {
            authorizeButton.AuthorizeType = AuthorizeType.Button.GetEnumCode();
            authorizeButton.PID = Request.Form["PID"];
            var ret = authorizeButtonApp.AddAuthorizeButton(authorizeButton);
            if (ret == 1)
            {
                return Success("添加权限成功");
            }
            return Error("添加权限失败");
        }
        public ActionResult ModifyAuthorizeButton(Authorize authorizeButton, string keyvalue)
        {
            var ret = authorizeButtonApp.ModifyAuthorizeButton(authorizeButton, keyvalue);
            if (ret == 1)
            {
                return Success("修改权限成功");
            }
            return Error("修改权限失败");
        }
        public ActionResult DeleteAuthorizeButton(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                return Error("删除权限失败");
            }
            Authorize authorizeButton = new Authorize() { ID = keyValue };
            var ret = authorizeButtonApp.DeleteAuthorizeButton(authorizeButton);
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
            var entity = authorizeButtonApp.GetForm(authorize);
            return Content(entity.ToJson());
        }
    }
}