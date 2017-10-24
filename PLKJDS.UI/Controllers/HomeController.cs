using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using PLKJDS.UIBLL;
using PLKJDS.Common;
using PLKJDS.Entity;
using PLKJDS.UIEntity.UI;

namespace PLKJDS.UI
{
    //[HandlerLogin]
    public class HomeController : Controller
    {
        CourseApp courseApp = new CourseApp();
        TrainApp trainBll = new TrainApp();
        public ActionResult Index()
        {
            List<CourseModel> courseList=courseApp.FindByPartNumber();
            List<TrainInfo> trainList=trainBll.FindBystarttime();
            ViewBag.trainList = trainList;
            ViewBag.courseList = courseList;
            return View();
        }
        public ActionResult Default()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult GetEmployPositionList()
        {
            TestClass test = new TestClass();
            
            return Content(test.GetEmployPositionList().ToJson());
        }
    }
}
