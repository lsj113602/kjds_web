using PLKJDS.BLL.SystemManage;
using PLKJDS.Common;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLKJDS.Admin.Controllers
{
    public class TrainInfoController : ControllerBase
    {
        //
        // GET: /TrainInfo/

        TrainInfoApp trainInfo = new TrainInfoApp();

        public ActionResult GetGridJson()
        {
            var list = trainInfo.GetTrainInfoList("");
            return Content(list.ToJson());
        }

        public ActionResult Summary()
        {
            return View();
        }

        public ActionResult Parters()
        {
            return View();
        }

       public ActionResult SubmitForm(TrainInfo train,string keyValue)
       {
           var result = trainInfo.AddOrUpdateTrainInfo(train, keyValue);
           if(result==1)
           {
               return Success("操作成功");
           }
           else
           {
               return Error("操作失败"); 
           }
       }

        public ActionResult GetFormJson(string keyValue)
       {
           TrainInfo model = new TrainInfo();
            if(!string.IsNullOrEmpty(keyValue))
            {
                model = trainInfo.GetForm(keyValue);
            }
            return Content(model.ToJson());
       }

        public ActionResult Details()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult SubmitSummary(TrainData traindata, string summary)
        {
            TrainDataApp dataApp = new TrainDataApp();
            var result = trainInfo.AddSummary(traindata.TrainID, summary);
            if (result == 1)
            {
                if (traindata.FileID.Contains(','))
                {
                    string[] fileArr = traindata.FileID.Split(',');
                    for (int i = 0; i < fileArr.Length; i++)
                    {
                        dataApp.AddTrainSummary(traindata.TrainID, fileArr[i]);
                    }
                }
                else
                {
                    dataApp.AddTrainSummary(traindata.TrainID, traindata.FileID);
                }
                return Success("操作成功");
            }
            else
            {
                return Error("操作失败");
            }

        }

        public ActionResult GetParterJson(string keyValue)
        {
            TrainParterApp trainparterapp = new TrainParterApp();
            var list = trainparterapp.GetParterList(keyValue);
            return Content(list.ToJson());
        }

        public ActionResult GetTrainDataList(string trainID)
        {
            var list = trainInfo.GetTrainDataList(trainID);
            return Content(list.ToJson());
        }

        public ActionResult DeleteForm(string keyvalue)
        {
            int result = trainInfo.DeleteForm(keyvalue);
            if (result == 1)
            {
                return Success("操作成功");
            }
            else
            {
                return Error("操作失败");
            }
        }
    }
}