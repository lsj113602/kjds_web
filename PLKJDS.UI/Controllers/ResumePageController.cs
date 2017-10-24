using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLKJDS.Common;
using PLKJDS.UIEntity.UI;
using PLKJDS.UIBLL;
using System.IO;
using Aspose.Words;
using System.Text;

namespace PLKJDS.UI.Areas.Course.Controllers
{
    [HandlerLogin]
    public class ResumePageController : ControllerBase
    {
        public override ActionResult Index() 
        {
            var userId = OperatorProvider.Provider.GetCurrent().UserId;
            var resumeID = new ResumeApp().AddCv(userId);//"faa2d2a1-bc9b-427a-bbc1-c5986909683e"
            ViewBag.Id = resumeID;
            return View();
        }

        public ActionResult Detail() 
        {
            var userId = OperatorProvider.Provider.GetCurrent().UserId;
            var resumeID = new ResumeApp().AddCv(userId);//"faa2d2a1-bc9b-427a-bbc1-c5986909683e"
            ViewBag.Id = resumeID;
            return View();
        }
        
        //保存基本信息 Id Username UserSex UserAge UserAddress UserTel UserEmail Logo
        public ActionResult SaveCv(CvModel model)
        {
            new ResumeApp().SaveCv(model);
            return Success(null);
        }

        //保存工作经验 CpyName Post JobDesc SDT EDT
        public ActionResult SaveExp(ExpModel model)
        {
            var id = new ResumeApp().SaveExp(model);
            return Success(null, new { Id = id });
        }
        //删除工作经验 Id
        public ActionResult DelExp(string id)
        {
            new ResumeApp().DelExp(id);
            return Success(null);
        }

        //保存教育背景 School Major SDT
        public ActionResult SaveEdu(EduModel model)
        {
            var id = new ResumeApp().SaveEdu(model);
            return Success(null, new { Id = id });
        }

        //保存培训经验 CpyName Post TrainDesc SDT EDT
        public ActionResult SaveTrain(TraModel model)
        {
            var id = new ResumeApp().SaveTrain(model);
            return Success(null, new { Id = id });
        }
        //删除培训经验 Id
        public ActionResult DelTrain(string id)
        {
            new ResumeApp().DelTrain(id);
            return Success(null);
        }

        //保存证书 Name Level
        public ActionResult SaveCer(CerModel model)
        {
            var id = new ResumeApp().SaveCer(model);
            return Success(null, new { Id = id });
        }
        //删除证书 Id
        public ActionResult DelCer(string id)
        {
            new ResumeApp().DelCer(id);
            return Success(null);
        }

        //保存专业技能 SkillContent
        public ActionResult SaveSkill(string id, string skillContent)
        {
            new ResumeApp().SaveSkill(id, skillContent);
            return Success(null);
        }

        //保存自我评价 SelfContent
        public ActionResult SaveSelf(string id, string selfContent)
        {
            new ResumeApp().SaveSelf(id, selfContent);
            return Success(null);
        }

        /*获取简历
         UserInfo:null, JobExps:null, TrainExps:null, Edu:null, Cers:null
         Username，UserSex，UserAge，UserAddress，UserTel，UserEmail，Logo SkillContent SelfContent
         Id, CpyName Post JobDesc SDT EDT
         Id CpyName Post TrainDesc SDT EDT
         School，Major，SDT
         Id Name Level
         */ 
        public ActionResult GetResume(string id)
        {
            var data = new ResumeApp().GetResume(id);
            return Success(null, data);
        }


        public ActionResult Export(string id) 
        {
            var data = new ResumeApp().GetResume(id);

            var tpFilePath = Server.MapPath("~/Content/ResumeTemp.html");
            
            var resumeTp = "";
            using (var sr = new StreamReader(tpFilePath))
            {
                resumeTp = sr.ReadToEnd();
            }

            if (data.Cv != null)
            {
                var entity = new FileApp().GetForm(data.Cv.Logo);
                string path = Server.MapPath("~/Image/") + entity.FileName;

                resumeTp = resumeTp.Replace("[#cvUsername#]", data.Cv.Username)
                    .Replace("[#cvUserSex#]", data.Cv.UserSex)
                    .Replace("[#cvUserAge#]", data.Cv.UserAge.HasValue?data.Cv.UserAge.ToString():"")
                    .Replace("[#cvUserAddress#]", data.Cv.UserAddress)
                    .Replace("[#cvUserTel#]", data.Cv.UserTel)
                    .Replace("[#cvUserEmail#]", data.Cv.UserEmail)
                    .Replace("[#cvSkill#]", data.Cv.SkillContent)
                    .Replace("[#cvSelf#]", data.Cv.SelfContent)
                    .Replace("[#cvUserLogo#]", path);
            }

            if (data.Edu != null)
            {
                resumeTp = resumeTp.Replace("[#eduSchool#]", data.Edu.School)
                    .Replace("[#eduMajor#]", data.Edu.Major)
                    .Replace("[#eduSDT#]", data.Edu.SDTStr);
            }

            var jobExpTp = "<table>"
                + "	<tr><td class=\"font18 width400\">[#CpyName#]</td><td>[#SDT#] ~ [#EDT#]</td></tr>"
                + "	<tr><td colspan=\"2\"><span>职务：[#Post#]</span></td></tr>"
                + "	<tr><td colspan=\"2\"><span>工作内容：[#JobDesc#]</span></td></tr>"
                + "</table>";
            if (data.JobExps != null)
            {
                List<string> jobExps = new List<string>();
                data.JobExps.ForEach(x=>{
                    var temp = jobExpTp.Replace("[#CpyName#]", x.CpyName)
                        .Replace("[#SDT#]", x.SDTStr)
                        .Replace("[#EDT#]", x.EDTStr)
                        .Replace("[#Post#]", x.Post )
                        .Replace("[#JobDesc#]", x.JobDesc);
                    jobExps.Add(temp);
                });
                resumeTp = resumeTp.Replace("[#cvJobExp#]", string.Join("", jobExps.ToArray()));
            }

            var trainExpTp = "<table>"
                + "	<tr><td class=\"font18 width400\">[#CpyName#]</td><td>[#SDT#] ~ [#EDT#]</td></tr>"
                + "	<tr><td colspan=\"2\"><span>培训岗位：[#Post#]</span></td></tr>"
                + "	<tr><td colspan=\"2\"><span>培训内容：[#TrainDesc#]</span></td></tr>"
			    +"</table>";
            if (data.TrainExps != null)
            {
                List<string> trainExps = new List<string>();
                data.TrainExps.ForEach(x =>
                {
                    var temp = trainExpTp.Replace("[#CpyName#]", x.CpyName)
                        .Replace("[#SDT#]", x.SDTStr)
                        .Replace("[#EDT#]", x.EDTStr)
                        .Replace("[#Post#]", x.Post)
                        .Replace("[#TrainDesc#]", x.TrainDesc);
                    trainExps.Add(temp);
                });
                resumeTp = resumeTp.Replace("[#cvTrainExp#]", string.Join("", trainExps.ToArray()));
            }

            var cerTp = "<table>"
            + "    <tr><td class=\"width400\">[#Name#]</td><td>[#Level#]</td></tr>"
            + "</table>";
            if (data.Cers != null)
            {
                List<string> cers = new List<string>();
                data.Cers.ForEach(x =>
                {
                    var temp = cerTp.Replace("[#Name#]", x.Name)
                        .Replace("[#Level#]", x.Level);
                    cers.Add(temp);
                });
                resumeTp = resumeTp.Replace("[#cvCer#]", string.Join("", cers.ToArray()));
            }

            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.InsertHtml(resumeTp);

            byte[] buffer = null;
            using (var ms = new MemoryStream())
            {
                doc.Save(ms, SaveFormat.Doc);
                buffer = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
            }
            return File(buffer, "application/x-zip-compressed", HttpUtility.UrlEncode("我的简历.doc", Encoding.UTF8));
        }

    }
}