using PLKJDS.BLL.SystemManage;
using PLKJDS.Common;
using PLKJDS.Common.Enums;
using PLKJDS.Entity;
using PLKJDS.UIEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Controllers
{
    public class CourseController : ControllerBase
    {
        //
        // GET: /Course/
        private CourseApp courseApp = new CourseApp();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReviseForm()
        {
            return View();
        }

        public ActionResult UploadCourseware()
        {
            return View();
        }


        #region 获取课程列表
        public ActionResult GetGridJson()
        {
            var list = courseApp.GetCourseList();
            return Content(list.ToJson());
        }
        #endregion
        public ActionResult GetGridJsonPage(Pagination pagination, string keyword)
        {
            var list = courseApp.GetCourseList(pagination, keyword);
            return Content(list.ToJson());
        }

        #region 保存图片
        public ActionResult SavePic()
        {
            var file = Request.Files["file"];
            var path = Server.MapPath("~") + "/Image/";
            var filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + file.FileName;
            path += filename;
            file.SaveAs(path);
            return Success("保存成功", "/Image/" + filename);
        }
        #endregion

        public ActionResult UploadSource()
        {
            var conut = Request.Files.Count;
            var file = Request.Files[0];
            if (Directory.Exists(Server.MapPath("~/Courseware/")) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(Server.MapPath("~/Courseware/"));
            }
            var path = Server.MapPath("~") + "/Courseware/";
            var filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + file.FileName;
            path += filename;
            file.SaveAs(path);
            return Success("保存成功", "/Courseware/" + filename);
        }

        public ActionResult SubmitForm(Course course, string keyValue,string IsRevise)
        {
            OperatorModel loginUser=OperatorProvider.Provider.GetCurrent();
            if (loginUser==null)
            {
                return Error("未登录，请先登录");
            }else
            {
                course.CreateCourseUserID = loginUser.UserId;
                courseApp.AddOrUpdateCourse(course, keyValue, IsRevise);
                return Success("操作成功");
            }           
        }

        public ActionResult GetFormJson(string keyValue)
        {
            var data = courseApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        public ActionResult GetTreeSelectJson(string type,string courseID)
        {
            CourseChapterApp coursechapterApp=new CourseChapterApp();
            var data  = coursechapterApp.GetChapterList(type, courseID);
            var treeList = new List<TreeSelectModel>();
            foreach (CourseChapter item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.ID;
                treeModel.text = item.ChapterName;
                treeModel.parentId = item.PID;
                treeList.Add(treeModel);
            }
            var a = treeList.ToJson();
            return Content(treeList.ToJson());
        }

        public ActionResult SubmitCourseContent(ChapterContent chaptercontent)
        {
            ChapterContentApp chaptercontentApp = new ChapterContentApp();
            if(chaptercontent.FileID.Contains(','))
            {
                string[] fileArr = chaptercontent.FileID.Split(',');
                for(int i=0;i<fileArr.Length;i++)
                {
                    ChapterContent model = new ChapterContent();
                    model.FileID = fileArr[i];
                    model.ChapterID = chaptercontent.ChapterID;
                    model.CourserID = chaptercontent.CourserID;
                    model.TypeID = Path.GetExtension(fileArr[i]);
                    chaptercontentApp.AddChapterContent(model);
                }
            }
            else
            {
                chaptercontentApp.AddChapterContent(chaptercontent);
            }
      
            return Success("操作成功");
        }   
     
        public ActionResult  GetChapterContentJson(string keyValue)
        {
            ChapterContentApp chaptercontentApp = new ChapterContentApp();
            List<ChapterContentModel> list =chaptercontentApp.GetListByCourseID(keyValue);
            return Content(list.ToJson());
        }

        public ActionResult DeleteForm(string keyValue)
        {
            int result = courseApp.DeleteForm(keyValue);
            if(result==1)
            {
                return Success("操作成功");
            }
            else
            {
                return Error("操作失败");
            }
        }

       
    }
}