using PLKJDS.BLL;
using PLKJDS.Common;
using PLKJDS.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Areas.QuestionsManage.Controllers
{
    public class QuestionsManageController : ControllerBase
    {
        QuestionsManageApp questionsManagaApp = new QuestionsManageApp();
        // GET: QuestionsManage/QuestionsManage
        public ActionResult GetTreeGridJson(Pagination pagination,string keyword,string chapterID)
        {
            var ret = questionsManagaApp.GetQuestionsList(pagination, keyword, chapterID);
            return Content(ret.ToJson());
        }
        public ActionResult ModifyQuestions(QuestionForm form)
        {
            int ret = questionsManagaApp.ModifyQuestions(form);
            if (ret == 1)
            {
                return Success("操作成功");
            }
            return Error("操作失败");
        }
        public ActionResult AddQuestions(QuestionForm form)
        {
            int ret = questionsManagaApp.AddQuestions(form);
            if(ret == 1)
            {
                return Success("操作成功");
            }
            return Error("操作失败");
        }
        public ActionResult DeleteQuestions(QuestionForm form)
        {
            int ret = questionsManagaApp.DeleteQuestions(form);
            if (ret == 1)
            {
                return Success("操作成功");
            }
            return Error("操作失败");
        }
        public ActionResult GetFormJson(QuestionForm form)
        {
            var entity = questionsManagaApp.GetForm(form);
            return Content(entity.ToJson());
        }

        public ActionResult GetChapterInfo(string chapterID)
        {
            var chapterInfo = questionsManagaApp.GetChapterInfo(chapterID);
            return Content(chapterInfo.ToJson());
        }

        public ActionResult GetQuestionType()
        {
            TreeSelectModel mode = new TreeSelectModel();
            mode.id = "1";
            mode.text = "单选题";
            TreeSelectModel mode2 = new TreeSelectModel();
            mode2.id = "2";
            mode2.text = "判断题";
            List<TreeSelectModel> list = new List<TreeSelectModel>();
            list.Add(mode);
            list.Add(mode2);
            return Content(list.ToJson());
        }
    }
}