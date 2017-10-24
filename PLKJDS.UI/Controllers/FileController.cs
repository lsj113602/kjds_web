using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.UIBLL;
using PLKJDS.Common;
using System.IO;

namespace PLKJDS.Admin.Controllers
{
    public class FileController : PLKJDS.UI.ControllerBase
    {
        FileApp fileApp = new FileApp();
        // GET: File
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult GetFile(string keyValue)
        {
            var entity = fileApp.GetForm(keyValue);
            string path = FileHelper.MapPath("~") + @"\Image\" + entity.FileName;
            FileStream file = new FileStream(path, FileMode.Open);
            return File(file, FileHelper.GetFileContentType(entity.FileName));
        }


        public ActionResult UploadFile(string keyValue)
        {
            var httpFiles = Request.Files;
            if (httpFiles.Count == 1)
            {
                string path = FileHelper.MapPath("~") + @"\Image\";
                string fileName = CommonUtility.CreateNo() + httpFiles[0].FileName;
                httpFiles[0].SaveAs(path + fileName);
                PLKJDS.Entity.File file = new PLKJDS.Entity.File();
                file.OName = httpFiles[0].FileName;
                file.FileName = fileName;
                file.FilePath = @"\Image\" + fileName;
                file.FileExt = FileHelper.GetExtension(path + fileName);
                file = fileApp.AddFile(file);
                if (file != null)
                {
                    string url = Configs.GetValue("FileService");
                    var data = new
                    {
                        url = url + file.ID,
                        id = file.ID
                    };
                    return Success("上传成功", data);
                }
                return Error("上传失败");
                
            }
            else
            {
                return Error("上传失败");
            }


        }

        private string SaveFile(HttpPostedFileBase fileBase)
        {
            string path = FileHelper.MapPath("~") + @"\Image\";
            string fileName = CommonUtility.CreateNo() + fileBase.FileName;
            fileBase.SaveAs(path + fileName);
            return path + fileName;
        }
    }
}
