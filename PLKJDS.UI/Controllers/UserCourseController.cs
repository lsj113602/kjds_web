using PLKJDS.Common;
using PLKJDS.UIBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.UI.Controllers
{
    [HandlerLogin]
    public class UserCourseController : ControllerBase
    {
        //
        // GET: /UserCenter/
        public override ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCourses(string state, int pageNo, int pageSize) 
        {
            var userId = OperatorProvider.Provider.GetCurrent().UserId;
            //Id, Logo, Name, School, Teacher, Desc
            var data = new UserCourseApp().Get(userId, state, pageNo, pageSize);
            return Success(null, data);
        }
	}
}