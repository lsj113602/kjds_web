using PLKJDS.Common;
using PLKJDS.Common.Enums;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.BLL.SystemManage
{
    public class QsBankApp
    {
        private IQsBankRepository service = new QsBankRepository();

        //查询
        public List<QsBank_ItemModel> Get(Pagination pagination, string keyword)
        {
            var pre = ExtLinq.True<QsBank>();
            pre = pre.And(x => x.DeleteMark != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                pre = pre.And(x => x.OrgName.Contains(keyword));
            }
            var data = service.FindList(pre, pagination);
            var list = data.Select(x => new QsBank_ItemModel
            {
                ID = x.ID,
                CreatorTime = x.CreatorTime.HasValue ? x.CreatorTime.Value.ToString("yyyy-MM-dd HH:mm") : "",
                FileExt = x.FileExt,
                FilePath = x.FilePath,
                OrgName = x.OrgName,
                StrName = x.StrName
            }).ToList();
            return list;
        }

        //添加
        public bool Add(QsBank_AddParam param)
        {
            if (param == null)
            {
                return false;
            }
            var model = new QsBank
            {
                FileExt = param.FileExt,
                FilePath = param.FilePath,
                OrgName = param.OrgName,
                StrName = param.StrName,
                DeleteMark = false
            };
            model.Create();
            service.Insert(model);
            return true;
        }

        //删除
        public bool Del(string id)
        {
            var model = service.FindEntity(id);
            if (model != null)
            {
                service.Delete(model);
            }
            return true;
        }

        public List<QsBank_ItemModel> Get(string[] ids) 
        {
            var sql = string.Format("select ID,OrgName,StrName,FileExt,FilePath,CreatorTime from QsBank where ID in (\"{0}\")", 
               string.Join("\",\"", ids));
            var list = new PLKJDS.Data.RepositoryBase().FindList<QsBank_ItemModel>(sql);
            return list;
        }
    }

    public class QsBank_ItemModel 
    {
        public string ID { get; set; } 
        public string OrgName { get; set; } 
        public string StrName { get; set; } 
        public string FileExt { get; set; } 
        public string FilePath { get; set; }
        public string CreatorTime { get; set; }
    }
    public class QsBank_AddParam 
    {
        public string OrgName { get; set; }
        public string StrName { get; set; }
        public string FileExt { get; set; }
        public string FilePath { get; set; }
        public string CreatorUserId { get; set; }
        public System.DateTime? CreatorTime { get; set; }
    }
}
