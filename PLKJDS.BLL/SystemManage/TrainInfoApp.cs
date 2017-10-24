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
    public class TrainInfoApp
    {
        private ITrainInfoRepository service = new TrainInfoRepository();
        private ITrainDataRepository data_service = new TrainDataRepository();

        public List<TrainInfo> GetTrainInfoList(string keyValue)
        {
            var list = service.IQueryable().Where(t => t.DeleteMark == null ? false : t.DeleteMark != true).ToList();
            foreach (var item in list)
            {
                item.StatusCode = GetStatuCode(item.StartTime, item.EndTime, item.ApplySTime, item.ApplyETime);
            }
            return list;
        }
        
        public int AddOrUpdateTrainInfo(TrainInfo traininfo,string keyValue)
        {
            int result = 0;
            if(string.IsNullOrEmpty(keyValue))
            {
                TrainInfo model = new TrainInfo();
                model.Create();
                model.TrainTitle = traininfo.TrainTitle;
                model.Address = traininfo.Address;
                model.ApplyETime = traininfo.ApplyETime;
                model.ApplySTime = traininfo.ApplySTime;
                model.StartTime = traininfo.StartTime;
                model.EndTime = traininfo.EndTime;
                model.Content = traininfo.Content;
                model.PartNumber = 0;
                model.LimitNumber = traininfo.LimitNumber;
                model.PhotoID=traininfo.PhotoID;
                model.PublishTime=traininfo.PublishTime;
                model.UserID=traininfo.UserID;
                model.Host = traininfo.Host;
                model.DeleteMark = false;
                model.StatusCode = GetStatuCode(traininfo.StartTime, traininfo.EndTime, traininfo.ApplySTime, traininfo.ApplyETime);
                result = service.Insert(model);
            }
            else
            {
                var train = service.FindEntity(keyValue);
                train.TrainTitle = traininfo.TrainTitle;
                train.ApplyETime = traininfo.ApplyETime;
                train.ApplySTime = traininfo.ApplySTime;
                train.StartTime = traininfo.StartTime;
                train.EndTime = traininfo.EndTime;
                train.Content = traininfo.Content;
                train.PartNumber = traininfo.PartNumber;
                train.LimitNumber = traininfo.LimitNumber;
                train.PhotoID = traininfo.PhotoID;
                train.PublishTime = traininfo.PublishTime;
                train.UserID = traininfo.UserID;
                train.Host = traininfo.Host;
                train.Address = traininfo.Address;
                train.StatusCode = GetStatuCode(traininfo.StartTime, traininfo.EndTime, traininfo.ApplySTime, traininfo.ApplyETime);
                 result = service.Update(train);
            }
            return result;
        }

        public int DeleteForm(string keyvalue)
        {
            var model = service.FindEntity(keyvalue);
            model.DeleteMark = true;
            int result = service.Update(model);
            return result;
        }

        public string GetStatuCode(DateTime? datestr1, DateTime? datastr2, DateTime? datestr3, DateTime? datestr4)
        {
            string StatusCode = "";
            var starttime = Convert.ToDateTime(datestr1);
            var endtime = Convert.ToDateTime(datastr2);
            var applystime = Convert.ToDateTime(datestr3);
            var applyetime = Convert.ToDateTime(datestr4);

            if (DateTime.Compare(DateTime.Now, applystime) <0)
            {
                StatusCode = "2";//报名即将开始
            }
            else if (DateTime.Compare(endtime, DateTime.Now) <0)
            {
                StatusCode = "1";//活动已结束
            }
            else if (DateTime.Compare(DateTime.Now, applystime) > 0 && DateTime.Compare(DateTime.Now, applyetime)  <0)
            {
                StatusCode = "0";//报名中
            }
            else if (DateTime.Compare(DateTime.Now, endtime) < 0 && DateTime.Compare(DateTime.Now, starttime) > 0)
            {
                StatusCode = "3";//活动进行中
            }
            else
            {
                StatusCode = "4";
            }
            return StatusCode;
        }

        public TrainInfo GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public int AddSummary(string trainID,string summary)
        {
            var model = service.FindEntity(trainID);
            model.Summary = summary;
            model.LastModifyTime = DateTime.Now;
            var result = service.Update(model);
            return result;
        }

        #region 获取活动总结图片
        public List<TrainData> GetTrainDataList(string trainID)
        {
            var list = data_service.IQueryable().Where(x => x.TrainID == trainID && (x.DeleteMark == null ? false : x.DeleteMark) != true).ToList();
            return list;
        }
        #endregion 
    }
}
