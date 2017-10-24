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
    public class OrganizeController : ControllerBase
    {
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

        private OrganizeApp organizeApp = new OrganizeApp();
        private AccountTypeApp accountTypeApp = new AccountTypeApp();

        public ActionResult GetTreeGridJson(Pagination pagination, string keyword)
        {
            var data = organizeApp.GetList(pagination, keyword);
            var accList = accountTypeApp.GetAccountTypeList();
            var orgList = EnumExt.GetEnumList<OrgProp>();
            foreach (var item in data)
            {
                var temp = accList.Find(x => x.ID == item.OrgType);
                if (temp != null)
                {
                    item.OrgType = temp.TypeName;
                }
                var temp2 = orgList.Find(x => x.id == item.OrgProp);
                if (temp2 != null)
                {
                    item.OrgProp = temp2.text;
                }
            }

            return Content(data.ToJson());
        }

        public ActionResult AddOrganize(Organize org)
        {
            var ret = organizeApp.AddOrganize(org);
            if (ret == 1)
            {
                return Success("添加机构成功");
            }
            else
            {
                return Error("添加机构失败");
            }
        }

        public ActionResult ModifyOrganize(Organize org, string keyValue)
        {
            var ret = organizeApp.ModifyOrganize(org, keyValue);
            if (ret == 1)
            {
                return Success("修改机构成功");
            }
            else
            {
                return Error("修改机构失败");
            }
        }

        public ActionResult GetFormJson(string keyValue)
        {
            var entity = organizeApp.GetForm(keyValue);
            return Content(entity.ToJson());
        }




        public ActionResult DeleteOrganize(string keyValue)
        {
            var ret = organizeApp.DeleteOrganize(keyValue);
            if (ret == 1)
            {
                return Success("删除机构成功");
            }
            else
            {
                return Error("删除机构失败");
            }
        }

        public ActionResult GetTreeOrgProp()
        {
            var list = EnumExt.GetEnumList<OrgProp>();
            return Content(list.ToJson());
        }

        public ActionResult GetTreeSelectJson()
        {
            var list = organizeApp.GetList();
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            foreach (var item in list)
            {
                TreeSelectModel tree = new TreeSelectModel();
                tree.id = item.ID;
                tree.text = item.OrgName;
                treeList.Add(tree);

            }
            return Content(treeList.ToJson());
        }
    }
}