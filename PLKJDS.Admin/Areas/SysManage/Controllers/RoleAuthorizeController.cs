using PLKJDS.BLL;
using PLKJDS.Common;
using PLKJDS.Common.Enums;
using PLKJDS.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
namespace PLKJDS.Admin.Areas.SysManage.Controllers
{
    public class RoleAuthorizeController : ControllerBase
    {
        private RoleAuthorizeApp roleAuthorizeApp = new RoleAuthorizeApp();
        private AuthorizeApp authorizeApp = new AuthorizeApp();
        private AuthorizeButtonApp authorizeButtonApp = new AuthorizeButtonApp();
        public ActionResult GetPermissionTree(string roleId,string accountTypeID)
        {
            var authorizedata = authorizeApp.GetAuthorizeList(AuthorizeType.Menu.GetEnumCode(), accountTypeID);
            var buttondata = authorizeButtonApp.GetButtonListByAuthList(authorizedata);
            var roleAuthorize = new List<RoleAuthorize>();
            if (!string.IsNullOrEmpty(roleId))
            {
                roleAuthorize = roleAuthorizeApp.GetList(roleId,"1");
            }
            var treeList = new List<TreeViewModel>();
            foreach (Authorize item in authorizedata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = authorizedata.Count(t => t.PID == item.ID) == 0 ? false : true;
                tree.id = item.ID;
                tree.text = item.AuthorizeName;
                tree.value = item.EnCode;
                tree.parentId = item.PID;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = roleAuthorize.Count(t => t.AuthorizeID == item.ID);
                tree.hasChildren = true;
                tree.img = item.Icon == "" ? "" : item.Icon;
                treeList.Add(tree);
            }
            foreach (Authorize item in buttondata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = buttondata.Count(t => t.PID == item.ID) == 0 ? false : true;
                tree.id = item.ID;
                tree.text = item.AuthorizeName;
                tree.value = item.EnCode;
                tree.parentId = item.PID;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = roleAuthorize.Count(t => t.AuthorizeID == item.ID);
                tree.hasChildren = hasChildren;
                tree.img = item.Icon == "" ? "" : item.Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
    }
}