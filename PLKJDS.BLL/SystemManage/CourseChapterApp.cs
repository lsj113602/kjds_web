using PLKJDS.Common;
using PLKJDS.Data;
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
   public class CourseChapterApp
    {
       private ICourseChapterRepository servcie = new CourseChapterRepository();
       private ICourseRepository course_service = new CourseRepository();
        private IUserRepository user_service = new UserRepository();
        private IRepositoryBase repository = new RepositoryBase();
        public List<CourseChapter> GetChapterList()
       {
           string sql = @"SELECT cc.ID,cc.CourserID,cc.ChapterName,cc.SetTime,cc.SequenceID,
            cc.PID,cc.CreatorTime,u.TrueName as UserID,cc.CreatorUserId,cc.LastModifyUserId,
            cc.LastModifyTime,cc.DeleteUserId,cc.DeleteMark,cc.DeleteTime from coursechapter cc 
            left join user as u on cc.UserID=u.ID  where cc.DeleteMark!=1 ORDER BY(cc.SequenceID);";
            List<CourseChapter>  list=repository.FindList<CourseChapter>(sql).ToList();
            //list = list.Where(x => (x.DeleteMark == null ? false : x.DeleteMark) != true).ToList();
            return list;
       }

       public List<CourseChapter> GetChapterList(string type,string courseID)
       {
           var list = new List<CourseChapter>(); 

            if(type=="1")
            {
                list = servcie.IQueryable().Where(t=>(t.DeleteMark==null?false:t.DeleteMark)!=true&&t.PID == courseID).ToList();
            }
            else
            {
               
                if(type=="-1")
                {
                    list = servcie.IQueryable().Where(t=>(t.DeleteMark==null?false:t.DeleteMark)!=true&&t.CourserID == courseID && t.PID != "0").ToList();
                }
                else
                {
                    var course = servcie.IQueryable().Where(t=>(t.DeleteMark==null?false:t.DeleteMark)!=true&&t.CourserID == courseID &&t.PID == "0").FirstOrDefault();
                    if(course!=null)
                    {
                        list = servcie.IQueryable().Where(t=>(t.DeleteMark==null?false:t.DeleteMark)!=true&&t.PID == course.ID).ToList();
                    }
                }
                
            }
            return list;
       }

       public List<CourseChapter> GetChapterList(string PID)
       {    
            var  list = servcie.IQueryable().Where(t => t.PID == PID).ToList();         
            return list;
       }

       public CourseChapter GetForm(string keyValue)
       {
           var model = servcie.FindEntity(keyValue);
            if (model!=null)
            {
                User user=user_service.FindEntity(model.UserID);
                model.UserID = user.TrueName;
            }            
           return model;
       }
       public int AddChapter(CourseChapter coursechpater,string keyValue)
       {
           //string username = coursechpater.UserID;
           // var e = ExtLinq.True<User>();
           // e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
           // e = e.And(x => x.TrueName == username);
           // User user=user_service.FindEntity(e);
            CourseChapter model = new CourseChapter();
           int result = 0;
           if(string.IsNullOrEmpty(keyValue)) //新增大纲
           {
               var count = servcie.IQueryable().Where(t => t.CourserID == coursechpater.CourserID && t.PID == "0"&&(t.DeleteMark==null?false:t.DeleteMark)!=true).FirstOrDefault();//所属课程对象
               model.Create();
               model.CourserID = coursechpater.CourserID;
               if (count == null)
               {
                   CourseChapter rootmodel = new CourseChapter();
                   rootmodel.Create();
                   rootmodel.PID = "0";
                   rootmodel.ChapterName = course_service.FindEntity(coursechpater.CourserID).CourseName;
                   rootmodel.SequenceID = 1;
                   rootmodel.CourserID = coursechpater.CourserID;
                   rootmodel.UserID = coursechpater.UserID;
                   rootmodel.CreatorUserId = coursechpater.CreatorUserId;
                   rootmodel.SetTime = DateTime.Now;
                   rootmodel.DeleteMark = false;

                   model.PID = rootmodel.ID;
                   servcie.Insert(rootmodel);//新增顶级课程节点
               }
               else
               {
                   model.PID = coursechpater.PID == "-1" ? count.ID : coursechpater.PID;
               }
                 model.UserID = coursechpater.UserID;
                    var exsitmodel = servcie.IQueryable().Where(x => x.PID == model.PID & x.SequenceID == coursechpater.SequenceID & (x.DeleteMark == null ? false : x.DeleteMark) != true).FirstOrDefault();
                    if (exsitmodel != null) //序号相同，从该位置插入
                    {
                        var chaperNum = exsitmodel.ChapterName.Split(' ')[0];
                        model.ChapterName = chaperNum + " " + coursechpater.ChapterName;
                        model.SequenceID = exsitmodel.SequenceID;
                        GetReorderName(exsitmodel, "add");
                    }
                    else
                    {
                        model.SequenceID = coursechpater.SequenceID;
                        var brotherList = servcie.IQueryable().Where(x => x.PID == model.PID & x.SequenceID > coursechpater.SequenceID & (x.DeleteMark == null ? false : x.DeleteMark) != true).OrderBy(x => x.SequenceID).FirstOrDefault();
                        var num = GetChapterOrder(model.PID);
                        var order = "";
                        if (brotherList != null) //序号大于同级大纲节点总数
                        {
                            order = "第" + num.ToString();
                            GetReorderName(brotherList, "add");
                        }
                        else
                        {
                            order = order = "第" + (num + 1).ToString();
                        }
                        model.ChapterName = coursechpater.PID == "-1" ? order + "章" + ' ' + coursechpater.ChapterName : order + "节" + ' ' + coursechpater.ChapterName;
                    }
                    model.CreatorUserId = coursechpater.CreatorUserId;
                    model.SetTime = DateTime.Now;
                    model.DeleteMark = false;
                    result = servcie.Insert(model);        
                                            
           }
           else //修改大纲
           {
               model = servcie.FindEntity(keyValue);
               var name = model.ChapterName.Split(' ')[0];
               model.ChapterName = name +' '+ coursechpater.ChapterName;
               model.UserID = coursechpater.UserID;
               result = servcie.Update(model);
           }
           return result;
       }
       
       public int GetChapterOrder(string keyValue)
       {
           var count = servcie.IQueryable().Where(p => p.PID == keyValue && (p.DeleteMark==null?false:p.DeleteMark) != true).ToList().Count;
           return count;
       }
       
       public int DeleteForm(string keyValue)
       {
           var model = servcie.FindEntity(keyValue);
           model.DeleteMark = true;
           int? sequenceID = model.SequenceID;
          // string pid = model.PID;
           //var afterList = servcie.IQueryable().Where(x =>x.PID==pid & x.SequenceID > sequenceID &(x.DeleteMark==null?false:x.DeleteMark)!=true).ToList();
           //foreach (var key in afterList)
           //{
           //    var node = servcie.FindEntity(key.ID);
           //    node.SequenceID = node.SequenceID - 1;
           //    var arr = node.ChapterName.Split(' ');
           //    node.ChapterName = "第" + node.SequenceID + "章" + " " + arr[2];
           //    servcie.Update(node);
           //}
           int result=servcie.Update(model);
           GetReorderName(model,"update");
           var childlist = GetChapterList(keyValue);
           if(childlist.Count>0)
           {
               foreach (var item in childlist)
               {
                   item.DeleteMark = true;
                   servcie.Update(item);
               }
           }
           return result;
       }

       public void GetReorderName(CourseChapter model,string type)
       {
           List<CourseChapter> afterList = new List<CourseChapter>();
          switch(type)
          {
              case "add":
                  afterList = servcie.IQueryable().Where(x => x.PID == model.PID & x.SequenceID >= model.SequenceID & (x.DeleteMark == null ? false : x.DeleteMark) != true).ToList();
                  break;
              case "update":
                  afterList = servcie.IQueryable().Where(x => x.PID == model.PID & x.SequenceID > model.SequenceID & (x.DeleteMark == null ? false : x.DeleteMark) != true).ToList();
                  break;
              default: break;
          }
           foreach (var key in afterList)
           {
               var arr = key.ChapterName.Split(' ');
               var num=GetChapterOrder(key.PID);
               string order = "";
               if(type=="add")
               {
                   key.SequenceID = key.SequenceID + 1;
                   if (key.SequenceID > num)
                   {
                       order = "第" + (num + 1).ToString();
                       num++;
                   }
                   else
                   {
                       order = "第" + key.SequenceID.ToString();
                   }
               }
               else
               {
                   key.SequenceID = key.SequenceID - 1;
                   order = "第" + num.ToString();                 
               }
               if (arr[0].Contains("章"))
               {
                   key.ChapterName = order + "章" +' ' +arr[1];
               }
               else
               {
                   key.ChapterName = order + "节" +' '+ arr[1];
               }
               servcie.Update(key);
           }
       }

       public int CloneChapter(string courseID)
       {
           int result=0;
           return result;
       }
    }
}
