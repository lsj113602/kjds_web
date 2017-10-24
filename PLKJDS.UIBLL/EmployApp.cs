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
    public class EmployApp
    {
        private IRepositoryBase repository = new RepositoryBase();
        private IJobapplicationRepository jobappRepository = new JobapplicationRepository();

        public JobConModel GetJobCon()
        {
            string sqlPost = @"SELECT ID Id, PosName `Name` FROM employposition where DeleteMark<>1 order by SortCode;";
            string sqlType = @"SELECT ID Id, TypeName `Name` FROM employtype where DeleteMark<>1;";
            string sqlArea = @"SELECT ID Id, AreaName `Name` FROM area where DeleteMark<>1;";
            var posts = repository.FindList<IdNameModel>(sqlPost);
            var types = repository.FindList<IdNameModel>(sqlType);
            var areas = repository.FindList<IdNameModel>(sqlArea);

            return new JobConModel { JobPosts = posts, JobTypes = types, JobAreas = areas };
        }

        public JobsModel GetJobs(string jobPostId, string jobTypeId, string jobAreaId, int pageNo, int pageSize)
        {
            string sql = @"select
	emp.Id, 
	post.PosName `Name`, 
	ety.`Name` `Type`, 
    emp.TypeID TypeId, 
    emp.AreaID AreaId,
    emp.PostID PostId,
	emp.Cpy, 
	emp.Address, 
	emp.Count, 
	emp.PublishTime, 
	emp.Pay 
from
(select ID Id, TypeID, AreaID, Title PostID, CompanyName Cpy, Address, PeopleCount Count, PublishTime,Salary Pay from employ where DeleteMark<>1) emp
left join (select ID, PosName from employposition) post on post.ID=emp.PostID
left join (select ID Id, TypeName `Name` from employtype where DeleteMark<>1) ety on ety.Id=emp.TypeID";

            var pre = ExtLinq.True<JobModel>();
            if (!string.IsNullOrEmpty(jobPostId))
            {
                pre = pre.And(x => x.PostId==jobPostId.ToLower());
            }
            if (!string.IsNullOrEmpty(jobTypeId))
            {
                pre = pre.And(x => x.TypeId==jobTypeId.ToLower());
            }
            if (!string.IsNullOrEmpty(jobAreaId))
            {
                pre = pre.And(x => x.AreaId==jobAreaId.ToLower());
            }
            var page = new Pagination { page = pageNo, rows = pageSize, sidx = "PublishTime", sord = "desc" };
            var list = repository.FindList<JobModel>(pre, sql, page);
            if (list != null)
            {
                list.ForEach(x => { x.PubDT = x.PublishTime.HasValue ? x.PublishTime.Value.ToString("yyyy-MM-dd") : ""; });
            }
            var model = new JobsModel { List = list, TotalPage = page.total, TotalRecord = page.records };
            return model;
        }

        public JobDtlModel GetJob(string id)
        {
            string sqlJobMain = @"select 		
                    employ.Title `Name`,
			        employ.Salary Pay,
			        area.AreaName Address,
			        employ.WorkExperience Exp,
			        employ.EduRequire Edu,
			        employtype.TypeName `Type`,
			        employ.PublishTime,
                    employ.TypeID, employ.AreaID, employ.Title PostID
                from employ
                left join employtype on employtype.ID=employ.TypeID
                left join area on area.ID=employ.AreaID
                where employ.ID=@id";

            string sqlJobDetail = @"select 
			        EmployAtract Tempt,
			        EmployDesc `Desc`,
			        Address
                from employ where ID=@id";

            string sqlJobCpy = @"select 
	                employ.CompanyName `Name`, 
                    inddic.`Name` Ind, 
                    organize.OrgProp Nature, 
                    scaledic.`Name` Scale, 
                    organize.OffSite 
                from employ
                left join organize on organize.ID=employ.OrgUserID
                left join (select * from dic where PID =(select ID from dic where `Name`='industry')) inddic on inddic.ID=organize.IndID
                left join (select * from dic where PID =(select ID from dic where `Name`='scale')) scaledic on scaledic.ID=organize.ScaleID
                where employ.ID=@id";

            var paramters1 = new MySql.Data.MySqlClient.MySqlParameter[] { 
                 new MySql.Data.MySqlClient.MySqlParameter(){ParameterName = "@id", Value = id}
            };

            var jobMain = repository.FindList<JobMainModel>(sqlJobMain, paramters1).FirstOrDefault();
            if (jobMain != null)
            {
                jobMain.PubDT = jobMain.PublishTime.HasValue ? jobMain.PublishTime.Value.ToString("yyyy-MM-dd") : "";
            }

            var jobDetail = repository.FindList<JobDetailModel>(sqlJobDetail, paramters1).FirstOrDefault();

            var jobCpy = repository.FindList<JobCpyModel>(sqlJobCpy, paramters1).FirstOrDefault();
            var orgProps = EnumExt.GetEnumList<OrgProp>();
            if (jobCpy != null && orgProps != null)
            {
                jobCpy.Nature = orgProps.Where(x => x.id == jobCpy.Nature).Select(x => x.text).FirstOrDefault();
            }

            string sqlSimilarJob = @"select employ.ID Id, organize.LogoID ImgSrc, post.PosName `Name`, employ.Salary Pay, employ.CompanyName CpyName, employ.Address from employ
left join (select ID, PosName from employposition) post on post.ID=employ.Title
left join organize on organize.ID=employ.OrgUserID where employ.DeleteMark<>1 and employ.TypeID=@TypeID and employ.AreaID=@AreaID and employ.Title=@PostID;";

            var paramters2 = new MySql.Data.MySqlClient.MySqlParameter[] { 
                 new MySql.Data.MySqlClient.MySqlParameter(){ParameterName = "@TypeID", Value = jobMain.TypeID},
                 new MySql.Data.MySqlClient.MySqlParameter(){ParameterName = "@AreaID", Value = jobMain.AreaID},
                 new MySql.Data.MySqlClient.MySqlParameter(){ParameterName = "@PostID", Value = jobMain.PostID}
            };
            var similarJobs = repository.FindList<SimilarJobModel>(sqlSimilarJob, paramters2);

            var model = new JobDtlModel() { JobMain = jobMain, JobDetail = jobDetail, JobCpy = jobCpy, SimilarJobs = similarJobs };
            return model;
        }

        public bool ApplyJob(string userId, string jobId) 
        {
            var job = jobappRepository.FindEntity(x => x.UserID == userId && x.EmployID == jobId);
            if (job == null)
            {
                var model = new Jobapplication { EmployID = jobId, UserID=userId, ApplyTime=DateTime.Now };
                model.ID = CommonUtility.GuId();
                jobappRepository.Insert(model);
            }
            return true;
        }
    }

    public class IdNameModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class JobConModel
    {
        public List<IdNameModel> JobPosts { get; set; }
        public List<IdNameModel> JobTypes { get; set; }
        public List<IdNameModel> JobAreas { get; set; }
    }
    public class JobModel
    {
        public string Id { get; set; }
        public string Name { get; set; }//市场推广,
        public string TypeId { get; set; }
        public string Type { get; set; }//兼职, 
        public string PostId { get; set; }
        public string AreaId { get; set; }
        public string Cpy { get; set; }//湖南纽曼数码科技有限公司, 
        public string Address { get; set; }//工作地点, 
        public string Count { get; set; }//招聘人数, 
        public DateTime? PublishTime { get; set; }
        public string PubDT { get; set; }//发布时间, 
        public string Pay { get; set; }//薪资
    }
    public class JobsModel
    {
        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
        public List<JobModel> List { get; set; }
    }

    public class JobDtlModel
    {
        public JobMainModel JobMain { get; set; }
        public JobDetailModel JobDetail { get; set; }
        public JobCpyModel JobCpy { get; set; }
        public List<SimilarJobModel> SimilarJobs { get; set; }
    }
    public class JobMainModel
    {
        public string Name { get; set; }
        public string Pay { get; set; }
        public string Address { get; set; }
        public string Exp { get; set; }
        public string Edu { get; set; }
        public string Type { get; set; }
        public DateTime? PublishTime{ get; set; }
        public string PubDT { get; set; }

        public string TypeID { get; set; }
        public string PostID { get; set; }
        public string AreaID { get; set; }
    }
    public class JobDetailModel
    {
        public string Tempt { get; set; }
        public string Desc { get; set; }
        public string Address { get; set; }
    }
    public class JobCpyModel
    {
        public string Name { get; set; }
        public string Ind { get; set; }
        public string Nature { get; set; }
        public string Scale { get; set; }
        public string OffSite { get; set; }
    }
    public class SimilarJobModel
    {
        public string Id { get; set; }
        public string ImgSrc { get; set; }
        public string Name { get; set; }
        public string Pay { get; set; }
        public string CpyName { get; set; }
        public string Address { get; set; }
    }
}
