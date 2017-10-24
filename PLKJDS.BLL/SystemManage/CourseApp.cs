using PLKJDS.Common;
using PLKJDS.Common.Enums;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.BLL.SystemManage
{
   public  class CourseApp
    {
        private ICourseRepository service = new CourseRepository();
        private IUserRepository userService = new UserRepository();
        private ICourseChapterRepository chapter_servcie = new CourseChapterRepository();
       public List<Course> GetCourseList()
       {
           //var e = ExtLinq.True<Course>();

           //e = e.Or(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
           //e = e.Or(x => (x.IsShow == null ? false : x.IsShow) != true);
           var list = service.IQueryable().Where(x => (x.DeleteMark == null ? false : x.DeleteMark) != true&&(x.IsShow == null ? false : x.IsShow) != true).ToList();
           return list;
       }

       public List<Course> GetNoChapterList()
       {
           var list = service.IQueryable().Where(x => (x.DeleteMark == null ? false : x.DeleteMark) != true && (x.IsShow == null ? false : x.IsShow) != true).ToList();
           var resultList = new List<Course>();
           foreach (var item in list)
           {
               int count = chapter_servcie.IQueryable().Where(p => p.CourserID== item.ID&&p.PID!="0").ToList().Count;
               if(count==0)
               {
                   resultList.Add(item);
               }
           }
           return resultList;
       }

        public List<Course> GetCourseList(Pagination pagination, string keyword)
        {
            var e = ExtLinq.True<Course>();

            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
           // e = e.And(x => (x.IsShow == null ? false : x.IsShow) != true);
           
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.CourseName.Contains(keyword));
            }
            List<Course> list= service.FindList(e, pagination);
            for (int i=0;i<list.Count;i++)
            {
                User user=userService.FindEntity(list[i].CreateCourseUserID);
                if (user!=null)
                {
                    list[i].CreateCourseUserID = user.TrueName;
                }else
                {
                    list[i].CreateCourseUserID = "";
                }
            }
            //List<Course> list = null;
            //if (pagination != null)
            //{
            //    if (pagination.sord == "asc")
            //    {
            //        if (pagination.sidx == "CourseName")
            //        {
            //            list = service.IQueryable(e).OrderBy(x => x.CourseName).ToList();
            //        }
            //        else if (pagination.sidx == "LevelID")
            //        {
            //            list = service.IQueryable(e).OrderBy(x => x.LevelID).ToList();
            //        }
            //        else if (pagination.sidx == "CreateCourseUserID")
            //        {
            //            list = service.IQueryable(e).OrderBy(x => x.CreateCourseUserID).ToList();
            //        }
            //        else if (pagination.sidx == "StartTime")
            //        {
            //            list = service.IQueryable(e).OrderBy(x => x.StartTime).ToList();
            //        }
            //        else if (pagination.sidx == "EndTime")
            //        {
            //            list = service.IQueryable(e).OrderBy(x => x.EndTime).ToList();
            //        }
            //        else if (pagination.sidx == "StatusCode")
            //        {
            //            list = service.IQueryable(e).OrderBy(x => x.StatusCode).ToList();
            //        }
            //        else if (pagination.sidx == "SerialNum")
            //        {
            //            list = service.IQueryable(e).OrderBy(x => x.SerialNum).ToList();
            //        }
            //        else if (pagination.sidx == "IsTest")
            //        {
            //            list = service.IQueryable(e).OrderBy(x => x.IsTest).ToList();
            //        }
            //        else//IsPublic
            //        {
            //            list = service.IQueryable(e).OrderBy(x => x.CreatorTime).ToList();
            //        }
            //    }
            //    else
            //    {
            //        if (pagination.sidx == "CourseName")
            //        {
            //            list = service.IQueryable(e).OrderByDescending(x => x.CourseName).ToList();
            //        }
            //        else if (pagination.sidx == "LevelID")
            //        {
            //            list = service.IQueryable(e).OrderByDescending(x => x.LevelID).ToList();
            //        }
            //        else if (pagination.sidx == "CreateCourseUserID")
            //        {
            //            list = service.IQueryable(e).OrderByDescending(x => x.CreateCourseUserID).ToList();
            //        }
            //        else if (pagination.sidx == "StartTime")
            //        {
            //            list = service.IQueryable(e).OrderByDescending(x => x.StartTime).ToList();
            //        }
            //        else if (pagination.sidx == "EndTime")
            //        {
            //            list = service.IQueryable(e).OrderByDescending(x => x.EndTime).ToList();
            //        }
            //        else if (pagination.sidx == "StatusCode")
            //        {
            //            list = service.IQueryable(e).OrderByDescending(x => x.StatusCode).ToList();
            //        }
            //        else if (pagination.sidx == "SerialNum")
            //        {
            //            list = service.IQueryable(e).OrderByDescending(x => x.SerialNum).ToList();
            //        }
            //        else if (pagination.sidx == "IsTest")
            //        {
            //            list = service.IQueryable(e).OrderByDescending(x => x.IsTest).ToList();
            //        }
            //        else//IsPublic
            //        {
            //            list = service.IQueryable(e).OrderByDescending(x => x.CreatorTime).ToList();
            //        }
            //        //list = authorizeButtonApp.IQueryable(e).OrderByDescending(x => x.SortCode).ToList();
            //    }
            //    list = list.Skip(pagination.rows * (pagination.page - 1)).Take(pagination.rows).ToList();
            //}
            //else
            //{
            //    list = service.IQueryable().Where(x => (x.DeleteMark == null ? false : x.DeleteMark) != true && (x.IsShow == null ? false : x.IsShow) != true).ToList();
            //}
            return list;
        }

        public int AddOrUpdateCourse(Course course,string KeyValue,string IsRevise)
       {
           int result=0;
           if(string.IsNullOrEmpty(KeyValue))
           {
               Course model = new Course();
               model.Create();
               model.CourseName = course.CourseName;
               model.LevelID =course.LevelID;
               model.PhotoID = course.PhotoID;
               model.StartTime = course.StartTime;
               model.EndTime = course.EndTime;
               model.CreateCourseUserID = course.CreateCourseUserID;
               model.IsTest = course.IsTest;
               model.SerialNum = 0;
               model.IsShow = false;
               model.DeleteMark = false;
              if(DateTime.Compare(Convert.ToDateTime(course.StartTime),DateTime.Now)>0)
              {
                  model.StatusCode = 0;
              }
              else if (DateTime.Compare(DateTime.Now,Convert.ToDateTime(course.EndTime)) > 0)
              {
                  model.StatusCode = 2;
              }
              else
              {
                  model.StatusCode = 1;
              }
               result = service.Insert(model);
           }
           else
           {
                   Course oldcourse = service.FindEntity(KeyValue);
                   if(IsRevise=="1")
                   {
                       Course newcourse = new Course();
                       newcourse.Create();
                       newcourse.CourseName = oldcourse.CourseName;
                       newcourse.LevelID = oldcourse.LevelID;
                       newcourse.PhotoID = oldcourse.PhotoID;
                       newcourse.StartTime = course.StartTime;
                       newcourse.EndTime = course.EndTime;
                       newcourse.PreCourse = oldcourse.ID;
                       newcourse.IsTest = oldcourse.IsTest;
                       newcourse.SerialNum = oldcourse.SerialNum + 1;
                       oldcourse.IsShow = true;
                       newcourse.IsShow = false;
                       if (DateTime.Compare(Convert.ToDateTime(course.StartTime), DateTime.Now) > 0)
                       {
                           newcourse.StatusCode = 0;
                       }
                       else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(course.EndTime)) > 0)
                       {
                           newcourse.StatusCode = 2;
                       }
                       else
                       {
                           newcourse.StatusCode = 1;
                       }
                       result = service.Insert(newcourse);
                       service.Update(oldcourse);
                   }
                   else
                   {
                       oldcourse.CourseName = course.CourseName;
                       oldcourse.LevelID = course.LevelID;
                       oldcourse.StartTime = course.StartTime;
                       oldcourse.EndTime = course.EndTime;
                       oldcourse.PhotoID = course.PhotoID;
                       oldcourse.IsTest = course.IsTest;
                       if (DateTime.Compare(Convert.ToDateTime(course.StartTime), DateTime.Now) > 0)
                       {
                           oldcourse.StatusCode = 0;
                       }
                       else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(course.EndTime)) > 0)
                       {
                           oldcourse.StatusCode = 2;
                       }
                       else
                       {
                           oldcourse.StatusCode = 1;
                       }
                       result = service.Update(oldcourse);
                   }
           }
           return result;
       }

       public Course GetForm(string keyValue)
       {
           return service.FindEntity(keyValue);
       }

       public int DeleteForm(string keyValue)
       {
           var model = service.FindEntity(keyValue);
           model.DeleteMark = true;
           int result=service.Update(model);
           return result;
       }


    }
}
