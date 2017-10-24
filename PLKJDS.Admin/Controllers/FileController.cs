using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.BLL;
using PLKJDS.Common;
using System.IO;

namespace PLKJDS.Admin.Controllers
{
    public class FileController : Controller
    {
        FileApp fileApp = new FileApp();
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFile(string keyValue)
        {
            var entity = fileApp.GetForm(keyValue);
            string path = keyValue;
            if(entity!=null)
            {
               path = FileHelper.MapPath("~") + @"\Image\" + entity.FileName;
            }
            FileStream file = new FileStream(path, FileMode.Open);
            return File(file,FileHelper.GetFileContentType(entity.FileName));
        }
    }
}