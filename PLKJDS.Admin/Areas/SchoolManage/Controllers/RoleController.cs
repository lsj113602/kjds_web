using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.BLL;
using PLKJDS.Entity;
using PLKJDS.Common;

namespace PLKJDS.Admin.Areas.SchoolManage.Controllers
{
    public class RoleController : ControllerBase
    {
        //private string OrgID = OperatorProvider.Provider.GetCurrent().CompanyId;
        private string OrgID = "5409875a-43bf-4767-9f14-cec777fcdce4";
        private string AccountType = "8eabdc8f-7e20-47f4-8acf-1c4678d53559";

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