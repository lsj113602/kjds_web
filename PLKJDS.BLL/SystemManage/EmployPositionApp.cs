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
   public class EmployPositionApp
    {
       private IEmployPositionRepository service = new EmployPositionRepository();

       public List<EmployPosition> GetPositionList()
       {
           var list = service.IQueryable().Where(t => t.DeleteMark == null ? false : t.DeleteMark != true).OrderBy(t=>t.SortCode).ToList();
           return list;
       }

       public int AddPositon(string posname,int sortcode)
       {
           int res = 0;
           if(service.IQueryable().Where(x=>x.PosName==posname).ToList().Count>=1)
           {
               res = -1;
           }
           else
           {
               EmployPosition model = new EmployPosition();
               model.Create();
               model.DeleteMark = false;
               model.PosName = posname;
               model.SortCode = sortcode;
               res = service.Insert(model);
           }

           return res;
       }
    }
}
