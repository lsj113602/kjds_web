using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.Common;
using PLKJDS.UIEntity.UI;
using PLKJDS.UIBLL;
using System.IO;

namespace PLKJDS.UI.Areas.Course.Controllers
{
    public class QsBankPageController : ControllerBase
    {
        public override ActionResult Index() 
        {
            ViewBag.FileServer = ConfigUtility.GetConfigValue("FileServer");
            ViewBag.QsBankUrl = ConfigUtility.GetConfigValue("QsBankUrl");
            return View();
        }
        public ActionResult GetQsBanks(string key, int pageNo, int pageSize)
        {
            var data = new QsBankApp().GetQsBanks(key, pageNo, pageSize);
            return Success(null, data);
        }



    }
}