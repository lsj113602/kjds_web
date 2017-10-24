using PLKJDS.Common;
using PLKJDS.Entity;
using PLKJDS.UIBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.UI
{
    public class TrainPageController : ControllerBase
    {
        private TrainApp trainBll = new TrainApp();
        public ActionResult GetTrainList()
        {

            return Content("");
        }

        public ActionResult GetTrainPageList(string keyword, Pagination pagination, string levelID, int statusCode)
        {
            string sql =
@"SELECT c.ID,c.LevelID,c.PhotoID,c.CourseName,c.SetTime,c.StartTime,c.EndTime,c.StatusCode,c.TrueName AS TeacherName,c.CreateCourseUserID,c.DeleteMark,o.OrgName,c.Desc FROM (
SELECT c.ID,c.LevelID,c.PhotoID,c.CourseName,c.SetTime,c.StartTime,c.EndTime,c.StatusCode,c.CreateCourseUserID,c.DeleteMark,c.Desc,u.TrueName,u.OrgID FROM course AS c 
LEFT JOIN `User`as u 
ON  c.CreateCourseUserID = u.ID) AS c 
LEFT JOIN organize as o
ON c.OrgID = o.ID";
            var list = trainBll.GetTrainList(keyword, sql, pagination, levelID, statusCode);
            var data = new
            {
                CourseList = list,
                Page = pagination,
                LevelID = levelID,
                StatusCode = statusCode
            };
            return Success("", data);
        }

        public ActionResult GetTrainPageList2(string keyword, Pagination pagination, string levelID, int statusCode)
        {
            var list = trainBll.GetTrainList2(keyword, pagination, levelID, statusCode);
            var data = new
            {
                CourseList = list,
                Page = pagination,
                LevelID = levelID,
                StatusCode = statusCode
            };
            return Success("", data);
        }
        public ActionResult GetTrainPageDetail(string trainID1)
        {
            string trainID = Request.Cookies["trainID"].Value;
            TrainInfo trainDetail = trainBll.GetTrainDetail(trainID);
            List<TrainInfo> list = new List<TrainInfo>();
            if (trainDetail == null)
            {
                throw new Exception("查询失败，请返回上一级");
            }
            list.Add(trainDetail);
            //var courseChapterList = trainBll.GetCourseChapterList(courseID);
            //var courseTeacherList = trainBll.GetTeacherList(courseChapterList.Select(x => x.UserID).Distinct().ToArray());
            //var data = new
            //{
            //    CourseDetail = courseDetail,
            //    CourseChapterList = courseChapterList,
            //    CourseTeacherList = courseTeacherList
            //};
            var data = new
            {
                TrainDetail = list
            };
            Response.Cookies["trainID"].Value = null;
            return Success("", data);
        }
        public ActionResult TrainDetail(string trainID)
        {
            Response.Cookies["trainID"].Value = trainID;
            //ViewBag.trainID = trainID;
            return View();
        }
    }
}