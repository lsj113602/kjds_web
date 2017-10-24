using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.Data;
using PLKJDS.UIEntity.UI;
using PLKJDS.Common;
using System.Data.Common;
using System.Configuration;

namespace PLKJDS.UIBLL
{
    public class UserCourseApp
    {
        IRepositoryBase repository = new RepositoryBase();
        
        //获取课程
        public object Get(string userId, string state, int pageNo, int pageSize)
        {
            string sql = @"select 
	            c.ID Id,
	            c.PhotoID Logo,
	            c.CourseName `Name`,
	            o.OrgName School,
	            u.TrueName Teacher,
	            c.`Desc`,
                c.StartTime,
                c.EndTime,
	            uc.CreatorTime
             from (select * from UserCourse where UserID='"+userId+@"') uc
            left join Course c on c.ID=uc.CourseID
            left join user u on u.ID=c.CreateCourseUserID
            left join organize o on o.ID=u.OrgID";

            var pre = ExtLinq.True<UserCourseModel>();
            if (!string.IsNullOrEmpty(state))
            {
                var now = DateTime.Now;
                if (state == "0")
                {
                    pre = pre.And(x => now < x.StartTime);
                }
                else if (state == "1")
                {
                    pre = pre.And(x => now >= x.StartTime && now <= x.EndTime);
                }
                else if (state == "2")
                {
                    pre = pre.And(x => now > x.EndTime);
                }
            }
            var page = new Pagination { page = pageNo, rows = pageSize, sidx = "CreatorTime", sord = "desc" };
            var list = repository.FindList<UserCourseModel>(pre, sql, page);
            var model = new { List = list, TotalPage = page.total, TotalRecord = page.records };
            return model;
        }
    }

    public class UserCourseModel
    {
        public string Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public string Teacher { get; set; }
        public string Desc { get; set; }
        public DateTime? CreatorTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
