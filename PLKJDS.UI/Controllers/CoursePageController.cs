using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.Common;
using PLKJDS.UIEntity.UI;
using PLKJDS.UIBLL;
using System.IO;
using PLKJDS.UIEntity;
using System.Configuration;
namespace PLKJDS.UI.Areas.Course.Controllers
{
    public class CoursePageController : ControllerBase
    {
        CourseApp courseApp = new CourseApp();


        //rows 10
        //page 1
        //sidx SetTime
        //levelID -1
        //statusCode -1
        //sord desc
        public ActionResult GetCoursePageList(string keyword,Pagination pagination,string levelID,int statusCode)
        {

            var list = courseApp.GetCourseList(keyword,pagination,levelID,statusCode);
            var data = new {
                CourseList = list,
                Page = pagination,
                LevelID = levelID,
                StatusCode = statusCode
            };
            return Success("",data);
        }

        public ActionResult PartCourse(string courseID)
        {
            var operatorModel = OperatorProvider.Provider.GetCurrent();
            if (operatorModel==null)
            {
                return Error("您还没有登录，请先登录");
            }
            var IsPartner = courseApp.CheckIsPartCourse(operatorModel.UserId, courseID);
            if (IsPartner)
            {
                return Error("您已经参加该课程");
            }
            else
            {
                var ret = courseApp.PartCourse(operatorModel.UserId, courseID);
                if (ret == 1)
                {
                    return Success("报名成功");
                }
                return Error("报名失败");
            }
        }
        #region 保存图片
        public ActionResult SavePic()
        {
            var file = Request.Files["file"];
            if (Directory.Exists(Server.MapPath("~/Image/")) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(Server.MapPath("~/Image/"));
            }
            var path = Server.MapPath("~") + "/Image/";
            var filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + file.FileName;
            path += filename;
            file.SaveAs(path);
            return Success("保存成功", "/Image/" + filename);
        }
        #endregion

        public ActionResult GetCourseDetail(string courseID)
        {
            var courseDetail = courseApp.GetCourseDetail(courseID);
            var courseChapterList = courseApp.GetCourseChapterList(courseID);
            var courseTeacherList = courseApp.GetTeacherList(courseChapterList.Select(x=>x.UserID).Distinct().ToArray());
            var data = new {
                CourseDetail = courseDetail,
                CourseChapterList = courseChapterList,
                CourseTeacherList = courseTeacherList
            };
            return Success("",data);
        }

        public ActionResult CourseDetail(string courseID)
        {
            //var courseDetail = courseApp.GetCourseDetail(courseID);
            //var courseChapterList = courseApp.GetCourseChapterList(courseID);
            //var courseTeacherList = courseApp.GetTeacherList(courseChapterList.Select(x => x.UserID).Distinct().ToArray());
            //ViewBag.courseDetail = courseDetail;
            //ViewBag.courseChapterList = courseChapterList;
            //ViewBag.courseTeacherList = courseTeacherList;
            ViewBag.CourseID = courseID;
            return View();
        }

        public ActionResult CourseVideo(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var prepath= ConfigurationManager.AppSettings["AdminUrl"].ToString().Trim();
                id = prepath + id;
            }
           ViewBag.VideoUrl = id;
            return View();
        }


        public ActionResult GetCourseDetailModel(string courseID)
        {
            var courseDetail = courseApp.GetCourseDetail(courseID);
            var courseChapterList = courseApp.GetCourseChapterList(courseID);
            var courseTeacherList = courseApp.GetTeacherList(courseChapterList.Select(x => x.UserID).Distinct().ToArray());
            CourseDetailModel model = new CourseDetailModel();
            model.coursemodel = courseDetail;
            model.chapter = courseChapterList;
            model.teachers = courseTeacherList;
            return Json(model.ToJson());
        }
    }
}