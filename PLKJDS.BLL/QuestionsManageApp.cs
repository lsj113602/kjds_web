using PLKJDS.Common;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PLKJDS.BLL
{
    public class QuestionsManageApp
    {
        ICourseChapterRepository courseChapterService = new CourseChapterRepository();
        IChapterQuestionSelectRepository questionSelectService = new ChapterQuestionSelectRepository();
        IChapterQuestionTRRepository questionTRService = new ChapterQuestionTRRepository();
        public List<QuestionForm> GetQuestionsList(Pagination pagination, string keyword, string chapterID)
        {
            var selectList = GetQSelectList(keyword, chapterID);
            var trList = GetQTRList(keyword, chapterID);
            List<QuestionForm> qFormList = new List<QuestionForm>();
            qFormList.AddRange(QSelectToQFormList(selectList));
            qFormList.AddRange(QTRToQFormList(trList));
            qFormList = ListQuestionFormPage(qFormList, pagination);
            return qFormList;
        }

        public QuestionForm GetForm(QuestionForm form)
        {
            if (form.QuestionType == "1")
            {
                var entity = GetSelectEntity(form.KeyValue);
                if (entity != null)
                {
                    return QSelectToQForm(entity);
                }
            }
            else
            {
                var entity = GetTREntity(form.KeyValue);
                if (entity != null)
                {
                    return QTRToQForm(entity);
                }
            }
            return null;
        }

        private ChapterQuestionSelect GetSelectEntity(string keyValue)
        {
            return questionSelectService.FindEntity(keyValue);
        }

        private ChapterQuestionTR GetTREntity(string keyValue)
        {
            return questionTRService.FindEntity(keyValue);
        }

        private List<QuestionForm> ListQuestionFormPage(List<QuestionForm> qFormList, Pagination pagination)
        {
            bool isAsc = pagination.sord.ToLower() == "asc" ? true : false;
            string[] _order = pagination.sidx.Split(',');
            MethodCallExpression resultExp = null;
            var tempData = qFormList.AsQueryable();
            foreach (string item in _order)
            {
                string _orderPart = item;
                _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                string[] _orderArry = _orderPart.Split(' ');
                string _orderField = _orderArry[0];
                bool sort = isAsc;
                if (_orderArry.Length == 2)
                {
                    isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                }
                var parameter = Expression.Parameter(typeof(QuestionForm), "t");
                var property = typeof(QuestionForm).GetProperty(_orderField);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(QuestionForm), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
            }
            tempData = tempData.Provider.CreateQuery<QuestionForm>(resultExp);
            pagination.records = tempData.Count();
            tempData = tempData.Skip<QuestionForm>(pagination.rows * (pagination.page - 1)).Take<QuestionForm>(pagination.rows).AsQueryable();
            return tempData.ToList();
        }

        private List<QuestionForm> QSelectToQFormList(List<ChapterQuestionSelect> qselectList)
        {
            List<QuestionForm> qFormList = new List<QuestionForm>();
            foreach (var qselect in qselectList)
            {
                QuestionForm temp = QSelectToQForm(qselect);
                qFormList.Add(temp);
            }
            return qFormList;
        }

        private List<QuestionForm> QTRToQFormList(List<ChapterQuestionTR> qselectList)
        {
            List<QuestionForm> qFormList = new List<QuestionForm>();
            foreach (var qtr in qselectList)
            {
                QuestionForm temp = QTRToQForm(qtr);
                qFormList.Add(temp);
            }
            return qFormList;
        }

        private static QuestionForm QTRToQForm(ChapterQuestionTR qtr)
        {
            QuestionForm temp = new QuestionForm();
            temp.ID = qtr.ID;
            temp.ChapterID = qtr.ChapterID;
            temp.CourseID = qtr.CourserID;
            temp.QuestionType = "2";
            temp.Score = qtr.Score.Value;
            temp.TRAnswer = qtr.Answer.Value;
            temp.QName = qtr.QName;
            temp.UserID = qtr.CreatorUserId;
            temp.CreatorTime = qtr.CreatorTime;
            return temp;
        }

        private static QuestionForm QSelectToQForm(ChapterQuestionSelect qselect)
        {
            QuestionForm temp = new QuestionForm();
            temp.ID = qselect.ID;
            temp.ChapterID = qselect.ChapterID;
            temp.CourseID = qselect.CourserID;
            temp.QName = qselect.QName;
            temp.QuestionType = "1";
            temp.Score = qselect.Score.Value;
            temp.SelectAnswer = qselect.Answer;
            temp.SelectA = qselect.SelectA;
            temp.SelectB = qselect.SelectB;
            temp.SelectC = qselect.SelectC;
            temp.SelectD = qselect.SelectD;
            temp.UserID = qselect.CreatorUserId;
            temp.CreatorTime = qselect.CreatorTime;
            return temp;
        }

        private List<ChapterQuestionSelect> GetQSelectList(string keyword, string chapterID)
        {
            var e = ExtLinq.True<ChapterQuestionSelect>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            e = e.And(x => x.ChapterID == chapterID);
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.QName.Contains(keyword));
            }
            return questionSelectService.IQueryable(e).ToList();
        }
        private List<ChapterQuestionTR> GetQTRList(string keyword, string chapterID)
        {
            var e = ExtLinq.True<ChapterQuestionTR>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            e = e.And(x => x.ChapterID == chapterID);
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.QName.Contains(keyword));
            }
            return questionTRService.IQueryable(e).ToList();
        }



        public int AddQuestions(QuestionForm form)
        {
            int ret = 0;
            if (form.QuestionType == "1")
            {
                ChapterQuestionSelect qselect = FormToQSelect(form);
                ret = AddSelectQuestions(qselect);
            }
            else
            {
                ChapterQuestionTR qtr = FormToTR(form);
                ret = AddTRQuestions(qtr);
            }
            return ret;
        }

        private ChapterQuestionTR FormToTR(QuestionForm form)
        {
            ChapterQuestionTR qtr = new ChapterQuestionTR();
            qtr.ID = form.KeyValue;
            qtr.Answer = form.TRAnswer;
            qtr.ChapterID = form.ChapterID;
            qtr.CourserID = form.CourseID;
            qtr.Score = form.Score;
            qtr.QName = form.QName;
            return qtr;
        }

        private ChapterQuestionSelect FormToQSelect(QuestionForm form)
        {
            ChapterQuestionSelect qselect = new ChapterQuestionSelect();
            qselect.ID = form.KeyValue;
            qselect.Answer = form.SelectAnswer;
            qselect.ChapterID = form.ChapterID;
            qselect.CourserID = form.CourseID;
            qselect.Score = form.Score;
            qselect.QName = form.QName;
            qselect.SelectA = form.SelectA;
            qselect.SelectB = form.SelectB;
            qselect.SelectC = form.SelectC;
            qselect.SelectD = form.SelectD;
            return qselect;
        }

        public int ModifyQuestions(QuestionForm form)
        {
            int ret = 0;
            if (form.QuestionType == "1")
            {
                ChapterQuestionSelect qselect = FormToQSelect(form);
                ret = ModifySelectQuestions(qselect);
            }
            else
            {
                ChapterQuestionTR qtr = FormToTR(form);
                ret = ModifyTRQuestions(qtr);
            }
            return ret;
        }
        public int DeleteQuestions(QuestionForm form)
        {
            int ret = 0;
            if (form.QuestionType == "1")
            {
                ChapterQuestionSelect qselect = FormToQSelect(form);
                ret = DeleteSelectQuestions(qselect);
            }
            else
            {
                ChapterQuestionTR qtr = FormToTR(form);
                ret = DeleteTRQuestions(qtr);
            }
            return ret;
        }


        private int AddSelectQuestions(ChapterQuestionSelect qselect)
        {
            qselect.Create();
            return questionSelectService.Insert(qselect);
        }

        private int ModifySelectQuestions(ChapterQuestionSelect qselect)
        {
            qselect.Modify(qselect.ID);
            return questionSelectService.Update(qselect);
        }

        private int DeleteSelectQuestions(ChapterQuestionSelect qselect)
        {
            qselect.Remove();
            return questionSelectService.Update(qselect);
        }
        private int AddTRQuestions(ChapterQuestionTR qtr)
        {
            qtr.Create();
            return questionTRService.Insert(qtr);
        }

        private int ModifyTRQuestions(ChapterQuestionTR qtr)
        {
            qtr.Modify(qtr.ID);
            return questionTRService.Update(qtr);
        }

        private int DeleteTRQuestions(ChapterQuestionTR qtr)
        {
            qtr.Remove();
            return questionTRService.Update(qtr);
        }

        public ChapterInfoModel GetChapterInfo(string chapterId)
        {
            ChapterInfoModel model = new ChapterInfoModel();
            var chapter = courseChapterService.FindEntity(chapterId);
            if (chapter != null)
            {
                var e = ExtLinq.True<CourseChapter>();
                //e = e.And (x =>(x.DeleteMark == null ? false:x.DeleteMark)!= true);
                e = e.And(x => x.ID == chapter.PID);
                var course = courseChapterService.FindEntity(e);
                model.ID = chapter.ID;
                model.CourseID = course.CourserID;
                model.ChapterName = chapter.ChapterName;
                model.CourseName = course.ChapterName;
            }
            return model;
        }
    }
}
