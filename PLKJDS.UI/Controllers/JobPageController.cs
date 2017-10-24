using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.Common;
using PLKJDS.UIEntity.UI;
using PLKJDS.UIBLL;
using System.IO;

namespace PLKJDS.UI.Areas.Course.Controllers
{
    public class JobPageController : ControllerBase
    {
        public override ActionResult Index() 
        {
            //var Condition = new { };//{ JobPosts=null, JobTypes=null, JobAreas=null };
            var Condition = new EmployApp().GetJobCon();
            ViewBag.ConditionJSON = Newtonsoft.Json.JsonConvert.SerializeObject(Condition);
            return View();
        }

        public ActionResult GetJobs(string jobPostId, string jobTypeId, string jobAreaId, int pageNo, int pageSize) 
        {
            //var data = new { };//{ TotalPage=null, TotalRecord=null, List=null };
            //List:Id, Name:市场推广, Type:兼职, Cpy:湖南纽曼数码科技有限公司, Address:工作地点, Count:招聘人数, PubDT:发布时间, Pay:薪资
            var data = new EmployApp().GetJobs(jobPostId, jobTypeId, jobAreaId, pageNo, pageSize);
            return Success(null, data);
        }

        public ActionResult Detail(string id) 
        {
            ViewBag.JobId = id;
            return View();
        }

        public ActionResult GetJob(string id) 
        { 
            //{ JobMain: null, JobDetail: null, JobCpy: null, SimilarJobs:null };
            //jobMain_Name,jobMain_Pay,jobMain_Address,jobMain_Exp,jobMain_Edu,jobMain_Type,jobMain_PubDT
            //jobDetail_Tempt,jobDetail_Desc,jobDetail_Address
            //jobCpy_Name,jobCpy_Ind,jobCpy_Nature,jobCpy_Scale,jobCpy_OffSite
            //Id, ImgSrc,  Name, Pay, CpyName, Address
            //var data = new { };
            var data = new EmployApp().GetJob(id);
            return Success(null, data);
        }

        public ActionResult ApplyJob(string id)
        {
            var user = OperatorProvider.Provider.GetCurrent();
            if (user == null)
            {
                return Content(new AjaxResult { state = "login", message = "请登录" }.ToJson());
            }
            var userId = user.UserId;
            new EmployApp().ApplyJob(userId, id);//"faa2d2a1-bc9b-427a-bbc1-c5986909683e"
            return Success(null);
        }
    }
}