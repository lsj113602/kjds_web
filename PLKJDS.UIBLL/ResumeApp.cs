using PLKJDS.Common;
using PLKJDS.Common.Enums;
using PLKJDS.Data;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIBLL
{
    public class ResumeApp
    {
        private IRepositoryBase repository = new RepositoryBase();
        private IResumeBaseInfoRepository baseInfoApp = new ResumeBaseInfoRepository();
        private IResumeCerRepository cerApp = new ResumeCerRepository();
        private IResumeEduBackRepository eduBackApp = new ResumeEduBackRepository();
        private IResumeTrainExpRepository trainExpApp = new ResumeTrainExpRepository();
        private IResumeWorkExpRepository workExpApp = new ResumeWorkExpRepository();

        public string AddCv(string userId) 
        {
            var res = baseInfoApp.IQueryable(x => x.UserID == userId).FirstOrDefault();
            if (res == null)
            {
                res = new ResumeBaseInfo { UserID = userId };
                res.ID = CommonUtility.GuId();
                baseInfoApp.Insert(res);                
            }
            return res.ID;
        }

        //保存基本信息
        public string SaveCv(CvModel model)
        {
            ResumeBaseInfo resume = null;

            resume = baseInfoApp.FindEntity(model.Id);
            if (resume == null)
            {
                return resume.ID;
            }

            resume.TrueName = model.Username;
            resume.Gender = model.UserSex;
            resume.Age = model.UserAge;
            resume.Address = model.UserAddress;
            resume.Phone = model.UserTel;
            resume.Email = model.UserEmail;
            resume.HeadPicID = model.Logo;
            resume.Skill = model.SkillContent;
            resume.SelfVal = model.SelfContent;
            baseInfoApp.Update(resume);
            return resume.ID;
        }

        //保存工作经验
        public string SaveExp(ExpModel model)
        {
            var workExp = new resumeworkexp
            {
                ResumeID = model.RId,
                CpyName = model.CpyName,
                Post = model.Post,
                JobDesc = model.JobDesc,
                SDT = model.SDT,
                EDT = model.EDT
            };
            workExp.ID = CommonUtility.GuId();
            workExpApp.Insert(workExp);
            return workExp.ID;
        }
        //删除工作经验
        public bool DelExp(string id)
        {
            var model = workExpApp.FindEntity(id);
            if (model != null)
            {
                workExpApp.Delete(model);
            }
            return true;
        }

        //保存教育背景
        public string SaveEdu(EduModel model)
        {
            var eduback = eduBackApp.IQueryable(x => x.ResumeID == model.RId).FirstOrDefault();
            if (eduback == null)
            {
                eduback = new resumeeduback
                {
                    ResumeID = model.RId,
                    Major = model.Major,
                    School = model.School,
                    SDT = model.SDT
                };
                eduback.ID = CommonUtility.GuId();
                eduBackApp.Insert(eduback);
            }
            else
            {
                eduback.Major = model.Major;
                eduback.School = model.School;
                eduback.SDT = model.SDT;
                eduBackApp.Update(eduback);
            }
            return eduback.ID;
        }

        //保存培训经验
        public string SaveTrain(TraModel model)
        {
            var trainexp = new resumetrainexp
            {
                ResumeID = model.RId,
                CpyName = model.CpyName,
                EDT = model.EDT,
                Post = model.Post,
                SDT = model.SDT,
                TrainDesc = model.TrainDesc
            };
            trainexp.ID = CommonUtility.GuId();
            trainExpApp.Insert(trainexp);
            return trainexp.ID;
        }
        //删除培训经验
        public bool DelTrain(string id)
        {
            var model = trainExpApp.FindEntity(id);
            if (model != null) trainExpApp.Delete(model);
            return true;
        }

        //保存证书
        public string SaveCer(CerModel model)
        {
            var cer = new resumecer
            {
                ResumeID = model.RId,
                Level = model.Level,
                Name = model.Name
            };
            cer.ID = CommonUtility.GuId();
            cerApp.Insert(cer);
            return cer.ID;
        }
        //删除证书
        public bool DelCer(string id)
        {
            var model = cerApp.FindEntity(id);
            if (model != null) cerApp.Delete(model);
            return true;
        }

        //保存专业技能
        public bool SaveSkill(string id, string skillContent)
        {
            var model = baseInfoApp.FindEntity(id);
            if (model != null)
            {
                model.Skill = skillContent;
                baseInfoApp.Update(model);
            }
            return true;
        }

        //保存自我评价
        public bool SaveSelf(string id, string selfContent)
        {
            var model = baseInfoApp.FindEntity(id);
            if (model != null)
            {
                model.SelfVal = selfContent;
                baseInfoApp.Update(model);
            }
            return true;
        }

        /*获取简历*/
        public ResumeModel GetResume(string id)
        {
            var model = new ResumeModel();
            //Cv
            var cv = baseInfoApp.FindEntity(id);
            if (cv != null)
            {
                model.Cv = new CvModel
                {
                    Id = cv.ID,
                    Username = cv.TrueName,
                    UserSex = cv.Gender,
                    UserAge = cv.Age,
                    UserAddress = cv.Address,
                    UserTel = cv.Phone,
                    UserEmail = cv.Email,
                    Logo = cv.HeadPicID,
                    SkillContent = cv.Skill,
                    SelfContent = cv.SelfVal
                };
            }

            string sqlJobExps = @"select ID Id, ResumeID RId, CpyName, JobDesc, Post, SDT, EDT from resumeworkexp where ResumeID=@ResumeID;";
            var paramJobExps = new MySql.Data.MySqlClient.MySqlParameter[] { 
                 new MySql.Data.MySqlClient.MySqlParameter(){ParameterName = "@ResumeID", Value = id}
            };
            model.JobExps = repository.FindList<ExpModel>(sqlJobExps, paramJobExps);
            if (model.JobExps != null)
            {
                model.JobExps.ForEach(x =>
                {
                    x.SDTStr = x.SDT.HasValue ? x.SDT.Value.ToString("yyyy-MM") : "";
                    x.EDTStr = x.EDT.HasValue ? x.EDT.Value.ToString("yyyy-MM") : "";
                });
            }

            //TrainExps
            string sqlTrainExps = @"select ID Id, ResumeID RId, CpyName, TrainDesc, Post, SDT, EDT from resumetrainexp where ResumeID=@ResumeID;";
            var paramTrainExps = new MySql.Data.MySqlClient.MySqlParameter[] { 
                 new MySql.Data.MySqlClient.MySqlParameter(){ParameterName = "@ResumeID", Value = id}
            };
            model.TrainExps = repository.FindList<TraModel>(sqlTrainExps, paramTrainExps);
            if (model.TrainExps != null)
            {
                model.TrainExps.ForEach(x =>
                {
                    x.SDTStr = x.SDT.HasValue ? x.SDT.Value.ToString("yyyy-MM") : "";
                    x.EDTStr = x.EDT.HasValue ? x.EDT.Value.ToString("yyyy-MM") : "";
                });
            }

            //Edu
            string sqledu = @"select ID Id, ResumeID RId, Major, School, SDT from resumeeduback where ResumeID=@ResumeID;";
            var paramedu = new MySql.Data.MySqlClient.MySqlParameter[] { 
                 new MySql.Data.MySqlClient.MySqlParameter(){ParameterName = "@ResumeID", Value = id}
            };
            model.Edu = repository.FindList<EduModel>(sqledu, paramedu).FirstOrDefault();
            if (model.Edu != null)
            {
                model.Edu.SDTStr = model.Edu.SDT.HasValue ? model.Edu.SDT.Value.ToString("yyyy-MM") : "";
            }

            //Cers
            string sqlcers = @"select ID Id, ResumeID RId, Name, Level from resumecer where ResumeID=@ResumeID;";
            var paramcers = new MySql.Data.MySqlClient.MySqlParameter[] { 
                 new MySql.Data.MySqlClient.MySqlParameter(){ParameterName = "@ResumeID", Value = id}
            };
            model.Cers = repository.FindList<CerModel>(sqlcers, paramcers);

            return model;
        }
    }


    public class ResumeModel
    {
        public CvModel Cv { get; set; }
        public List<ExpModel> JobExps { get; set; }
        public List<TraModel> TrainExps { get; set; }
        public EduModel Edu { get; set; }
        public List<CerModel> Cers { get; set; }
    }

    public class CvModel 
    {
        public string Id { get; set; }
        public string Username     {get;set;}
        public string UserSex      {get;set;}
        public int? UserAge      {get;set;}
        public string UserAddress  {get;set;}
        public string UserTel      {get;set;}
        public string UserEmail    {get;set;}
        public string Logo         {get;set;}
        public string SkillContent {get;set;}
        public string SelfContent  {get;set;}
    }

    public class ExpModel 
    {
        public string RId { get; set; }
        public string Id      {get;set;}
        public string CpyName {get;set;}
        public string Post    {get;set;}
        public string JobDesc {get;set;}
        public DateTime? SDT     {get;set;}
        public string SDTStr { get; set; }
        public DateTime? EDT { get; set; }
        public string EDTStr { get; set; }
    }

    public class EduModel 
    {
        public string RId { get; set; }
        public string Id     {get;set;}
        public string School {get;set;}
        public string Major  {get;set;}
        public DateTime? SDT { get; set; }
        public string SDTStr { get; set; }
    }

    public class TraModel 
    {
        public string RId { get; set; }
        public string Id        {get;set;}
        public string CpyName   {get;set;}
        public string Post      {get;set;}
        public string TrainDesc {get;set;}
        public DateTime? SDT { get; set; }
        public string SDTStr { get; set; }
        public DateTime? EDT { get; set; }
        public string EDTStr { get; set; }
    }

    public class CerModel
    {
        public string RId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
    }
}
