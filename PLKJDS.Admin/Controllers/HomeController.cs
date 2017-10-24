using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace PLKJDS.Admin
{
    //[HandlerLogin]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
    }
}
