using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using PLKJDS.BLL.SystemManage;
using PLKJDS.Common;
using PLKJDS.Common.Enums;
using PLKJDS.Entity;
using PLKJDS.UIEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Controllers
{
    public class QsBankController : ControllerBase
    {
        private QsBankApp qsBankApp = new QsBankApp();

        public override ActionResult Index()
        {
            ViewBag.FileServer = ConfigUtility.GetConfigValue("FileServer");
            return View();
        }

        public ActionResult GetGridJsonPage(Pagination pagination, string keyword)
        {
            var list = qsBankApp.Get(pagination, keyword);
            return Content(list.ToJson());
        }

        public ActionResult Add()
        {
            var file = Request.Files[0];
            if (file == null)
            {
                return Error("文件不存在！");
            }
            var qsBankFullDir = Server.MapPath("~/QsBank/");
            if (!Directory.Exists(qsBankFullDir))
            {
                Directory.CreateDirectory(qsBankFullDir);
            }

            var orgFileNameWithoutExt = Path.GetFileNameWithoutExtension(file.FileName);
            var orgFileExt = Path.GetExtension(file.FileName);

            var strFileNameWithoutExt = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var strFileName = string.Format("{0}{1}", strFileNameWithoutExt, orgFileExt);

            try
            {
                file.SaveAs(qsBankFullDir + strFileName);
                qsBankApp.Add(new QsBank_AddParam
                {
                    OrgName = orgFileNameWithoutExt,
                    FileExt = orgFileExt,
                    StrName = strFileNameWithoutExt,
                    FilePath = "/QsBank/"
                });
            }
            catch (Exception)
            {
                return Error("保存失败");
            }
            return Success("保存成功");
        }

        public ActionResult Del(string id)
        {
            var result = qsBankApp.Del(id);
            if (result)
            {
                return Success("操作成功");
            }
            else
            {
                return Error("操作失败");
            }
        }

        public ActionResult MultiDownload()
        {
            var idsStr = Request["idsStr"];
            var ids = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(idsStr);
            var qsBanks = qsBankApp.Get(ids);

            byte[] buffer = null;
            using (var ms = new MemoryStream())
            {
                using (var file = ZipFile.Create(ms))
                {
                    file.BeginUpdate();
                    var myNameTransfom = new MyNameTransfom();
                    file.NameTransform = myNameTransfom;
                    myNameTransfom.RootPath = "";
                    foreach (var qsBank in qsBanks)
                    {
                        myNameTransfom.EntryVirtualPath = qsBank.OrgName + qsBank.FileExt;
                        file.Add(Server.MapPath("~" + qsBank.FilePath + qsBank.StrName + qsBank.FileExt));
                    }
                    file.CommitUpdate();
                    buffer = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(buffer, 0, buffer.Length);
                }
            }

            return File(buffer, "application/x-zip-compressed", HttpUtility.UrlEncode("题库.zip", System.Text.Encoding.UTF8));
        }
    }

    public class MyNameTransfom : INameTransform
    {
        private string _rootPath;
        public string RootPath
        {
            get { return _rootPath; }
            set { _rootPath = value; }
        }
        private string _entryVirtualPath;
        public string EntryVirtualPath
        {
            get { return _entryVirtualPath; }
            set { _entryVirtualPath = value; }
        }

        public string TransformDirectory(string name)
        {
            return TrimStartStr(EntryVirtualPath, _rootPath);
        }

        public string TransformFile(string name)
        {
            return TrimStartStr(EntryVirtualPath, _rootPath);
        }

        public static string TrimEndStr(string str, string trimEndStr)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            if (str.EndsWith(trimEndStr))
            {
                return str.Substring(0, str.Length - trimEndStr.Length);
            }
            return str;
        }

        public static string TrimStartStr(string str, string trimStartStr)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            if (str.StartsWith(trimStartStr))
            {
                return str.Substring(trimStartStr.Length, str.Length - trimStartStr.Length);
            }
            return str;
        }
    }
}