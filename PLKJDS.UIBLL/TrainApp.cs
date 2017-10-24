using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Common;
using PLKJDS.UIEntity.UI;
using PLKJDS.Entity;
using PLKJDS.Data;
using System.Configuration;

namespace PLKJDS.UIBLL
{
    public class TrainApp
    {
        ITrainInfoRepository trainInfoDal= new TrainInfoRepository();
        IRepositoryBase repository = new RepositoryBase();

        public List<TrainInfo> FindBystarttime()
        {
            string sql = "select * from traininfo where DeleteMark!=true ORDER BY StartTime desc limit 4";
            List<TrainInfo> list=trainInfoDal.FindList(sql).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].PhotoID = adminurl + list[i].PhotoID;
            }
            return list;
        }

        string adminurl = ConfigurationManager.AppSettings["AdminUrl"].ToString().Trim();
        public List<TrainListModel> GetTrainList(string keyword, string sql, Pagination pagination, string levelID, int statusCode)
        {
            var e = ExtLinq.True<TrainListModel>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.TrainTitle.Contains(keyword));
            }

            var list = repository.FindList<TrainListModel>(e, sql, pagination).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                list[i].PhotoID = adminurl + list[i].PhotoID;
            }
            return list;
        }

        public List<TrainInfo> GetTrainList2(string keyword, Pagination pagination, string levelID, int statusCode)
        {
            var e = ExtLinq.True<TrainInfo>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            if (levelID == "0")
            {
                pagination.sidx = "PartNumber";
            }else if (levelID=="1")
            {
                DateTime now = DateTime.Now;
                e = e.And(x => x.EndTime <= now);
            }else
            {
                pagination.sidx = "StartTime";
            }
            
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.TrainTitle.Contains(keyword));
            }
            var list = trainInfoDal.FindList(e, pagination).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].PhotoID = adminurl + list[i].PhotoID;
            }
            return list;
        }

        public TrainInfo GetTrainDetail(string trainID)
        {
            TrainInfo traininfo=trainInfoDal.FindEntity(trainID);
            if (traininfo!=null)
            {
                traininfo.PhotoID = adminurl + traininfo.PhotoID;
            }            
            return traininfo;
        }
    }
}
