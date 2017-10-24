using PLKJDS.Data;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.UIEntity;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PLKJDS.BLL.SystemManage
{
    public class TestPaperApp
    {
        private IExaminationPaperRepository service = new ExaminationPaperRepository();
        private IChapterQuestionSelectRepository select_service = new ChapterQuestionSelectRepository();
        private IChapterQuestionTRRepository TF_service = new ChapterQuestionTRRepository();
        private IExaminationPaperDetailRepository detail_service = new ExaminationPaperDetailRepository();
        public List<ExaminationPaper> GetPapersList()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT a.ID, b.CourseName  as CourseID,a.FullMark,a.PassMark,a.QuesetionNum, 
 a.SelectNum,a.TFNum ,a.SelectScore,a.TFScore,a.StatusCode,a.MakingUserID,a.CheckUserId,a.CheckTime ,a.CreatorUserId,a.LastModifyUserId,
a.LastModifyTime,a.DeleteMark,a.DeleteUserId,a.DeleteTime,a.CreatorTime FROM  plkjds.ExaminationPaper as a left join
 plkjds.Course  as b on a.CourseID=b.ID;");
            RepositoryBase db = new RepositoryBase();
            var list = db.FindList<ExaminationPaper>(sb.ToString());
            return list;
        }

        public int CreatePaper(ExaminationPaper paper)
        {
            ExaminationPaper model = new ExaminationPaper();
            model.Create();
            model.CourseID = paper.CourseID;
            model.QuesetionNum = paper.QuesetionNum;
            model.SelectNum = paper.SelectNum;
            model.TFNum = paper.TFNum;
            model.TFScore = paper.TFScore;
            model.SelectScore = paper.SelectScore;
            model.FullMark = paper.FullMark;
            model.PassMark = paper.PassMark;
            model.DeleteMark = false;
  
            int selectscore =paper.SelectScore==null?0:int.Parse(paper.SelectScore);
            int tfscore =paper.TFScore==null?0:int.Parse(paper.TFScore);

            var selectList = select_service.IQueryable().Where(x => x.Score == selectscore && (x.DeleteMark == null ? false : x.DeleteMark) != true).ToList();
            var TFList = TF_service.IQueryable().Where(x => x.Score == tfscore && (x.DeleteMark == null ? false : x.DeleteMark) != true).ToList();
            List<int> SelecltOrders = GetRandom(0, selectList.Count, paper.SelectNum);
            List<int> TFOrders = GetRandom(0, TFList.Count, paper.SelectNum);
            
            for (int i = 0; i < SelecltOrders.Count; i++)
            {
                var index=SelecltOrders[i];
                InsertSelectNum(model.ID, selectList[index].ID,"1");
            }
            for (int j = 0; j < TFOrders.Count; j++)
            {
                var item = TFOrders[j];
                InsertSelectNum(model.ID, TFList[item].ID, "1");
            }
            int result = service.Insert(model);
            return result;
        }

        public int DeleteTestPaper(string keyValue)
        {
            ExaminationPaper TestPaper = service.FindEntity(keyValue);
            if (TestPaper !=null)
            {
                return service.Delete(TestPaper);
            }
            else
            {
                return 0;
            }
        }

        public void InsertSelectNum(string paperID,string QuestionID,string TypeID)
        {
            ExaminationPaperDetail detail = new ExaminationPaperDetail();
            detail.Create();
            detail.PaperID = paperID;
            detail.QuestionID = QuestionID;
            detail.TypeID = TypeID;
            detail.DeleteMark = false;
            detail_service.Insert(detail);
        }

        public  List<int> GetRandom(int minValue, int maxValue, int? count)
        {
            List<int> Numbers = new List<int>();
            //使用Guid.NewGuid().GetHashCode()作为种子，可以确保Random在极短时间产生的随机数尽可能做到不重复   
            Random rand = new Random(123456);
            Console.WriteLine("GUID:" + Guid.NewGuid().GetHashCode());
            int item;
            for (int i = minValue; i < maxValue; i++)//
            {
                item = rand.Next(minValue, maxValue + 1);
                while (Numbers.IndexOf(item) != -1)
                {
                    item = rand.Next(minValue, maxValue + 1);
                }
                Numbers.Add(item);
                if (Numbers.Count >= count)
                    break;

            }

            return Numbers;
        }


        public int GetSelectNum(string courseID)
        {
            int sum = select_service.IQueryable().Where(x => x.CourserID == courseID && (x.DeleteMark == null ? false : x.DeleteMark) != true).ToList().Count;
            return sum;
        }

        public int GetTFNum(string courseID)
        {
            int sum = TF_service.IQueryable().Where(x => x.CourserID == courseID).ToList().Count;
            return sum;
        }

        #region 获取试卷
        public ExaminationPaperModel GetPaperModelList(string paperID)
        {
            var paper = GetPapersList().Where(p => p.ID == paperID).FirstOrDefault();
            StringBuilder sb = new StringBuilder();
            StringBuilder gsb = new StringBuilder();
            sb.Append(@"SELECT distinct  b.*  FROM plkjds.ExaminationPaperDetail   as  a 
            left join plkjds.ChapterQuestionSelect b on a.QuestionID=b.ID where a.TypeID=1 and a.PaperID=@paperid");
            gsb.Append(@"SELECT distinct  b.*  FROM plkjds.ExaminationPaperDetail   as  a 
            left join plkjds.ChapterQuestionTR b on a.QuestionID=b.ID where a.TypeID=1 and a.PaperID=@paperid");
            RepositoryBase db = new RepositoryBase();
            MySqlParameter[] selectparam = new MySqlParameter[] { new MySqlParameter("@paperid", paperID)};
            var selectlist = db.FindList<ChapterQuestionSelect>(sb.ToString(), selectparam);
            var TRlist = db.FindList<ChapterQuestionTR>(sb.ToString(), selectparam);
            ExaminationPaperModel model = new ExaminationPaperModel();
            if(paper!=null)
            {
                model.ID = paper.ID;
                model.CourseName = paper.CourseID;
                model.FullMark = paper.FullMark;
                model.PassMark = paper.PassMark;
                model.QuestionSum = paper.QuesetionNum;
                model.SelectNum = paper.SelectNum;
                model.TFNum = paper.TFNum;
                model.selectList = selectlist;
                model.TRList = TRlist;
            }
            return model;
        }
        #endregion
    }    
}
