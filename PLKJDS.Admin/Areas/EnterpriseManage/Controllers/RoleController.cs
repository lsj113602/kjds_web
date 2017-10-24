using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.BLL;
using PLKJDS.Entity;
using PLKJDS.Common;

namespace PLKJDS.Admin.Areas.EnterpriseManage.Controllers
{
    public class RoleController : ControllerBase
    {
        //private string OrgID = OperatorProvider.Provider.GetCurrent().CompanyId;
        private string OrgID = "5409875a-43bf-4767-9f14-cec777fcdce4";
        private string AccountType = "abfc94e9-cada-46f9-9a20-1ad6423062c8";

        RoleApp roleApp = new RoleApp();

        // GET: SchoolManage/Role
        public ActionResult GetTreeSelectJson()
        {
            var list = roleApp.GetList();
            list = list.Where(x => x.AccountTypeID == AccountType).ToList();
            return Content(list.ToJson());
        }
    }
}