using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.BLL;
using PLKJDS.Common;

namespace PLKJDS.Admin.Areas.EnterpriseManage.Controllers
{
    public class OrganizeController : ControllerBase
    {
        // GET: SchoolManage/Organize
        //private string OrgID = OperatorProvider.Provider.GetCurrent().CompanyId;
        private string OrgID = "88c9ce67-7ad2-4136-b8d4-6bcd4707907c";
        OrganizeApp organizeApp = new OrganizeApp();
        public ActionResult GetTreeSelectJson()
        {
            var entity = organizeApp.GetForm(OrgID);
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            TreeSelectModel tree = new TreeSelectModel();
            tree.id = entity.ID;
            tree.text = entity.OrgName;
            treeList.Add(tree);
            return Content(treeList.ToJson());
        }
    }
}