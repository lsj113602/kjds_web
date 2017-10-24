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
   public class TrainParterApp
    {
       private ITrainParterRepository service = new TrainParterRepository();

       public List<TrainPartModel> GetParterList(string trainID)
       {
           List<TrainPartModel> list = new List<TrainPartModel>();
           StringBuilder sb = new StringBuilder();
           sb.Append(@"select d.ID, d.TrainID ,c.TrueName,c.Gender,c.Orgname,c.Phone,d.PartTime from  
 (SELECT a.ID,a.TrueName,a.Gender,a.Phone,b.OrgName 
 FROM plkjds.User as a left join plkjds.Organize as b on  a.OrgID=b.ID) c
 right join plkjds.TrainParter  as d on c.ID=d.UserID");
           IRepositoryBase db = new RepositoryBase();
           list = db.FindList<TrainPartModel>(sb.ToString()).Where(t => t.TrainID==trainID).ToList();
           return list;
       }
    }
}
