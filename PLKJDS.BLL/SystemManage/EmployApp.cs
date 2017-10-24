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

namespace PLKJDS.BLL.SystemManage
{
    public class EmployApp
    {
        private IEmployRepository service = new EmployRepository();
        private IEmployPartRepository employPartService = new EmployPartRepository();
        private IRepositoryBase repository = new RepositoryBase();
        public List<Employ> GetEmployList()
        {
            var list = service.IQueryable().Where(x => x.DeleteMark == null ? false : x.DeleteMark != true).ToList();
            return list;
        }

        public int AddOrUpdateEmploy(Employ employ, string keyValue)
        {
            int result = 0;
            if (string.IsNullOrEmpty(keyValue))
            {
                Employ model = new Employ();
                model.Create();
                model.CompanyName = employ.CompanyName;
                model.Address = employ.Address;
                model.Salary = employ.Salary;
                model.PeopleCount = employ.PeopleCount;
                model.JobResp = employ.JobResp;



                model.Title = employ.Title;
                model.EduRequire = employ.EduRequire;
                model.EmployAtract = employ.EmployAtract;
                model.EmployDesc = employ.EmployDesc;
                model.TypeID = employ.TypeID;
                model.WorkExperience = employ.WorkExperience;
                model.DeleteMark = false;
                model.PublishTime = employ.PublishTime;
                model.StatusCode = EmployStatu.PendingApproval.GetEnumNote();
                result = service.Insert(model);
            }
            else
            {
                Employ model = service.FindEntity(keyValue);
                model.CompanyName = employ.CompanyName;
                model.Address = employ.Address;
                model.Salary = employ.Salary;
                model.PeopleCount = employ.PeopleCount;
                model.JobResp = employ.JobResp;
                model.Title = employ.Title;
                model.EduRequire = employ.EduRequire;
                model.EmployAtract = employ.EmployAtract;
                model.EmployDesc = employ.EmployDesc;
                model.TypeID = employ.TypeID;
                model.WorkExperience = employ.WorkExperience;
                model.DeleteMark = false;
                model.PublishTime = employ.PublishTime;
                result = service.Update(model);
            }
            return result;
        }

        public int DeleteEmploy(string keyValue)
        {
            var model = service.FindEntity(keyValue);
            model.DeleteMark = true;
            int res = service.Update(model);
            return res;
        }

        public Employ GetForm(string keyValue)
        {
            var model = service.FindEntity(keyValue);
            return model;
        }


        public object GetEmployPartnerList(string keyword,string keyValue, Pagination pagination)
        {
            string sql =
                @"SELECT epart.id,epart.EmployID,employ.Title,employ.TypeID,epart.UserID,epart.PartTime,epart.IsPass,epart.LevelID,epart.Comment,epart.CreatorTime,epart.DeleteMark,epart.Gender,epart.TrueName,epart.Phone 
FROM
(SELECT epart.id,epart.EmployID,epart.UserID,epart.PartTime,epart.IsPass,epart.LevelID,epart.Comment,epart.CreatorTime,epart.DeleteMark,user.Gender,user.TrueName,user.Phone
FROM plkjds.EmployPart AS epart LEFT JOIN plkjds.User  AS user
ON epart.UserID  = user.ID) AS epart LEFT JOIN Employ AS employ
ON epart.EmployID = employ.ID";

            var e = ExtLinq.True<EmployListModel>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            e = e.And(x => x.EmployID == keyValue);
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.TrueName.Contains(keyword));
            }
            var list =  repository.FindList<EmployListModel>(e,sql, pagination);
            return list;
        }


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
            //{ TotalPage=null, TotalRecord=null, List=null };
            //List:Id, Name:市场推广, Type:兼职, Cpy:湖南纽曼数码科技有限公司, Address:工作地点, Count:招聘人数, PubDT:发布时间, Pay:薪资
            string sql = @"select
	emp.Id, 
	emp.`Name`, 
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
(select ID Id, Title `Name`, TypeID, AreaID, '' PostID, CompanyName Cpy, Address, PeopleCount Count, PublishTime,Salary Pay from employ where DeleteMark<>1) emp
left join (select ID Id, TypeName `Name` from employtype where DeleteMark<>1) ety on ety.Id=emp.TypeID";

            var pre = ExtLinq.True<JobModel>();
            if (!string.IsNullOrEmpty(jobPostId))
            {
                pre = pre.And(x => x.PostId.Contains(jobPostId.ToLower()));
            }
            if (!string.IsNullOrEmpty(jobTypeId))
            {
                pre = pre.And(x => x.TypeId.Contains(jobTypeId.ToLower()));
            }
            if (!string.IsNullOrEmpty(jobAreaId))
            {
                pre = pre.And(x => x.AreaId.Contains(jobAreaId.ToLower()));
            }
            var page = new Pagination { page = pageNo, rows = pageSize };
            var list = repository.FindList<JobModel>(pre, sql, page);
            var model = new JobsModel { List = list, TotalPage = page.total, TotalRecord = page.records };
            return model;
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
}
