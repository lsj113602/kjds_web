using PLKJDS.BLL;
using PLKJDS.BLL.SystemManage;
using PLKJDS.Common;
using PLKJDS.Entity;
using PLKJDS.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Controllers
{
    public class CourseChapterController : ControllerBase
    {
        
        // GET: /Syllabus/
        private CourseChapterApp courseChapterApp = new CourseChapterApp();
        private UserApp userApp = new UserApp();

        public ActionResult GetTreeGridJson(Pagination pagination, string keyword)
        {
            var data = courseChapterApp.GetChapterList();
            if (!string.IsNullOrEmpty(keyword))
            {
                var searchCourse= data.Where(t =>t.PID=="0"&& t.ChapterName.Contains(keyword)).ToList();
                if(data.Count>0)
                {
                    var courseID = data.FirstOrDefault().CourserID;
                    data = data.Where(t => t.CourserID == courseID).ToList();
                }
            }
            var treeList = new List<TreeGridModel>();
            foreach (CourseChapter item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.PID == item.ID) == 0 ? false : true;
                treeModel.id = item.ID;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.PID;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson("0"));
        }

        public ActionResult GetTreeData(string keyValue)
        {
            var data = courseChapterApp.GetChapterList("-1", keyValue);
            List<TreeDataModel> treelist = new List<TreeDataModel>();
            foreach (var item in data)
            {
                TreeDataModel treemodel = new TreeDataModel();

                bool hasChildren = data.Count(t => t.PID == item.ID) == 0 ? false : true;
                if(hasChildren)
                {
                    treemodel.name = item.ChapterName;
                    treemodel.code = item.ID;
                    treemodel.icon = "icon-th";
                    List<ChildDataModel> childlist = new List<ChildDataModel>();
                    var childdatas = courseChapterApp.GetChapterList(item.ID);
                    foreach (var key in childdatas)
                    {
                        ChildDataModel childmodel = new ChildDataModel();
                        childmodel.name = key.ChapterName;
                        childmodel.code = key.ID;
                        childmodel.icon = "icon-minus-sign";
                        childmodel.parentCode = key.PID;
                        childmodel.child = null;
                        childlist.Add(childmodel);
                    }
                    treemodel.child = childlist;
                    treelist.Add(treemodel);
                }
            }
            var a = treelist.ToJson();
            return Content(treelist.ToJson());
        }
        public ActionResult  GetCourseTree()
        {
            CourseApp courseapp=new CourseApp();
            var list = courseapp.GetCourseList();
            var treeList = new List<TreeSelectModel>();
            foreach (Course item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.ID;
                treeModel.text = item.CourseName;
                treeModel.parentId = item.PreCourse;
                treeList.Add(treeModel);
            }
            return Content(treeList.ToJson());
        }
        public ActionResult GetFormJson(string keyValue)
        {
            var model = courseChapterApp.GetForm(keyValue);
            return Content(model.ToJson());
        }
        public ActionResult SubmitForm(CourseChapter coursechapter,string Uid,string keyValue)
        {
            string userId = coursechapter.UserID;
            if (userId != null&& userId != ""&& Uid == null)
            {
                List<User> userList = userApp.findUserById(userId);
                if (userList.Count != 1)
                {
                    return Error("改用户不存在或者姓名重复，请重新选择负责人");
                }
                else
                {
                    coursechapter.UserID = userList[0].ID;
                }
            }else if(Uid !=null)
            {
                coursechapter.UserID = Uid;
            }else
            {
                return Error("请选择负责人");
            }
            //string userId=coursechapter.UserID;
            //List<User> userList=userApp.findUserById(userId);            
            var res = courseChapterApp.AddChapter(coursechapter, keyValue);
            if(res==1)
            {
                return Success("操作成功");
            }
            else
            {
                return Error("操作失败");
            }
        }
        public ActionResult GetChapterOrder(string keyValue)
        {
            var order = courseChapterApp.GetChapterOrder(keyValue);
            return Content(order.ToJson());
        }
        public ActionResult DeleteForm(string keyValue)
        {
            var result = courseChapterApp.DeleteForm(keyValue);
            if(result==1)
            {
                return Success("删除成功");
            }
            else
            {
                return Error("删除失败");
            }
        }
	}
}