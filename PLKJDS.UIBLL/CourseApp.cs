using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.Data;
using PLKJDS.UIEntity.UI;
using PLKJDS.Common;
using System.Data.Common;
using System.Configuration;
using PLKJDS.UIEntity;
using MySql.Data.MySqlClient;

namespace PLKJDS.UIBLL
{
    public class CourseApp
    {
        ICourseRepository courseApp = new CourseRepository();


        ICourseParterRepository coursePartnerApp = new CourseParterRepository();
        IChapterContentRepository chapterContentApp = new ChapterContentRepository();
        IRepositoryBase repository = new RepositoryBase();
        ICourseChapterRepository courseChapterApp = new CourseChapterRepository();
        IUserRepository userApp = new UserRepository();
        string adminurl = ConfigurationManager.AppSettings["AdminUrl"].ToString().Trim();


        public List<CourseModel> FindByPartNumber()
        {
            string sql = @"select c.ID,c.PhotoID,c.CourseName, c.LevelID,c.StartTime,
                    c.EndTime, c.Desc,u.UserName as CourseUserName from course c,user u 
                    where c.CreateCourseUserID=u.ID and c.DeleteMark!=true ORDER BY c.StartTime desc limit 4";
            List<CourseModel> list = repository.FindList<CourseModel>(sql).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                // adminurl
                list[i].PhotoID = adminurl + list[i].PhotoID;
            }
            foreach (var item in list)
            {

                var f = ExtLinq.True<CourseParter>();
                f = f.And(x => x.CourseID == item.ID);
                f = f.And(x => x.IsCancel != true);
                item.PartNumber = coursePartnerApp.IQueryable(f).Count();
            }
            return list;
        }
        public List<CourseListModel> GetCourseList(string keyword, Pagination pagination, string levelID, int statusCode)
        {

            var e = ExtLinq.True<CourseListModel>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.CourseName.Contains(keyword));
            }
            if (levelID != "-1")
            {
                e = e.And(x => x.LevelID == levelID);
            }
            //if (statusCode != -1)
            //{
            //    e = e.And(x => x.StatusCode == statusCode);
            //}
            string sql =
            @"SELECT c.ID,c.LevelID,c.PhotoID,c.CourseName,c.SerialNum,c.StartTime,c.EndTime,
            c.StatusCode,c.TrueName AS TeacherName,c.CreateCourseUserID,c.DeleteMark,o.OrgName,c.Desc 
            FROM (SELECT c.ID,c.LevelID,c.PhotoID,c.CourseName,c.SerialNum,c.StartTime,c.EndTime,
            c.StatusCode,c.CreateCourseUserID,c.DeleteMark,c.Desc,u.TrueName,u.OrgID 
            FROM course AS c LEFT JOIN `User`as u ON  c.CreateCourseUserID = u.ID) AS c 
            LEFT JOIN organize as o ON c.OrgID = o.ID";

            var list = repository.FindList<CourseListModel>(e, sql, pagination).ToList();

            //for (int i = 0; i < list.Count; i++)
            //{
            //    // adminurl
            //    list[i].PhotoID = adminurl + list[i].PhotoID;
            //}
            foreach (var item in list)
            {
                var f = ExtLinq.True<CourseParter>();
                f = f.And(x => x.CourseID == item.ID);
                f = f.And(x => x.IsCancel != true);
                item.PartnerCount = coursePartnerApp.IQueryable(f).Count();
                item.PhotoID = adminurl + item.PhotoID;
                if (DateTime.Compare(Convert.ToDateTime(item.StartTime), DateTime.Now) > 0)
                {
                    item.StatusCode = 0;//即将开课
                }
                else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(item.EndTime)) > 0)
                {
                    item.StatusCode = 2;//已结课
                }
                else
                {
                    item.StatusCode = 1;//开课中
                }
            }
            if (statusCode != -1)
            {
                list = list.Where(p => p.StatusCode == statusCode).ToList();
            }
            return list;
        }


        public bool CheckIsPartCourse(string userid, string courseId)
        {
            var e = ExtLinq.True<CourseParter>();
            e = e.And(x => x.CourseID == courseId);
            e = e.And(x => x.UserID == userid);
            e = e.And(x => x.IsCancel == false);
            var ret = coursePartnerApp.IQueryable(e).Count();
            if (ret == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public int PartCourse(string userid, string courseId)
        {
            CourseParter coursePartner = new CourseParter();
            coursePartner.Create();
            coursePartner.CourseID = courseId;
            coursePartner.UserID = userid;
            coursePartner.IsCancel = false;
            coursePartner.IsFinish = false;
            coursePartner.IsTest = false;
            var ret = coursePartnerApp.Insert(coursePartner);
            return ret;
        }



        public CourseListModel GetCourseDetail(string courseID)
        {
            MySqlParameter param = new MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@Course";
            param.Value = courseID;
            string sql =
@"SELECT c.ID,c.LevelID,c.PhotoID,c.CourseName,c.SerialNum,c.StartTime,c.EndTime,c.StatusCode,c.TrueName AS TeacherName,
c.CreateCourseUserID,c.DeleteMark,o.OrgName ,c.LogoID as TeacherImg FROM (
SELECT c.ID,c.LevelID,c.PhotoID,c.CourseName,c.SerialNum,c.StartTime,c.EndTime,c.StatusCode,
c.CreateCourseUserID,c.DeleteMark,u.TrueName,u.OrgID,u.LogoID FROM course AS c 
LEFT JOIN `User`as u 
ON  c.CreateCourseUserID = u.ID) AS c 
LEFT JOIN organize as o
ON c.OrgID = o.ID
WHERE c.id = @Course";
            DbParameter[] dbParam = new DbParameter[] {
                param
            };
            var list = repository.FindList<CourseListModel>(sql, dbParam).ToList();
            if (list.Count == 1)
            {
                list[0].PhotoID = adminurl + list[0].PhotoID;
                if (DateTime.Compare(Convert.ToDateTime(list[0].StartTime), DateTime.Now) > 0)
                {
                    list[0].StatusCode = 0;//即将开课
                }
                else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(list[0].EndTime)) > 0)
                {
                    list[0].StatusCode = 2;//已结课
                }
                else
                {
                    list[0].StatusCode = 1;//开课中
                }
                return list[0];
            }

            return null;
        }

        public List<ChapterAndFile> GetCourseChapterList(string courseID)
        {
            //var e = ExtLinq.True<CourseChapter>();
            //e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            //e = e.And(x => x.CourserID == courseID);
            //var list = courseChapterApp.IQueryable(e).OrderBy(x=>x.SequenceID).ToList();
            string sql = @"SELECT a.* FROM plkjds.coursechapter as a
            where a.DeleteMark!=1 and a.CourserID=@courseID  order by a.SequenceID";
            DbParameter[] chapterparam = new DbParameter[] { new MySqlParameter() { ParameterName="@courseID",Value=courseID} };
            var list = repository.FindList<ChapterAndFile>(sql, chapterparam).ToList();
            if(list.Count>0)
            {
                foreach (var item in list)
                {
                    item.FileID = GetChapterFile(item.ID,"文档");
                    item.VideoID = GetChapterFile(item.ID, "视频");
                }
            }
            return list;
        }

        public string GetChapterFile(string chapterID,string typeID)
        {
            string fileID = "";
            var e = ExtLinq.True<ChapterContent>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            e = e.And(x => x.ChapterID == chapterID);
            e = e.And(x => x.TypeID == typeID);
            var file= chapterContentApp.IQueryable(e).OrderByDescending(x => x.CreatorTime).FirstOrDefault();
            if(file!=null)
            {
                if(typeID=="文档")
                {
                    fileID =adminurl+ file.FileID;
                }
                else
                {
                    fileID = file.FileID;
                }
            }
            return fileID;
     }

        public List<CourseTeacherModel> GetTeacherList(string[] userIDs)
        {
            List<CourseTeacherModel> list = new List<CourseTeacherModel>();
            if (userIDs.Length > 0)
            {
                foreach (var userid in userIDs)
                {
                    var tempUser = GetTeacherModel(userid);
                    if (tempUser != null)
                        list.Add(tempUser);
                }
                return list;
            }
            return null;
        }

        private CourseTeacherModel GetTeacherModel(string teacherid)
        {
            MySql.Data.MySqlClient.MySqlParameter param = new MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = "@UserID";
            param.Value = teacherid;
            string sql =
@"SELECT U.ID,U.TrueName,U.ReMark,U.Department,O.OrgName FROM `User` AS U LEFT JOIN
organize AS O
ON U.OrgID = O.ID
WHERE U.ID = @UserID;";
            DbParameter[] dbParam = new DbParameter[] {
                param
            };
            var list = repository.FindList<CourseTeacherModel>(sql, dbParam).ToList();
            if (list.Count == 1)
                return list[0];
            return null;
        }
    }
}
