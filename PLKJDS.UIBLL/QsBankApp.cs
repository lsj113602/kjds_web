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
    public class QsBankApp
    {
        private IRepositoryBase repository = new RepositoryBase();

        public object GetQsBanks(string key, int pageNo, int pageSize)
        {
            string sql = @"select ID,OrgName,StrName,FileExt,FilePath from QsBank";

            var pre = ExtLinq.True<QsBankModel>();
            if (!string.IsNullOrEmpty(key))
            {
                pre = pre.And(x => x.OrgName.Contains(key.ToLower()));
            }

            var page = new Pagination { page = pageNo, rows = pageSize, sidx = "CreatorTime", sord = "desc" };
            var list = repository.FindList<QsBankModel>(pre, sql, page);

            var model = new { List = list, TotalPage = page.total, TotalRecord = page.records };
            return model;
        }
    }

    public class QsBankModel 
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)
        public string OrgName { get; set; } // OrgName (length: 300)
        public string StrName { get; set; } // StrName (length: 300)
        public string FileExt { get; set; } // FileExt (length: 50)
        public string FilePath { get; set; } // FilePath (length: 2147483647)
        public DateTime? CreatorTime { get; set; }
    }
}
