using PLKJDS.BLL;
using PLKJDS.BLL.SystemManage;
using PLKJDS.Common;
using PLKJDS.Common.Enums;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Controllers
{
    public class EmployController : ControllerBase
    {
        //
        // GET: /Employ/
        EmployApp employapp = new EmployApp();

        #region o
        public ActionResult GetGridJson()
        {
            var list = employapp.GetEmployList();
            return Content(list.ToJson());
        }

        public ActionResult GetFormJson(string keyValue)
        {
            var model = employapp.GetForm(keyValue);
            return Content(model.ToJson());
        }
        [ValidateInput(false)]
        public ActionResult SubmitForm(Employ employ,string keyValue,string Orglist)
        {
            employ.PublishTime=DateTime.Now;
            if(employ.EndTime.ToString()=="oneweek")
            {
                employ.StartTime = employ.PublishTime;
                employ.EndTime = Convert.ToDateTime(employ.StartTime).AddDays(7);

            }
            else if(employ.EndTime.ToString()=="onemonth")
            {
                employ.StartTime = employ.PublishTime;
                employ.EndTime = Convert.ToDateTime(employ.StartTime).AddDays(30);

            }
            employ.StatusCode = EmployStatu.PendingApproval.GetEnumNote();
            var result = employapp.AddOrUpdateEmploy(employ, keyValue);
            EmployPublishApp  employpubApp=new EmployPublishApp();
            string[] orgID_Arr = Orglist.TrimEnd(',').Split(',');
            bool orgFlag = true;
            for (int i = 0; i < orgID_Arr.Length;i++)
            {
                var res = employpubApp.AddMutiEmployType(employ.ID, "", orgID_Arr[i]);
                if(res!=1)
                {
                    orgFlag = false;
                    break;
                }
            }
                if (result == 1&&orgFlag)
                {
                    return Success("操作成功");
                }
                else
                {
                    return Error("操作失败");
                }
        }

        public ActionResult GetSelectJson()
        {
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            EmployPositionApp positionApp = new EmployPositionApp();
            var data = positionApp.GetPositionList();
            foreach (EmployPosition item in data)
            {
            
                bool hasChildren = data.Count(t => t.PID == item.ID) == 0 ? false : true;
                TreeSelectModel tree = new TreeSelectModel();
                tree.id = item.PosName;
                tree.text = item.PosName;
                treeList.Add(tree);
            }
            return Content(treeList.ToJson());
        }

        public ActionResult GetJobExpSelectJson(string type)
        {
           List<TreeSelectModel> data = new List<TreeSelectModel>();
            switch(type)
            {
                case "1":  data = EnumExt.GetEnumNoteList<JobExperience>(); 
                    break;
                case "2": data = EnumExt.GetEnumNoteList<EducationRequire>(); 
                    break;
                case "3": data = EnumExt.GetEnumNoteList<EmployTypes>();
                    break;
                default: break;
            }
            return Content(data.ToJson());
        }

        public ActionResult Parter()
        {
            return View();
        }

        public ActionResult JobPosition()
        {
            return View();
        }
        public ActionResult DeleteForm( string keyValue)
        {
            var res = employapp.DeleteEmploy(keyValue);
            if(res==1)
            {
                return Success("操作成功");
            }
            else
            {
                return Error("删除失败");
            }
        }

        public ActionResult AddJobPosition(string posname,string sortcode)
        {
            EmployPositionApp epa=new EmployPositionApp();
            int code = sortcode.ToInt();
            int res = epa.AddPositon(posname,code);
            return Content(res.ToJson());
        }

        public override ActionResult Form()
        {
            OrganizeApp oa = new OrganizeApp();
            var list = oa.GetList();
            string allorgID = "";
            foreach (var item in list)
            {
                allorgID = allorgID + item.ID + ",";
            }
            ViewBag.AllOrgID = allorgID;
            return View();
        }

        public string GetOrgList(string employID)
        {
            EmployPublishApp epa = new EmployPublishApp();
            var list = epa.GetList(employID);
            string orgID_str = "";
            foreach (var item in list) 
            {
                orgID_str = orgID_str + item.ROrgUserID + ",";
            }
            return orgID_str;
        }
        #endregion
        public ActionResult GetParterJson(string keyValue,string keyword,Pagination pagination)
        {
            var list = employapp.GetEmployPartnerList(keyword,keyValue,pagination);
            return Content(list.ToJson());
        }

    }
}