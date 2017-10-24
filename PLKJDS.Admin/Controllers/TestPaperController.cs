using PLKJDS.BLL.SystemManage;
using PLKJDS.Common;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Controllers
{
    public class TestPaperController : ControllerBase
    {
        TestPaperApp testpaperApp = new TestPaperApp();
        //
        // GET: /TestPaper/

        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult GetGridJson(string keyWord)
        {
            var list = testpaperApp.GetPapersList();
            if (!string.IsNullOrEmpty(keyWord))
            {
                list = list.Where(x => x.CourseID.Contains(keyWord)).ToList();
            }
            return Content(list.ToJson());
        }

        public ActionResult CreateTestPaper(ExaminationPaper paper)
        {
            var result = testpaperApp.CreatePaper(paper);
            if(result==1)
            {
                return Success("操作成功");
            }
            else
            {
                return Error("操作失败");
            }
        }

        public ActionResult GetQuestionSum(string courseID)
        {
            var selectsum = testpaperApp.GetSelectNum(courseID);
            var TFsum = testpaperApp.GetTFNum(courseID);
            var r = new
            {
                selectTotal = selectsum,
                TFTotal = TFsum
            };
            return Content(r.ToJson());
        }

        public ActionResult DeleteForm(string keyValue)
        {
            var ret = testpaperApp.DeleteTestPaper(keyValue);
            if (ret == 1)
            {
                return Success("删除试卷成功");
            }
            else
            {
                return Error("删除试卷失败");
            }
        }

        #region 获取试卷（含题目）
        public ActionResult GetPaperDetail(string paperID)
        {
            var paper = testpaperApp.GetPaperModelList(paperID);
            return Content(paper.ToJson());
        }
        #endregion
        public ActionResult PaperDetail(string keyValue)
        {
            var paper = testpaperApp.GetPaperModelList(keyValue);
            return Content(paper.ToJson());
        }
    }
}