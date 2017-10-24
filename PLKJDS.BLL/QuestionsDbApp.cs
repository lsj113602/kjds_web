using PLKJDS.Common;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.BLL
{
    public class QuestionsDbApp
    {
        ICourseChapterRepository courseChapterService = new CourseChapterRepository();
        ICourseRepository courseService = new CourseRepository();
        IChapterQuestionTRRepository questionTRService = new ChapterQuestionTRRepository();
        IChapterQuestionSelectRepository questionSelectService = new ChapterQuestionSelectRepository();


        private List<Course> GetCourseList(Pagination pagination, string keyword)
        {
            var e = ExtLinq.True<Course>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.CourseName.Contains(keyword));
            }
            var list = courseService.FindList(e,pagination);
            return list;
        }

        private List<CourseChapter> GetChapterList(Pagination pagination, string keyword)
        {
            var courseList = GetCourseList(pagination, keyword);
            List<CourseChapter> chapterList = new List<CourseChapter>();
            foreach (var course in courseList)
            {
                var e = ExtLinq.True<CourseChapter>();
                e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
                e = e.And(x => x.CourserID == course.ID);
                var temp = courseChapterService.IQueryable(e);
                chapterList.AddRange(temp);
            }
            return chapterList;
        }


        public List<QuestionsDbModel> GetQuestionsDbList(Pagination pagination, string keyword)
        {
            var chapterList = GetChapterList(pagination, keyword);
            List<QuestionsDbModel> qDbList = new List<QuestionsDbModel>();
            var top = chapterList.Where(x => x.PID == "0").ToList();
            if (top.Count() >= 1)
            {
                //only two level ,filter third level
                List<CourseChapter> tempChapter = new List<CourseChapter>();
                foreach (var item in top)
                {
                    var temp = chapterList.Where(x => x.PID == item.ID).ToList();
                    temp.Add(item);
                    tempChapter.AddRange(temp);
                }
                chapterList = tempChapter;

                foreach (var chapter in chapterList)
                {
                    QuestionsDbModel temp = new QuestionsDbModel();
                    temp.ID = chapter.ID;
                    temp.ChapterName = chapter.ChapterName;
                    temp.CreatorTime = chapter.CreatorTime;
                    temp.PID = chapter.PID;
                    GetSelcetCount(chapter, temp);
                    GetTRCount(chapter, temp);
                    qDbList.Add(temp);
                }
                var pChapter = qDbList.Where(x => x.PID == "0").ToList();
                foreach (var chapter in pChapter)
                {
                    var tempList = qDbList.Where(x => x.PID == chapter.ID);
                    chapter.Selects = tempList.Sum(x => x.Selects);
                    chapter.TRs = tempList.Sum(x => x.TRs);
                }
            }
            
            return qDbList;
        }

        private void GetTRCount(CourseChapter chapter, QuestionsDbModel temp)
        {
            var t = ExtLinq.True<ChapterQuestionTR>();
            t = t.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            t = t.And(x => x.ChapterID == chapter.ID);
            var trList = questionTRService.IQueryable(t);
            if (trList != null)
            {
                temp.TRs = trList.Count();
            }
        }

        private void GetSelcetCount(CourseChapter chapter, QuestionsDbModel temp)
        {
            var s = ExtLinq.True<ChapterQuestionSelect>();
            s = s.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            s = s.And(x => x.ChapterID == chapter.ID);
            var selectList = questionSelectService.IQueryable(s);
            if (selectList != null)
            {
                temp.Selects = selectList.Count();
            }
        }
    }
}
