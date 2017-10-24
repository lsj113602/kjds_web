using MySql.Data.MySqlClient;
using PLKJDS.Data;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.BLL.SystemManage
{
    public class ChapterContentApp
    {
        private IChapterContentRepository service = new ChapterContentRepository();


        public int AddChapterContent(ChapterContent chaptercontent)
        {
            int result = 0;
            ChapterContent model = new ChapterContent();
            model.Create();
            model.ChapterID = chaptercontent.ChapterID;
            model.CourserID = chaptercontent.CourserID;
            model.FileID = chaptercontent.FileID;
            model.TypeID = chaptercontent.TypeID;
            result = service.Insert(model);
            return result;
        }

        public List<ChapterContentModel> GetListByCourseID(string keyValue)
        {
            List<ChapterContentModel> list = new List<ChapterContentModel>();
           StringBuilder sb = new StringBuilder();
           sb.Append(@"SELECT  c.ID, c.CourserID, c.FileID,c.TypeID,c.CreatorUserId,c.CreatorTime,
            c.ChapterName,d.ChapterName as PChapterName from(SELECT a.ID, a.CourserID, a.FileID,
            a.TypeID,a.CreatorUserId,a.CreatorTime,b.ChapterName,b.PID  FROM plkjds.ChapterContent 
            as a left join plkjds.CourseChapter as b on a.ChapterID =b.ID) c left join plkjds.CourseChapter 
            as d on c.PID = d.ID");
           //MySqlParameter[] courseparam = new MySqlParameter[] { new MySqlParameter("@courserID", keyValue) };
           IRepositoryBase db = new RepositoryBase();
           //list = db.FindList<ChapterContentModel>(sb.ToString(), courseparam);
           list = db.FindList<ChapterContentModel>(sb.ToString());
           list = list.Where(x => x.CourserID == keyValue).ToList();
           foreach(ChapterContentModel item in list)
           {
               item.SumChapterName = item.PChapterName + "/" + item.ChapterName;
           }
           return list;
        }
    }
}
