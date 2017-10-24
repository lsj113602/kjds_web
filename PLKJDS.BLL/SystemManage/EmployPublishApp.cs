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
    public class EmployPublishApp
    {
        private IEmployPublishRepository service = new EmployPublishRepository();

        public int AddMutiEmployType(string EmployID,string OrgUserID,string ROrgUserID)
        {
            EmployPublish model = new EmployPublish();
            model.Create();
            model.DeleteMark = false;
            model.EmployID = EmployID;
            model.OrgUserID = OrgUserID;
            model.ROrgUserID = ROrgUserID;
            int res = service.Insert(model);
            return res;
        }

        public List<EmployPublish> GetList(string employID)
        {
            var list = service.IQueryable().Where(x => x.DeleteMark == null ? false : x.DeleteMark != x.DeleteMark && x.EmployID == employID).ToList();
            return list;
        }
    }
}
