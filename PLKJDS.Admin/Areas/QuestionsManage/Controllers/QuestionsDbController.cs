using PLKJDS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.BLL;
namespace PLKJDS.Admin.Areas.QuestionsManage.Controllers
{
    public class QuestionsDbController : ControllerBase
    {
        private AuthorizeApp authorizeApp = new AuthorizeApp();
        private QuestionsDbApp questionDbApp = new QuestionsDbApp();
        // GET: QuestionsManage/QuestionsDb
        public ActionResult GetTreeGridJson(Pagination pagination, string keyword)
        {
            var list = questionDbApp.GetQuestionsDbList(pagination,keyword);
            var treeList = new List<TreeGridModel>();
            foreach (var item in list)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = list.Count(t => t.PID == item.ID) == 0 ? false : true;
                treeModel.id = item.ID;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.PID;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }
    }
}